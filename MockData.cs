using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace FamilyTree
{
    public class MockData
    {
        public List<Person> GetData(List<Person> people)
        {
            var DA = new DataAccess();
            bool dbExists = CheckDatabaseExists(Utility.Cnn("FamilyTreeDB"), "FamilyTree");

            if (dbExists)
            {
                DA.RemakeTable();
                people = DA.AddMockData();
                DA.AlterMockData();
                new Dashboard().GetParentsNames(people);

                return people;
            }
            else
            {
                SqlConnection connect = new SqlConnection(Utility.Cnn("FamilyTreeDB"));
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                try
                {
                    connect.Open();
                    cmd.CommandText = "CREATE DATABASE FamilyTree;";
                    cmd.ExecuteNonQuery();
                }
                catch
                {

                }
                //finally
                //{
                //    connect.Close();
                //}

                //DA.RemakeTable();
                //people = DA.AddMockData();
                //DA.AlterMockData();
                //new Dashboard().GetParentsNames(people);
                return people;
            }
        }

        public static bool CheckDatabaseExists(string connectionString, string databaseName)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand($"SELECT db_id('{databaseName}')", connection))
                {
                    connection.Open();
                    return (command.ExecuteScalar() != DBNull.Value);
                }
            }
        }

    }
}