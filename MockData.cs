using System.Collections.Generic;

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
            DB.GetParentsNames(people);

            return people;
        }
    }
}