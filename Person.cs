using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    public class Person : IPersonable
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int YearOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public int MotherId { get; set; }
        public string MotherName { get; set; }
        public int FatherId { get; set; }
        public string FatherName { get; set; }
        public int YearOfDeath { get; set; }
        public string PlaceOfDeath { get; set; }
        public string SearchInput { get; set; }

        public string GetFullName
        {
            get { return FullName; }
        }
        public int GetYearOfBirth
        {
            get { return YearOfBirth; }
        }
        public string GetPlaceOfBirth
        {
            get { if (PlaceOfBirth == null) { return "--"; } else { return PlaceOfBirth; } }
        }
        public string GetMotherName
        {
            get { if (MotherName == null) { return "--"; } else { return MotherName; } }
        }
        public string GetFatherName
        {
            get { if (FatherName == null){ return "--"; } else{return FatherName; } }
        }
        public string GetYearOfDeath
        {
            get { if (YearOfDeath == 0){ return "--"; } else{ return YearOfDeath.ToString(); } }
        }
        public string GetPlaceOfDeath
        {
            get { if (PlaceOfDeath == null) { return "--"; } else { return PlaceOfDeath; } }
        }       
    }
}
