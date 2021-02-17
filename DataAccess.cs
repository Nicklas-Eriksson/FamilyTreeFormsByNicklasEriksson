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
                return connection.Query<Person>("dbo.spPeople_GetAll").ToList();
            }
        }

        internal List<Person> GetAll(string input)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Utility.Cnn("FamilyTreeDB")))
            {
                //The Person object needs to contain "SearchInput" so that it can be exactly matched against the SQL databases "@SearchInput", otherwise it will cast a "must declare the scalar variable"-error.
                var DynamicObject = new DynamicParameters(new Person { SearchInput = input });
                var queryList = connection.Query<Person>("dbo.People_SearchLIKE @SearchInput", DynamicObject).ToList();

                new Dashboard().GetMotherAndFatherNameFromID(queryList);
                return queryList;
            }
        }

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
                return connection.Query<Person>("dbo.People_InsertMockData").ToList();
            }
        }

        internal void AlterMockData()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Utility.Cnn("FamilyTreeDB")))
            {
                connection.Execute("dbo.People_AlterMockData");
            }
        }

        internal void RemakeTable()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Utility.Cnn("FamilyTreeDB")))
            {
                connection.Execute("DROP TABLE dbo.People");
                connection.Execute("dbo.People_CreateTablePeople");
            }
        }

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

                if (_motherName != null)
                {
                    momId = FindMotherId(_motherName, momId, populatedList);
                }
                else
                {
                    momId = 0;
                }

                if (_motherName != null)
                {
                    dadId = FindFatherId(_fatherName, momId, populatedList);
                }
                else
                {
                    dadId = 0;
                }

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

        internal void DeleteAllFromTable()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Utility.Cnn("FamilyTreeDB")))
            {
                connection.Execute("dbo.People_EmptyTable");
            }
        }

        internal static void Delete(Person person)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Utility.Cnn("FamilyTreeDB")))
            {
                var DynamicObject = new DynamicParameters(person);
                connection.Execute(@"dbo.People_Delete @fullName", DynamicObject);
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
