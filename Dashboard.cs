using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FamilyTree
{
    public partial class Dashboard : Form
    {
        public List<Person> people = new List<Person>();
        private List<Person> foundPerson = new List<Person>();
        private List<Person> siblings = new List<Person>();
        private List<Person> parents = new List<Person>();
        private List<Person> kids = new List<Person>();

        public Dashboard()
        {
            InitializeComponent();
            UpdateScrollListData(new DataAccess());
        }

        private void ResetDB_Button_Click(object sender, EventArgs e)
        {
            ResetDB();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            ResetListBoxes();
            TypeOfSearch();
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            DataAccess dataAccess = new DataAccess();
            var add = AddUpdateDelete_ComboBox.SelectedIndex == 0;
            var update = AddUpdateDelete_ComboBox.SelectedIndex == 1;
            var delete = AddUpdateDelete_ComboBox.SelectedIndex == 2;

            if (add)
            {
                AddNewMember(dataAccess);
            }
            else if (update)
            {
                UpdateMember(dataAccess);
            }
            else if (delete)
            {
                DeleteMember(dataAccess);
            }
        }

        private void CodeSandboxButton_Click(object sender, EventArgs e)
        {
            UserControl control = new UserControl();
            control.Dock = DockStyle.Fill;
            this.Controls.Add(control);
            new Dashboard2().Show();
        }





        private void ResetDB()
        {
            var MD = new MockData();
            people = MD.ResetData(people);
            GetParentNamesForRelatives(people);
        }

        private void ResetListBoxes()
        {            
            ListBoxName.DataSource = null;
            ListBoxName.Items.Clear();
            ListBoxYOB.DataSource = null;
            ListBoxYOB.Items.Clear();
            ListBoxPOB.DataSource = null;
            ListBoxPOB.Items.Clear();
            ListBoxMother.DataSource = null;
            ListBoxMother.Items.Clear();
            ListBoxFather.DataSource = null;
            ListBoxFather.Items.Clear();
            ListBoxYOD.DataSource = null;
            ListBoxYOD.Items.Clear();
            ListBoxPOD.DataSource = null;
            ListBoxPOD.Items.Clear();
                        
            foundPerson.Clear();
            people.Clear();
        }

        public void DisplayInfoFromList(List<Person> insertedList)
        {
            ListBoxName.DataSource = insertedList;
            ListBoxName.DisplayMember = "GetFullName";

            ListBoxYOB.DataSource = insertedList;
            ListBoxYOB.DisplayMember = "GetYearOfBirth";

            ListBoxPOB.DataSource = insertedList;
            ListBoxPOB.DisplayMember = "GetPlaceOfBirth";

            ListBoxMother.DataSource = insertedList;
            ListBoxMother.DisplayMember = "GetMotherName";

            ListBoxFather.DataSource = insertedList;
            ListBoxFather.DisplayMember = "GetFatherName";

            ListBoxYOD.DataSource = insertedList;
            ListBoxYOD.DisplayMember = "GetYearOfDeath";

            ListBoxPOD.DataSource = insertedList;
            ListBoxPOD.DisplayMember = "GetPlaceOfDeath";
        }

        private void AddNewMember(DataAccess dataAccess)
        {
            //Name, Year-/Place of birth, Mother-/Father name, Year-/Place of death
            dataAccess.AddNewPerson(TextBoxName.Text, TextBoxYearOfBirth.Text, TextBoxPlaceOfBirth.Text, TextBoxMother.Text, TextBoxFather.Text, TextBoxYearOfDeath.Text, TextBoxPlaceOfDeath.Text);

            people = dataAccess.GetAll();
            FindParents();
        }

        private void UpdateMember(DataAccess dataAccess)
        {
            for (int i = 0; i < people.Count; i++)
            {
                if (MemberList_ComboBox.SelectedItem.ToString() == people[i].FullName)
                {
                    bool success;
                    success = Int32.TryParse(TextBoxYearOfBirth.Text.Trim(), out int YOB);
                    success = Int32.TryParse(TextBoxYearOfDeath.Text.Trim(), out int YOD);
                    int momId = GetMotherId(i);
                    int dadId = GetFatherId(i);
                    UpdatePersonInformation(dataAccess, i, YOB, YOD, momId, dadId);
                    UpdateScrollListData(dataAccess);
                    break;
                }
            }
        }

        private void DeleteMember(DataAccess dataAccess)
        {
            for (int i = 0; i < people.Count; i++)
            {
                if (MemberList_ComboBox.SelectedItem.ToString() == people[i].FullName)
                {
                    DataAccess.Delete(people[i]);
                    break;
                }
            }

            UpdateScrollListData(dataAccess);
        }

        private void TypeOfSearch()
        {
            if (SearchMenu.SelectedIndex == 0)
            {
                NormalSearch();
            }
            else if (SearchMenu.SelectedIndex == 1)
            {
                FindAll();
            }
            else if (SearchMenu.SelectedIndex == 2)
            {
                FindSiblings(siblings);
            }
            else if (SearchMenu.SelectedIndex == 3)
            {
                FindKids();
            }
            else if (SearchMenu.SelectedIndex == 4)
            {
                FindParents();
            }
            else if (SearchMenu.SelectedIndex == 5)
            {
                FindCousins();
            }
        }

        private void NormalSearch()
        {
            foundPerson.Clear();
            people = new DataAccess().GetAll();
            FoundSearchedPerson();
            GetMotherAndFatherNameFromID(people);
            DisplayInfoFromList(foundPerson);
        }

        private void FindAll()
        {
            var db = new DataAccess();
            people.Clear();
            MemberList_ComboBox.Items.Clear();
            people = db.GetAll();

            foreach (var person in people)
            {
                MemberList_ComboBox.Items.Add(person.FullName);
            }

            GetMotherAndFatherNameFromID(people);
            DisplayInfoFromList(people);
        }

        private void FindSiblings(List<Person> insertedList)
        {
            people.Clear();
            people = new DataAccess().GetAll();
            insertedList = new DataAccess().GetRelativesByName(SearchText.Text);
            FoundSearchedPerson();

            for (int i = 0; i < insertedList.Count; i++)
            {
                if (foundPerson[0].Id == insertedList[i].Id)
                {
                    insertedList.Remove(insertedList[i]);
                }
            }
            GetMotherAndFatherNameFromID(people);
            GetParentNamesForRelatives(insertedList);
            DisplayInfoFromList(insertedList);
        }

        private void FindKids()
        {
            kids.Clear();
            var db = new DataAccess();
            people = db.GetAll();//Populates with every1 in sql
            FoundSearchedPerson(); //Populates the foundPersonList with the person from search

            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].MotherId == foundPerson[0].Id)
                {
                    kids.Add(people[i]);
                }
                else if (people[i].FatherId == foundPerson[0].Id)
                {
                    kids.Add(people[i]);
                }
            }

            GetMotherAndFatherNameFromID(people);
            DisplayInfoFromList(kids);
        }

        private void FindParents()
        {
            parents.Clear();
            people = new DataAccess().GetAll();
            FoundSearchedPerson();

            for (int i = 0; i < people.Count; i++)
            {
                if (foundPerson[0].MotherId == people[i].Id)
                {
                    parents.Add(people[i]);
                }
                else if (foundPerson[0].FatherId == people[i].Id)
                {
                    parents.Add(people[i]);
                }
            }

            GetMotherAndFatherNameFromID(people);
            DisplayInfoFromList(parents);
        }

        private void FindCousins()
        {
            var cousinList = new List<Person>();
            var parentsSiblings = new List<Person>();

            cousinList.Clear();
            parentsSiblings.Clear();
            foundPerson.Clear();
            parents.Clear();
                       
            FoundSearchedPerson();
            var DA = new DataAccess();
            people = DA.GetAll();

            for (int i = 0; i < people.Count; i++)
            {
                if (foundPerson[0].MotherId == people[i].Id)
                {
                    parents.Add(people[i]);
                }
                else if (foundPerson[0].FatherId == people[i].Id)
                {
                    parents.Add(people[i]);
                }
            }

            foreach (var parent in parents)
            {
                parentsSiblings.AddRange(DA.GetRelativesByName(parent.FullName));
            }

            for (int j = 0; j < parentsSiblings.Count; j++)
            {
                for (int k = 0; k < people.Count; k++)
                {
                    if (people[k].MotherId == parentsSiblings[j].Id)
                    {
                        cousinList.Add(people[k]);
                    }
                    else if (people[k].FatherId == parentsSiblings[j].Id)
                    {
                        cousinList.Add(people[k]);
                    }
                }
            }

            for (int i = 0; i < cousinList.Count; i++)
            {
                if(foundPerson[0].Id == cousinList[i].Id)
                {
                    cousinList.Remove(cousinList[i]);
                }
            }

            GetMotherAndFatherNameFromID(cousinList);
            DisplayInfoFromList(cousinList);            
        }

        private void FoundSearchedPerson()
        {
            var DA = new DataAccess();
            string input = SearchText.Text;
            foundPerson = DA.GetAll(input);
            GetMotherAndFatherNameFromID(foundPerson);
        }

        private void UpdateScrollListData(DataAccess db)
        {
            MemberList_ComboBox.Items.Clear();
            people.Clear();
            people = db.GetAll();

            foreach (var person in people)
            {
                MemberList_ComboBox.Items.Add(person.FullName);
            }
        }

        private void UpdatePersonInformation(DataAccess dataAccess, int i, int YOB, int YOD, int momId, int dadId)
        {
            people[i].FullName = TextBoxName.Text;
            people[i].YearOfBirth = YOB;
            people[i].PlaceOfBirth = TextBoxPlaceOfBirth.Text;
            people[i].MotherId = momId;
            people[i].FatherId = dadId;
            people[i].YearOfDeath = YOD;
            people[i].PlaceOfDeath = TextBoxPlaceOfDeath.Text;
            people = dataAccess.Update(people[i]);
        }

        private int GetMotherId(int i)
        {
            int momId = default;

            if (TextBoxMother.Text.ToString() != "")
            {
                for (int j = 0; i < people.Count; j++)
                {
                    if (TextBoxMother.Text == people[j].FullName)
                    {
                        return people[j].Id;
                    }
                }
            }

            return momId;
        }

        private int GetFatherId(int i)
        {
            int dadId = default;

            if (TextBoxFather.Text.ToString() != "")
            {
                for (int j = 0; i < people.Count; j++)
                {
                    if (TextBoxFather.Text == people[j].FullName)
                    {
                        return people[j].Id;
                    }
                }
            }

            return dadId;
        }

        private void GetParentNamesForRelatives(List<Person> insertedList)
        {
            for (int i = 0; i < insertedList.Count; i++)
            {
                for (int j = 0; j < people.Count; j++)
                {                    
                    if (people[j].Id == insertedList[i].MotherId)
                    {
                        insertedList[i].MotherName = people[j].FullName;
                    }
                    else if (people[j].Id == insertedList[i].FatherId)
                    {
                        insertedList[i].FatherName = people[j].FullName;
                    }
                }
            }
        }

        public void GetMotherAndFatherNameFromID(List<Person> insertedList)
        {
            for (int i = 0; i < people.Count; i++)
            {
                for (int j = 0; j < insertedList.Count; j++)
                {
                    if (insertedList[j].MotherId == people[i].Id)
                    {
                        insertedList[j].MotherName = people[i].FullName;
                    }
                    else if (insertedList[j].FatherId == people[i].Id)
                    {
                        insertedList[j].FatherName = people[i].FullName;
                    }
                }
            }
        }
    }
}
