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

        public Dashboard()
        {
            InitializeComponent();
            GetInfo(people);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            ResetListBoxes();
            TypeOfSearch();
        }
        private void InsertButton_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();
            db.AddNewPerson(TextBoxName.Text, TextBoxYearOfBirth.Text, TextBoxPlaceOfBirth.Text, TextBoxMother.Text, TextBoxFather.Text, TextBoxYearOfDeath.Text, TextBoxPlaceOfDeath.Text);
        }

        private void FoundSearchedPerson()
        {
            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].FullName == SearchText.Text)
                {
                    foundPerson.Add(people[i]);
                    break;
                }
            }
        }

        private void GetMotherAndFatherNameFromID(List<Person> insertedList)
        {
            for (int i = 0; i < insertedList.Count; i++)
            {
                for (int j = 0; j < insertedList.Count; j++)
                {
                    if (insertedList[i].MotherId == insertedList[j].Id)
                    {
                        insertedList[i].MotherName = insertedList[j].FullName;
                    }
                }
                for (int k = 0; k < insertedList.Count; k++)
                {
                    if (insertedList[i].FatherId == insertedList[k].Id)
                    {
                        insertedList[i].FatherName = insertedList[k].FullName;
                    }
                }
            }
        }
        private void GetParentNamesForSiblings(List<Person> insertedList)
        {
            for (int i = 0; i < insertedList.Count; i++) //Search full DB for a match
            {
                for (int j = 0; j < people.Count; j++)
                {
                    //If siblings motherId == peopleId > set that siblings mother name to that iterations name
                    if (people[j].Id == insertedList[i].MotherId) 
                    {
                        insertedList[i].MotherName = people[j].FullName;
                    }
                }
                for (int k = 0; k < people.Count; k++)
                {
                    if (people[k].Id == insertedList[i].FatherId)
                    {
                        insertedList[i].FatherName = people[k].FullName;
                    }
                }
            }
        }

        private void GetInfo(List<Person> insertedList)
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

        private void ResetListBoxes()
        {
            //Only calling Items.Clear() will cause error, needs to set DataSource to null too
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

            //Reset lists
            foundPerson.Clear();
            people.Clear();
        }

        private void TypeOfSearch()
        {            
            if (SearchMenu.SelectedIndex == 0) //Normal Search:
            {
                NormalSearch();
            }
            else if (SearchMenu.SelectedIndex == 1)//Find Siblings:
            {
                FindSiblings();
            }
            else if (SearchMenu.SelectedIndex == 2)//Find Parents:
            {
                FindParents();
            }
            else //Find Kids
            {
                FindKids();
            }
        }
        private void NormalSearch()
        {
            if (SearchMenu.SelectedIndex == 0)
            {
                var db = new DataAccess();
                people = db.GetByName(/*SearchText.Text*/); //SearchText refers to the search bar

                FoundSearchedPerson();
                GetMotherAndFatherNameFromID(people);
                GetInfo(foundPerson);
            }
        }
        private void FindSiblings()
        {
            if (SearchMenu.SelectedIndex == 1)
            {
                people.Clear();//Clears the list if user only preforms multiple find sibling searches

                var db = new DataAccess();
                siblings = db.GetSibblingsByName(SearchText.Text);
                people = db.GetByName(/*SearchText.Text*/); //Populate the list if user only preforms multiple find sibling searches

                FoundSearchedPerson();
                GetMotherAndFatherNameFromID(people);
                GetParentNamesForSiblings(siblings);
                GetInfo(siblings);
            }
        }
        private void FindParents()
        {

        }
        private void FindKids()
        {

        }

        //Cant delete these.. Will throw error
        private void Dashboard_Load(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void AddNewFamilyMemberLabel_Click(object sender, EventArgs e) { }
        private void NameInsLabel_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void FatherInsLabel_Click(object sender, EventArgs e) { }
        private void label12_Click(object sender, EventArgs e) { }
        private void label13_Click(object sender, EventArgs e) { }
        private void label14_Click(object sender, EventArgs e) { }
        private void DisplayNameLabel_Click(object sender, EventArgs e) { }
        private void YearOfBirthInsLabel_Click(object sender, EventArgs e) { }
        private void PeopleFoundListBox_SelectedIndexChanged(object sender, EventArgs e) { }
        private void SearchText_TextChanged(object sender, EventArgs e) { }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void ListBoxYOB_SelectedIndexChanged(object sender, EventArgs e) { }
        private void PlaceOfBirthInsLabel_Click(object sender, EventArgs e) { }
        private void MotherInsLabel_Click(object sender, EventArgs e) { }
        private void YearOfDeathInsLabel_Click(object sender, EventArgs e) { }
        private void PlaceOfDeathInsLabel_Click(object sender, EventArgs e) { }
        private void TextBoxPlaceOfDeath_TextChanged(object sender, EventArgs e) { }
        private void TextBoxYearOfDeath_TextChanged(object sender, EventArgs e) { }
        private void TextBoxFather_TextChanged(object sender, EventArgs e) { }
        private void TextBoxMother_TextChanged(object sender, EventArgs e) { }
        private void TextBoxPlaceOfBith_TextChanged(object sender, EventArgs e) { }
        private void TextBoxYearOfBirth_TextChanged(object sender, EventArgs e) { }
        private void TextBoxName_TextChanged(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }
        private void SearchMenu_SelectedIndexChanged(object sender, EventArgs e) { }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
