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

        public Dashboard()
        {
            InitializeComponent();
            GettFullInfo();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            var db = new DataAccess();
            people = db.GetPeopleByName(SearchText.Text); //SearchText refers to the search bar



            GetMotherAndFatherNameFromID();
            GettFullInfo();
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

        private void InsertButton_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void Dashboard_Load(object sender, EventArgs e) { }
        private void label13_Click(object sender, EventArgs e) { }
        private void label14_Click(object sender, EventArgs e) { }
        private void label12_Click(object sender, EventArgs e) { }
        private void PeopleFoundListBox_SelectedIndexChanged(object sender, EventArgs e) { }
        private void SearchText_TextChanged(object sender, EventArgs e) { }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void DisplayNameLabel_Click(object sender, EventArgs e) { }
        private void ListBoxYOB_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
