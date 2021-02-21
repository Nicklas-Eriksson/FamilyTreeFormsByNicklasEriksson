using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;

namespace FamilyTree
{
    public class DataAccess
    {
        #region Overloaded GetAll()
        /// <summary>
        /// Retrieves all people from the SQL-database.
        /// </summary>
        /// <returns>List of Persons.</returns>
        internal List<Person> GetAll()
        {
            //Reference to Dapper, via nugget   
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Utility.Cnn("FamilyTreeDB")))
            {
                //This one is prone to SQL injection
                //return connection.Query<Person>($"select * from People where fullName = '{name}'").ToList();

                //This one is safer
                return connection.Query<Person>("dbo.spPeople_GetAll").ToList();
            }
        }

        /// <summary>
        /// Retrieves one person from the SQL-database if it matches with the search result.
        /// Used if you need to search every one in database using LIKE % %.
        /// </summary>
        /// <param name="input">Search box input that is used for the LIKE search.</param>
        /// <returns>List of Persons.</returns>
        internal List<Person> GetAll(string input)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Utility.Cnn("FamilyTreeDB")))
            {
                //The Person object needs to contain "SearchInput" so that it can be exactly matched against the SQL databases "@SearchInput", otherwise it will cast a "must declare the scalar variable"-error.
                var DynamicObject = new DynamicParameters(new Person { SearchInput = input });
                var queryList = connection.Query<Person>("dbo.People_SearchLIKE @SearchInput", DynamicObject).ToList();

                new Dashboard().GetParentsNamesFrom(queryList);
                return queryList;
            }
        }
        #endregion Overloaded GetAll()
                
        /// <summary>
        /// Searches the SQL-database for siblings using name from person being searched for. Requires full name.
        /// </summary>
        /// <param name="name">Name for the person that the data base will find siblings for.</param>
        /// <returns>List of Persons, returns list with siblings.</returns>
        internal List<Person> GetRelativesByName(string name)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Utility.Cnn("FamilyTreeDB")))
            {
                var DynamicObject = new DynamicParameters(new Person { FullName = name });
                return connection.Query<Person>("dbo.People_FindSiblings @fullName", DynamicObject).ToList();
            }
        }

        /// <summary>
        /// Takes in a person, converts it to a "Dynamic Parameter" that gets inserted into SQL to be updated in the SQL-database.
        /// </summary>
        /// <param name="person">Takes in a person that will be updated in DB.</param>
        /// <returns>List of Persons.</returns>
        internal List<Person> Update(Person person)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Utility.Cnn("FamilyTreeDB")))
            {
                var DynamicObject = new DynamicParameters(person);
                return connection.Query<Person>("dbo.People_UpdatePerson @id, @fullName, @yearOfBirth, @placeOfBirth, @motherId, @fatherId, @yearOfDeath, @placeOfDeath", DynamicObject).ToList();
            }
        }

        /// <summary>
        /// Inserts a number of persons to act as mock data for the family tree project.
        /// </summary>
        /// <returns>List of persons.</returns>
        internal List<Person> AddMockData()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Utility.Cnn("FamilyTreeDB")))
            {
                return connection.Query<Person>("dbo.People_InsertMockData").ToList();
            }
        }

        /// <summary>
        /// After mock data has been added to the database it gets updated so that parent connections will be set correctly. Parents ID# is linked to the dbo.Person ID# that is the tables primary key.
        /// </summary>
        internal void AlterMockData()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Utility.Cnn("FamilyTreeDB")))
            {
                connection.Execute("dbo.People_AlterMockData");
            }
        }

        /// <summary>
        /// Remakes the table dbo.Person so that the ID# counter will be reset.
        /// </summary>
        internal void RemakeTable()
        {
            DropTable();
            CreateTable();
        }
        internal void CreateTable()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Utility.Cnn("FamilyTreeDB")))
            {
                connection.Execute("dbo.People_CreateTablePeople");
            }
        }
        internal void DropTable()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Utility.Cnn("FamilyTreeDB")))
            {
                connection.Execute("DROP TABLE dbo.People");
            }
        }

        /// <summary>
        /// Inserts a new member to the database so it can be stored in the SQL-server.
        /// The method takes in parents names, but thereafter they get converted to their ID# number and sent into the database.
        /// </summary>
        /// <param name="_fullName">Full name.</param>
        /// <param name="_yearOfBirth">Year of birth.</param>
        /// <param name="_birthPlace">Birth place.</param>
        /// <param name="_motherName">Mothers name.</param>
        /// <param name="_fatherName">Fathers name.</param>
        /// <param name="_yearOfDeath">Year of death.</param>
        /// <param name="_placeOfDeath">Place of death-</param>
        internal List<Person> AddNewPerson(string _fullName, string _yearOfBirth, string _birthPlace, string _motherName, string _fatherName, string _yearOfDeath, string _placeOfDeath)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Utility.Cnn("FamilyTreeDB")))
            {
                var newDashboard = new Dashboard();
                List<Person> people = GetAll();
                bool success;
                int YOBint = 0, YODint = 0;

                success = Int32.TryParse(_yearOfBirth, out YOBint);
                success = Int32.TryParse(_yearOfDeath, out YODint);

                int momId = newDashboard.GetParentsId(_motherName, people);
                int dadId = newDashboard.GetParentsId(_fatherName, people);

                Person newPerson = new Person
                {
                    FullName = _fullName.Trim(),
                    YearOfBirth = YOBint,
                    PlaceOfBirth = _birthPlace.Trim(),
                    MotherId = momId,
                    FatherId = dadId,
                    YearOfDeath = YODint,
                    PlaceOfDeath = _placeOfDeath.Trim()
                };

                return CheckIfPersonAlreadyExist(connection, people, newPerson);
            }
        }

        /// <summary>
        /// Only adds a new person to the database if it does not already exist.
        /// Con to this: Only checks by full name, would use ID# if I wanted a more fool proof way.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="people"></param>
        /// <param name="newPersonToDatabase"></param>
        /// <param name="newPerson">Person to be added to DB.</param>
        private List<Person> CheckIfPersonAlreadyExist(IDbConnection connection, List<Person> people, Person newPerson)
        {
            bool contains = false;
            for (int i = 0; i < people.Count; i++)
            {
                if (newPerson.FullName == people[i].FullName)
                {
                    contains = true;
                }
            }

            if (!contains)
            {                
                connection.Execute("dbo.People_Insert @fullName, @yearOfBirth, @placeOfBirth, @motherId, @fatherId, @yearOfDeath, @placeOfDeath", newPerson);
                people.Add(newPerson);
                return people;
            }

            return people;
        }

        /// <summary>
        /// Wipes the dbo.People table clean. So that it can be inserted anew.
        /// </summary>
        internal void DeleteAllFromTable()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Utility.Cnn("FamilyTreeDB")))
            {
                connection.Execute("dbo.People_EmptyTable");
            }
        }

        /// <summary>
        /// If a person is deleted from the program it will also remove that person from the SQL-database.
        /// </summary>
        /// <param name="person"></param>
        internal static void Delete(Person person)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Utility.Cnn("FamilyTreeDB")))
            {
                var DynamicObject = new DynamicParameters(person);
                connection.Execute(@"dbo.People_Delete @fullName", DynamicObject);
            }
        }
    }
}