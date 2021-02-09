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
        private List<Person> people = new List<Person>();
        private List<Person> foundPerson = new List<Person>();

        public Dashboard()
        {
            InitializeComponent();
            GettFullInfo();
        }
        
        private void SearchButton_Click(object sender, EventArgs e)
        {
            ResetListBoxes();

            var db = new DataAccess();
            people = db.GetPeopleByName(SearchText.Text); //SearchText refers to the search bar

            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].fullName == SearchText.Text)
                {
                    foundPerson.Add(people[i]);
                    break;
                }
            }

            GetMotherAndFatherNameFromID();
            GettFoundPersonInfo();
        }

        private void GetMotherAndFatherNameFromID()
        {
            for (int i = 0; i < people.Count; i++)
            {
                for (int j = 0; j < people.Count; j++)
                {
                    if (people[i].motherId == people[j].Id)
                    {
                        people[i].motherName = people[j].fullName;
                    }
                }
                for (int k = 0; k < people.Count; k++)
                {
                    if (people[i].fatherId == people[k].Id)
                    {
                        people[i].fatherName = people[k].fullName;
                    }
                }
            }
        }

        private void GettFoundPersonInfo()
        {
            ListBoxName.DataSource = foundPerson;
            ListBoxName.DisplayMember = "GetFullName";

            ListBoxYOB.DataSource = foundPerson;
            ListBoxYOB.DisplayMember = "GetYearOfBirth";

            ListBoxPOB.DataSource = foundPerson;
            ListBoxPOB.DisplayMember = "GetPlaceOfBirth";

            ListBoxMother.DataSource = foundPerson;
            ListBoxMother.DisplayMember = "GetMotherName";

            ListBoxFather.DataSource = foundPerson;
            ListBoxFather.DisplayMember = "GetFatherName";

            ListBoxYOD.DataSource = foundPerson;
            ListBoxYOD.DisplayMember = "GetYearOfDeath";

            ListBoxPOD.DataSource = foundPerson;
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

        private void GettFullInfo()
        {
            ListBoxName.DataSource = people;
            ListBoxName.DisplayMember = "GetFullName";

            ListBoxYOB.DataSource = people;
            ListBoxYOB.DisplayMember = "GetYearOfBirth";

            ListBoxPOB.DataSource = people;
            ListBoxPOB.DisplayMember = "GetPlaceOfBirth";

            ListBoxMother.DataSource = people;
            ListBoxMother.DisplayMember = "GetMotherName";

            ListBoxFather.DataSource = people;
            ListBoxFather.DisplayMember = "GetFatherName";

            ListBoxYOD.DataSource = people;
            ListBoxYOD.DisplayMember = "GetYearOfDeath";

            ListBoxPOD.DataSource = people;
            ListBoxPOD.DisplayMember = "GetPlaceOfDeath";
        }

        private void InsertButton_Click(object sender, EventArgs e) 
        {
            
        }

        //Cant delete these.. Will throw error
        private void Dashboard_Load(object sender, EventArgs e){}
        private void pictureBox1_Click(object sender, EventArgs e){}
        private void label1_Click(object sender, EventArgs e){}
        private void label2_Click(object sender, EventArgs e){}
        private void AddNewFamilyMemberLabel_Click(object sender, EventArgs e){}
        private void NameInsLabel_Click(object sender, EventArgs e){}
        private void label7_Click(object sender, EventArgs e){}
        private void label8_Click(object sender, EventArgs e){}
        private void FatherInsLabel_Click(object sender, EventArgs e){}
        private void label12_Click(object sender, EventArgs e){}
        private void label13_Click(object sender, EventArgs e){}
        private void label14_Click(object sender, EventArgs e){}
        private void DisplayNameLabel_Click(object sender, EventArgs e){}
        private void YearOfBirthInsLabel_Click(object sender, EventArgs e){}
        private void PeopleFoundListBox_SelectedIndexChanged(object sender, EventArgs e){}
        private void SearchText_TextChanged(object sender, EventArgs e){}
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e){}
        private void ListBoxYOB_SelectedIndexChanged(object sender, EventArgs e){}
        private void PlaceOfBirthInsLabel_Click(object sender, EventArgs e){}
        private void MotherInsLabel_Click(object sender, EventArgs e){}
        private void YearOfDeathInsLabel_Click(object sender, EventArgs e){}
        private void PlaceOfDeathInsLabel_Click(object sender, EventArgs e){}
        private void TextBoxPlaceOfDeath_TextChanged(object sender, EventArgs e){}
        private void TextBoxYearOfDeath_TextChanged(object sender, EventArgs e){}
        private void TextBoxFather_TextChanged(object sender, EventArgs e){}
        private void TextBoxMother_TextChanged(object sender, EventArgs e){}
        private void TextBoxPlaceOfBith_TextChanged(object sender, EventArgs e){}
        private void TextBoxYearOfBirth_TextChanged(object sender, EventArgs e){}
        private void TextBoxName_TextChanged(object sender, EventArgs e){}
    }
}
