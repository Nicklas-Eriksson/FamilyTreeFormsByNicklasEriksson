using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace FamilyTree
{
    public class DataAccess
    {
        public List<Person> GetPeopleByName(string name)
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
    }
}
