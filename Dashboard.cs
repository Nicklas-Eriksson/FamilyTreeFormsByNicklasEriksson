using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FamilyTree
{
    public partial class Dashboard : Form
    {
        #region Field contains Lists
        internal List<Person> people = new List<Person>();
        private List<Person> foundPerson = new List<Person>();
        private List<Person> siblings = new List<Person>();
        private List<Person> parents = new List<Person>();
        private List<Person> kids = new List<Person>();
        #endregion Field

        #region Initialize forms
        /// <summary>
        /// Initializing components for forms window and checks if the database that will be in use exists or not.
        /// If it does not exist it gets created along with stored procedures and tables.
        /// </summary>
        public Dashboard()
        {
            InitializeComponent();
            new MockData().InitializeData();
            UpdateScrollListData(new DataAccess());
        }
        #endregion Initialize forms

        #region Button_Clicks
        /// <summary>
        /// Press the reset button to restore the database with the "mock data".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetDB_Button_Click(object sender, EventArgs e)
        {
            RestoreDatabase();
            UpdateScrollListData(new DataAccess());
        }

        /// <summary>
        /// If the index of the MemberList  combo box changes the TextBoxes will be filled in with the chosen member.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MemberList_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < people.Count; i++)
            {
                if (MemberList_ComboBox.SelectedItem.ToString() == people[i].FullName)
                {
                    GetParentsNames(people[i]);
                    FillTextBoxWith(people[i]);
                    break;
                }
            }
        }

        /// <summary>
        /// Depending on what you chose from the combo box you can Add/Update/Delete a member to or from the SQL server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_Button_Click(object sender, EventArgs e)
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
        #endregion Button_Clicks

        #region Search functions
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
        /// Searches in the SQL-server using LIKE % % to get your search results.
        /// </summary>
        private void NormalSearch()
        {
            if (SearchText.Text != "")
            {
                people = new DataAccess().GetAll();
                FoundSearchedPerson();
                GetParentsNamesFrom(people);
                DisplayInfoToListBoxes(foundPerson);
            }
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

            GetParentsNamesFrom(people);
            DisplayInfoToListBoxes(people);
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
                for (int j = 0; j < foundPerson.Count; j++)
                {
                    if (foundPerson[j].Id == insertedList[i].Id)
                    {
                        insertedList.Remove(insertedList[i]);
                    }
                }
            }
            GetParentsNamesFrom(people);
            GetParentNamesForRelatives(insertedList);
            DisplayInfoToListBoxes(insertedList);
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
                for (int k = 0; k < foundPerson.Count; k++)
                {
                    if (foundPerson[k].Id == people[i].Id)
                    {
                        for (int j = 0; j < people.Count; j++)
                        {
                            if (people[j].MotherId == foundPerson[k].Id)
                            {
                                kids.Add(people[j]);
                            }
                            else if (people[j].FatherId == foundPerson[k].Id)
                            {
                                kids.Add(people[j]);
                            }
                        }
                    }
                }
            }

            GetParentsNamesFrom(people);
            DisplayInfoToListBoxes(kids);
        }

        /// <summary>
        /// Uses the persons motherId and fatherId variable to locate their parents.
        /// </summary>
        private void FindParents()
        {
            parents.Clear();
            people = new DataAccess().GetAll();
            FoundSearchedPerson();
            GetParentsNamesFrom(people);

            for (int i = 0; i < people.Count; i++)
            {
                for (int j = 0; j < foundPerson.Count; j++)
                {
                    if (foundPerson[j].MotherId == people[i].Id)
                    {
                        parents.Add(people[i]);
                    }
                    else if (foundPerson[j].FatherId == people[i].Id)
                    {
                        parents.Add(people[i]);
                    }
                }
            }

            DisplayInfoToListBoxes(parents);
        }

        /// <summary>
        /// First finds searched persons parents > finds parents siblings > finds the aunts and uncles kids > displays them as cousins.
        /// </summary>
        private void FindCousins()
        {
            var DA = new DataAccess();
            var cousinList = new List<Person>();
            var parentsSiblings = new List<Person>();

            ClearLists(cousinList, parentsSiblings);
            FoundSearchedPerson();
            people = DA.GetAll();
            GetParents();
            GetAuntsAndUncles(DA, parentsSiblings);
            GetCousins(cousinList, parentsSiblings);
            GetParentsNamesFrom(cousinList);
            DisplayInfoToListBoxes(cousinList);
        }

        private void RemoveSearchedPersonFromCousinList(List<Person> cousinList)
        {
            for (int i = 0; i < cousinList.Count; i++)
            {
                for (int j = 0; j < foundPerson.Count; j++)
                {
                    try
                    {
                        if (foundPerson[j].Id == cousinList[i].Id)
                        {
                            cousinList.Remove(cousinList[i]);
                        }
                    }
                    catch
                    {
                    }

                }

            }
        }

        private void GetCousins(List<Person> cousinList, List<Person> parentsSiblings)
        {
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

            RemoveSearchedPersonFromCousinList(cousinList);
            RemoveSearchedPersonFromCousinList(cousinList);
        }

        private void GetAuntsAndUncles(DataAccess DA, List<Person> parentsSiblings)
        {
            foreach (var parent in parents)
            {
                parentsSiblings.AddRange(DA.GetRelativesByName(parent.FullName));
            }

            for (int i = 0; i < parents.Count; i++)
            {
                for (int j = 0; j < parentsSiblings.Count; j++)
                {
                    if (parentsSiblings[j].Id == parents[i].Id)
                    {
                        parentsSiblings.Remove(parentsSiblings[j]);
                    }
                }
            }
        }

        private void GetParents()
        {
            for (int i = 0; i < people.Count; i++)
            {
                for (int j = 0; j < foundPerson.Count; j++)
                {
                    if (foundPerson[j].MotherId == people[i].Id)
                    {
                        parents.Add(people[i]);
                    }
                    else if (foundPerson[j].FatherId == people[i].Id)
                    {
                        parents.Add(people[i]);
                    }
                }
            }
        }

        private void ClearLists(List<Person> cousinList, List<Person> parentsSiblings)
        {
            cousinList.Clear();
            parentsSiblings.Clear();
            foundPerson.Clear();
            parents.Clear();
        }

        /// <summary>
        /// Gets information from the person that is being searched for, so that he/she can be compared to others.
        /// </summary>
        private void FoundSearchedPerson()
        {
            var DA = new DataAccess();
            foundPerson.Clear();
            string input = SearchText.Text;
            foundPerson = DA.GetAll(input);
            GetParentsNamesFrom(foundPerson);
        }
        #endregion Search functions

        #region Insert and reset list boxes
        /// <summary>
        /// Populates the list boxes so they can display information.
        /// </summary>
        /// <param name="insertedList">Insert the list that you want to display</param>
        public void DisplayInfoToListBoxes(List<Person> insertedList)
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
        #endregion Insert and reset list boxes

        #region CRUD methods
        /// <summary>
        /// Creates a new person object and populates it with info from the text boxes that are being filled in. Thereafter that person is being inserted into SQL.
        /// </summary>
        /// <param name="dataAccess"></param>
        private void AddNewMember(DataAccess dataAccess)
        {
            if (TextBoxName.Text != "")
            {
                //Name, Year-/Place of birth, Mother-/Father name, Year-/Place of death
                people = dataAccess.AddNewPerson(TextBoxName.Text, TextBoxYearOfBirth.Text, TextBoxPlaceOfBirth.Text, TextBoxMother.Text, TextBoxFather.Text, TextBoxYearOfDeath.Text, TextBoxPlaceOfDeath.Text);

                GetParentsNamesFrom(people);
            }

            UpdateScrollListData(dataAccess);
            CRUDTextBoxClear();
        }

        /// <summary>
        /// Takes the new information provided from the text boxes and updates that person in SQL.
        /// </summary>
        /// <param name="dataAccess"></param>
        private void UpdateMember(DataAccess dataAccess)
        {
            if (MemberList_ComboBox.SelectedItem != null)
            {
                for (int i = 0; i < people.Count; i++)
                {
                    if (MemberList_ComboBox.SelectedItem.ToString() == people[i].FullName)
                    {
                        bool success;
                        success = Int32.TryParse(TextBoxYearOfBirth.Text.Trim(), out int YOB);
                        success = Int32.TryParse(TextBoxYearOfDeath.Text.Trim(), out int YOD);
                        //int momId = GetParentsId(TextBoxMother.Text.ToString(), people);
                        //int dadId = GetParentsId(TextBoxFather.Text.ToString(), people);
                        int momId = GetParentsId(comboBoxMother.Text, people);
                        int dadId = GetParentsId(comboBoxFather.Text, people);
                        UpdatePersonInformation(dataAccess, i, YOB, YOD, momId, dadId);
                        break;
                    }
                }

                CRUDTextBoxClear();
                UpdateScrollListData(dataAccess);
            }
        }

        /// <summary>
        /// After the comboBox changes its index the TextBoxes will be filled with the information from the chosen member.
        /// </summary>
        /// <param name="selectedPerson">Person that will fill up the TextBoxes.</param>
        private void FillTextBoxWith(Person selectedPerson)
        {
            TextBoxName.Text = selectedPerson.FullName;
            TextBoxYearOfBirth.Text = selectedPerson.YearOfBirth.ToString();
            TextBoxPlaceOfBirth.Text = selectedPerson.PlaceOfBirth;            
            comboBoxMother.Text = selectedPerson.MotherName;
            comboBoxFather.Text = selectedPerson.FatherName;
            TextBoxYearOfDeath.Text = selectedPerson.YearOfDeath.ToString();
            TextBoxPlaceOfDeath.Text = selectedPerson.PlaceOfDeath;
        }

        /// <summary>
        /// Clears the TextBoxes after they have been used.
        /// </summary>
        private void CRUDTextBoxClear()
        {
            TextBoxName.Clear();
            TextBoxYearOfBirth.Clear();
            TextBoxPlaceOfBirth.Clear();           
            comboBoxMother.Items.Clear();
            comboBoxFather.Items.Clear();
            TextBoxYearOfDeath.Clear();
            TextBoxPlaceOfDeath.Clear();
        }

        /// <summary>
        /// Removes the person chosen from the scrollable list which displays all the members in the database.
        /// </summary>
        /// <param name="dataAccess"></param>
        private void DeleteMember(DataAccess dataAccess)
        {
            if (MemberList_ComboBox.SelectedItem != null)
            {
                for (int i = 0; i < people.Count; i++)
                {
                    if (MemberList_ComboBox.SelectedItem.ToString() == people[i].FullName)
                    {
                        DataAccess.Delete(people[i]);
                        break;
                    }
                }

                CRUDTextBoxClear();
                UpdateScrollListData(dataAccess);
            }
        }

        /// <summary>
        /// Updates the scrollable list that displays all members in the database if there has been a change.
        /// </summary>
        /// <param name="db"></param>
        private void UpdateScrollListData(DataAccess db)
        {
            MemberList_ComboBox.Items.Clear();
            comboBoxMother.Items.Clear();
            comboBoxFather.Items.Clear();
            people.Clear();
            people = db.GetAll();

            foreach (var person in people)
            {
                MemberList_ComboBox.Items.Add(person.FullName);
                comboBoxMother.Items.Add(person.FullName);
                comboBoxFather.Items.Add(person.FullName);
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
        #endregion CRUD methods

        #region Get id# or name methods
        /// <summary>
        /// Finds the parents ID# and returns it.
        /// </summary>
        /// <param name="i">Parent name as a string + a list to use in for-loop.</param>
        /// <returns>Found mother id#.</returns>
        public int GetParentsId(string _parentName, List<Person> _people)
        {
            int parentId = default;

            if (_parentName != "")
            {
                for (int j = 0; j < _people.Count; j++)
                {
                    if (_parentName == _people[j].FullName)
                    {
                        return _people[j].Id;
                    }
                }
            }

            return parentId;
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
        public void GetParentsNamesFrom(List<Person> insertedList)
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

        /// <summary>
        /// Overloaded from method above
        /// </summary>
        /// <param name="insertedPerson">Person that need names for parents.</param>
        public void GetParentsNames(Person insertedPerson)
        {
            for (int i = 0; i < people.Count; i++)
            {
                if (insertedPerson.MotherId == people[i].Id)
                {
                    insertedPerson.MotherName = people[i].FullName;
                }
                else if (insertedPerson.FatherId == people[i].Id)
                {
                    insertedPerson.FatherName = people[i].FullName;
                }
            }
        }
        #endregion Get id# or name methods

        /// <summary>
        /// When the "Restore Database" button is pressed it resets to the preset mock data.
        /// </summary>
        private void RestoreDatabase()
        {
            var DA = new DataAccess();
            DA.RemakeTable();
            DA.AddMockData();
            DA.AlterMockData();
            people = DA.GetAll();
            UpdateScrollListData(DA);
            ResetListBoxes();
            GetParentsNamesFrom(people);
        }

        private void comboBoxMother_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBoxFather_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}