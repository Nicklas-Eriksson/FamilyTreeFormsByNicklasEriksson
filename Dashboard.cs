﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FamilyTree
{
    public partial class Dashboard : Form
    {        
        internal List<Person> people = new List<Person>();
        private List<Person> foundPerson = new List<Person>();
        private List<Person> siblings = new List<Person>();
        private List<Person> parents = new List<Person>();
        private List<Person> kids = new List<Person>();
        
        /// <summary>
        /// Initializing components and adds members from SQL-DB to display in the scroll list for Add/Update/delete.
        /// </summary>
        public Dashboard()
        {
            InitializeComponent();
            UpdateScrollListData(new DataAccess());
        }

        /// <summary>
        /// Press the reset button to restore the database with the "mock data".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetDB_Button_Click(object sender, EventArgs e)
        {
            var MD = new MockData();
            people = MD.ResetData(people);
            GetParentNamesForRelatives(people);
        }
                
        /// <summary>
        /// Depending on what you chose from the combo box you can Add/Update/Delete a member to or from the SQL server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            DataAccess dataAccess = new DataAccess();
            var add = Search_ComboBox.SelectedIndex == 0;
            var update = Search_ComboBox.SelectedIndex == 1;
            var delete = Search_ComboBox.SelectedIndex == 2;

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

        /// <summary>
        /// This button takes you to another forms window where you can create some SQL tables for fun.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CodeSandboxButton_Click(object sender, EventArgs e)
        {
            UserControl control = new UserControl();
            control.Dock = DockStyle.Fill;
            this.Controls.Add(control);
            new Dashboard2().Show();
        }

        /// <summary>
        /// The search bars text combined with the combo box will decide what the results will be.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            ResetListBoxes();
            TypeOfSearch();
        }

        /// <summary>
        /// Lets you decide what type of search you want.
        /// </summary>
        public void TypeOfSearch()
        {            
            if (Search_ComboBox.SelectedIndex == 0)
            {
                NormalSearch();
            }
            else if (Search_ComboBox.SelectedIndex == 1)
            {
                FindAll();
            }
            else if (Search_ComboBox.SelectedIndex == 2)
            {
                FindSiblings(siblings);
            }
            else if (Search_ComboBox.SelectedIndex == 3)
            {
                FindKids();
            }
            else if (Search_ComboBox.SelectedIndex == 4)
            {
                FindParents();
            }
            else if (Search_ComboBox.SelectedIndex == 5)
            {
                FindCousins();
            }
        }

        /// <summary>
        /// Searches in the sql server using LIKE % % to get your search results.
        /// </summary>
        private void NormalSearch()
        {
            foundPerson.Clear();
            people = new DataAccess().GetAll();
            FoundSearchedPerson();
           GetMotherAndFatherNameFromID(people);
            DisplayInfoFromList(foundPerson);
        }

        /// <summary>
        /// Displays every person in the database.
        /// </summary>
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

        /// <summary>
        /// Searches the SQL-server for persons with the same parent ID# as the one you searched for.
        /// </summary>
        /// <param name="insertedList"></param>
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

        /// <summary>
        /// Searches the SQL-server for persons with the searched persons ID# as their parent ID#.
        /// </summary>
        private void FindKids()
        {
            kids.Clear();
            var db = new DataAccess();
            people = db.GetAll();
            FoundSearchedPerson();

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

        /// <summary>
        /// Uses the persons motherId and fatherId variable to locate their parents.
        /// </summary>
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

        /// <summary>
        /// First finds searched persons parents > finds parents siblings > finds the aunts and uncles kids > displays them as cousins.
        /// </summary>
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
                if (foundPerson[0].Id == cousinList[i].Id)
                {
                    cousinList.Remove(cousinList[i]);
                }
            }

            GetMotherAndFatherNameFromID(cousinList);
            DisplayInfoFromList(cousinList);
        }

        /// <summary>
        /// Gets information from the person that is being searched for, so that he/she can be compared to others.
        /// </summary>
        private void FoundSearchedPerson()
        {
            var DA = new DataAccess();
            string input = SearchText.Text;
            foundPerson = DA.GetAll(input);
            GetMotherAndFatherNameFromID(foundPerson);
        }

        /// <summary>
        /// Populates the list boxes so they can display information.
        /// </summary>
        /// <param name="insertedList">Insert the list that you want to display</param>
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

        /// <summary>
        /// Clears the list boxes so that they can display other information than before.
        /// </summary>
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

        /// <summary>
        /// Creates a new person object and populates it with info from the textboxes that are bein filled in. Thereafter that person is being inserted into SQL.
        /// </summary>
        /// <param name="dataAccess"></param>
        private void AddNewMember(DataAccess dataAccess)
        {
            //Name, Year-/Place of birth, Mother-/Father name, Year-/Place of death
            dataAccess.AddNewPerson(TextBoxName.Text, TextBoxYearOfBirth.Text, TextBoxPlaceOfBirth.Text, TextBoxMother.Text, TextBoxFather.Text, TextBoxYearOfDeath.Text, TextBoxPlaceOfDeath.Text);

            people = dataAccess.GetAll();
            FindParents();
        }

        /// <summary>
        /// Takes the new information provided from the text boxes and updates that person in SQL.
        /// </summary>
        /// <param name="dataAccess"></param>
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

        /// <summary>
        /// Removes the person chosen from the scrollable list which displays all the members in the database.
        /// </summary>
        /// <param name="dataAccess"></param>
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

        /// <summary>
        /// Updates the scrollable list that displays all members in the database if there has been a change.
        /// </summary>
        /// <param name="db"></param>
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

        /// <summary>
        /// Updates the persons information that will be update in SQL
        /// </summary>
        /// <param name="dataAccess"></param>
        /// <param name="i">for-loop index.</param>
        /// <param name="YOB">Year of birth.</param>
        /// <param name="YOD">Year of death.</param>
        /// <param name="momId">Mothers id#.</param>
        /// <param name="dadId">Fathers id#.</param>
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

        /// <summary>
        /// Finds the mother and returns their id#.
        /// </summary>
        /// <param name="i">for-loop index.</param>
        /// <returns>Found mother id#.</returns>
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

        /// <summary>
        /// Finds the father and returns their id#.
        /// </summary>
        /// <param name="i">for-loop index.</param>
        /// <returns>Found father id#.</returns>
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

        /// <summary>
        /// Gets the 
        /// </summary>
        /// <param name="insertedList"></param>
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

        /// <summary>
        /// Gets mothers and fathers name using their id# to the persons in the inserted list.
        /// </summary>
        /// <param name="insertedList">List for persons that need name for their parents.</param>
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
