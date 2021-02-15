using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using System.Threading;

namespace FamilyTree
{
    public class DataAccess
    {
        internal List<Person> GetAll()
        {
            //Reference to Dapper, via nugget   
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Utility.Cnn("FamilyTreeDB")))
            {
                //This one is prone to SQL injection
                //return connection.Query<Person>($"select * from People where fullName = '{name}'").ToList();

                //This one is safer
                var fullList = connection.Query<Person>("dbo.spPeople_GetAll").ToList();
                return fullList;
            }
        }

        internal List<Person> GetRelativesByName(string name, string relative)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Utility.Cnn("FamilyTreeDB")))
            {
                var DynamicObject = new DynamicParameters(new Person { FullName = name });
                List<Person> fullList = new List<Person>();

                if (relative == "siblings")
                {
                    fullList = connection.Query<Person>("dbo.People_FindSiblings @fullName", DynamicObject).ToList();
                }
                else if (relative == "parents")
                {
                    fullList = connection.Query<Person>("dbo.People_FindParents @fullName", DynamicObject).ToList();
                }
                else if (relative == "kids")
                {
                    fullList = connection.Query<Person>("dbo.People_FindKids @fullName", DynamicObject).ToList();
                }
                return fullList;
            }
        }

        internal List<Person> AddMockData()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Utility.Cnn("FamilyTreeDB")))
            {
                List<Person> fullList = new List<Person>();
                fullList = connection.Query<Person>("dbo.People_InsertMockData").ToList();
               
                var DB = new Dashboard();
                DB.GetMotherAndFatherNameFromID(fullList);
                return fullList;
            }
        }

        internal void AlterMockData()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Utility.Cnn("FamilyTreeDB")))
            {    
                connection.Query<Person>("dbo.People_AlterMockData").ToList();               
            }
        }

        internal void RemakeTable()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Utility.Cnn("FamilyTreeDB")))
            {    
                connection.Query<Person>("DROP TABLE dbo.People");               
                connection.Query<Person>("dbo.People_CreateTablePeople");               
            }
        }

        internal void AddNewPerson(string _fullName, string _yearOfBirth, string _birthPlace, string _motherName, string _fatherName, string _yearOfDeath, string _placeOfDeath)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Utility.Cnn("FamilyTreeDB")))
            {
                //sets value to 0 if text entered wont be parsed. Since 0 will be set shown as --
                int _YOBint = 0, _YODint = 0, momId = 0, dadId = 0;
                bool success;
                success = Int32.TryParse(_yearOfBirth, out _YOBint);
                success = Int32.TryParse(_yearOfDeath, out _YODint);

                //Retrieves people and populate new list. Uses to find #ID for parents
                var newDashboard = new Dashboard();
                List<Person> populatedList = new List<Person>();
                populatedList = newDashboard.people;

                //Searches for mother's and father's #ID, that is what SQL needs
                bool motherSuccess = false, fatherSuccess = false;
                momId = FindMotherId(_motherName, momId, populatedList);
                if (momId != 0) { motherSuccess = true; }
                dadId = FindFatherId(_fatherName, momId, populatedList);
                if (dadId != 0) { fatherSuccess = true; }

                List<Person> newPersonToDataBase = new List<Person>();

                //Creating new person
                if (motherSuccess && fatherSuccess)
                {
                    Person nP = new Person
                    {
                        Id = 100,
                        FullName = _fullName, //string
                        YearOfBirth = _YOBint, //converted to in
                        PlaceOfBirth = _birthPlace, //string
                        MotherId = momId, //converted to in
                        FatherId = dadId, //converted to in
                        YearOfDeath = _YODint, //converted to in
                        PlaceOfDeath = _placeOfDeath //string
                    };

                    newPersonToDataBase.Add(nP);
                }
                else
                {
                    Person nP = new Person
                    {
                        Id = 100,
                        FullName = _fullName, //string
                        YearOfBirth = _YOBint, //converted to in
                        PlaceOfBirth = _birthPlace, //string     
                        YearOfDeath = _YODint, //converted to in
                        PlaceOfDeath = _placeOfDeath //string
                    };

                    newPersonToDataBase.Add(nP);
                }

                if (motherSuccess && fatherSuccess)
                {
                    connection.Execute("dbo.People_Insert @Id, @fullName, @yearOfBirth, @placeOfBirth, @motherId, @fatherId, @yearOfDeath, @placeOfDeath", newPersonToDataBase);
                }
                else
                {
                    connection.Execute("dbo.People_Insert @Id, @fullName, @yearOfBirth, @placeOfBirth, @motherId, @fatherId, @yearOfDeath, @placeOfDeath", newPersonToDataBase);
                }
            }
        }

        internal void DeleteAllFromTable()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Utility.Cnn("FamilyTreeDB")))
            {
                connection.Query<Person>("dbo.People_EmptyTable");
            }
        }

        internal static void Delete(Person person)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Utility.Cnn("FamilyTreeDB")))
            {
                var DynamicObject = new DynamicParameters(person);
                connection.Query<Person>(@"dbo.People_Delete @fullName", DynamicObject);
            }
        }

        private static int FindFatherId(string _fatherName, int dadId, List<Person> populatedList)
        {
            for (int i = 0; i < populatedList.Count; i++)
            {
                if (populatedList[i].FullName == _fatherName)
                {
                    dadId = populatedList[i].Id;
                    break;
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
            }
            return momId;
        }
    }
}
