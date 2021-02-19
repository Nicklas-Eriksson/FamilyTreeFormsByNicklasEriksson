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
        /// Retrieves all people from the SQL-database.
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

                new Dashboard().GetParentsNames(queryList);
                return queryList;
            }
        }
        #endregion Overloaded GetAll()

        //internal string SQLSandbox(string input)
        //{
        //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Utility.Cnn("FamilyTreeDB"))) //Make another DB for sandbox
        //    {               
        //        //try
        //        //{
        //        //    var QuaryResults = connection.Query($"{input}").ToString();
        //        //    return QuaryResults;
        //        //}
        //        //catch
        //        //{
        //        //    var DA = new Dashboard();
        //        //    string emptyString = "";
        //        //    return emptyString;
        //        //}
        //    }
        //}

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
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Utility.Cnn("FamilyTreeDB")))
            {
                connection.Execute("DROP TABLE dbo.People");
                connection.Execute("dbo.People_CreateTablePeople");
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
        internal void AddNewPerson(string _fullName, string _yearOfBirth, string _birthPlace, string _motherName, string _fatherName, string _yearOfDeath, string _placeOfDeath)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Utility.Cnn("FamilyTreeDB")))
            {
                var newDashboard = new Dashboard();
                List<Person> populatedList = populatedList = newDashboard.people;
                List<Person> newPersonToDataBase = new List<Person>();
                bool motherSuccess = false, fatherSuccess = false;
                bool success;
                int YOBint = 0, YODint = 0, momId = 0, dadId = 0;

                success = Int32.TryParse(_yearOfBirth, out YOBint);
                success = Int32.TryParse(_yearOfDeath, out YODint);

                momId = newDashboard.GetParentsId(_motherName, populatedList);
                dadId = newDashboard.GetParentsId(_fatherName, populatedList);

                //if (_motherName != null)
                //{
                //    momId = FindMotherId(_motherName, momId, populatedList);
                //}
                //else
                //{
                //    momId = 0;
                //}

                //if (_motherName != null)
                //{
                //    dadId = FindFatherId(_fatherName, momId, populatedList);
                //}
                //else
                //{
                //    dadId = 0;
                //}

                Person nP = new Person
                {
                    FullName = _fullName.Trim(), //string
                    YearOfBirth = YOBint, //converted to int
                    PlaceOfBirth = _birthPlace.Trim(), //string
                    MotherId = momId, //converted to int
                    FatherId = dadId, //converted to int
                    YearOfDeath = YODint, //converted to int
                    PlaceOfDeath = _placeOfDeath.Trim() //string
                };

                if (!populatedList.Contains(nP))
                {
                    newPersonToDataBase.Add(nP);
                    connection.Execute("dbo.People_Insert @fullName, @yearOfBirth, @placeOfBirth, @motherId, @fatherId, @yearOfDeath, @placeOfDeath", newPersonToDataBase);
                }
            }
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_fatherName"></param>
        /// <param name="dadId"></param>
        /// <param name="populatedList"></param>
        /// <returns></returns>
        private static int FindFatherId(string _fatherName, int dadId, List<Person> populatedList)
        {
            for (int i = 0; i < populatedList.Count; i++)
            {
                if (populatedList[i].FullName == _fatherName)
                {
                    dadId = populatedList[i].Id;
                    break;
                }
                else
                {
                    dadId = 0;
                }
            }
            return dadId;
        }

        internal static int FindMotherId(string _motherName, int momId, List<Person> populatedList)
        {       
            for (int i = 0; i < populatedList.Count; i++)
            {
                if (populatedList[i].FullName == _motherName)
                {
                    momId = populatedList[i].Id;
                    break;
                }
                else
                {
                    momId = 0;
                }
            }
            return momId;
        }
    }
}