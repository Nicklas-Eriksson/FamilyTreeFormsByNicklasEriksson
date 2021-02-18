namespace FamilyTree
{
    interface IPersonable
    {
        int Id { get; set; }
        string FullName { get; set; }
        int YearOfBirth { get; set; }
        string PlaceOfBirth { get; set; }
        int MotherId { get; set; }
        int FatherId { get; set; }
        int YearOfDeath { get; set; }
        string PlaceOfDeath { get; set; }

        string GetFullName { get; }
        int GetYearOfBirth { get; }
        string GetPlaceOfBirth { get; }
        string GetMotherName { get; }
        string GetFatherName { get; }
        string GetYearOfDeath { get; }
        string GetPlaceOfDeath { get; }
    }
}
