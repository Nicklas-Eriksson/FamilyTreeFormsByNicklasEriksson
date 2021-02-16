using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    public class MockData
    {
        public List<Person> ResetData(List<Person> people)
        {            
            var DB = new Dashboard();
            var DA = new DataAccess();
            DA.RemakeTable();
            people = DA.AddMockData();
            DA.AlterMockData();
            DB.GetMotherAndFatherNameFromID(people);

            return people;
        }
    }
}
