using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    public class Person
    {
        public int Id { get; set; }
        public string fullName { get; set; }
        public int yearOfBirth { get; set; }
        public string placeOfBirth { get; set; }
        public int motherId { get; set; }
        public int fatherId { get; set; }
        public int yearOfDeath { get; set; }
        public string placeOfDeath { get; set; }
    }
}
