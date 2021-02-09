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
        public string motherName { get; set; }
        public int fatherId { get; set; }
        public string fatherName { get; set; }
        public int yearOfDeath { get; set; }
        public string placeOfDeath { get; set; }

        public string GetFullName
        {
            get { return fullName; }
        }
        public int GetYearOfBirth
        {
            get { return yearOfBirth; }
        }
        public string GetPlaceOfBirth
        {
            get { return placeOfBirth; }
        }
        public string GetMotherName
        {
            get { if (fatherName == null) { return "-no register found-"; } else { return motherName; } }
        }
        public string GetFatherName
        {
            get { if (fatherName == null){ return "-no register found-"; } else{return fatherName; } }
        }
        public string GetYearOfDeath
        {
            get { if (yearOfDeath == 0){ return "--"; } else{ return yearOfDeath.ToString(); } }
        }
        public string GetPlaceOfDeath
        {
            get { if (placeOfDeath == null) { return "--"; } else { return placeOfDeath; } }
        }
    }
}
