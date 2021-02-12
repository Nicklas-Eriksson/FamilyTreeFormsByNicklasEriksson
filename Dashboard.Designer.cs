
namespace FamilyTree
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.ListBoxName = new System.Windows.Forms.ListBox();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.DisplayNameLabel = new System.Windows.Forms.Label();
            this.NameInsLabel = new System.Windows.Forms.Label();
            this.YearOfBirthInsLabel = new System.Windows.Forms.Label();
            this.PlaceOfBirthInsLabel = new System.Windows.Forms.Label();
            this.MotherInsLabel = new System.Windows.Forms.Label();
            this.FatherInsLabel = new System.Windows.Forms.Label();
            this.YearOfDeathInsLabel = new System.Windows.Forms.Label();
            this.PlaceOfDeathInsLabel = new System.Windows.Forms.Label();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.TextBoxYearOfBirth = new System.Windows.Forms.TextBox();
            this.TextBoxPlaceOfBirth = new System.Windows.Forms.TextBox();
            this.TextBoxYearOfDeath = new System.Windows.Forms.TextBox();
            this.TextBoxFather = new System.Windows.Forms.TextBox();
            this.TextBoxMother = new System.Windows.Forms.TextBox();
            this.TextBoxPlaceOfDeath = new System.Windows.Forms.TextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.TreePNGBox = new System.Windows.Forms.PictureBox();
            this.FamilyTreeLogoLabel = new System.Windows.Forms.Label();
            this.DisplayYearOfBirthLabel = new System.Windows.Forms.Label();
            this.DisplayMotherLabel = new System.Windows.Forms.Label();
            this.DisplayPlaceOfDeathLabel = new System.Windows.Forms.Label();
            this.DisplayFatherLabel = new System.Windows.Forms.Label();
            this.DisplayYearOfDeathLabel = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.DisplayPlaceOfBirthLabel = new System.Windows.Forms.Label();
            this.ListBoxYOB = new System.Windows.Forms.ListBox();
            this.ListBoxPOB = new System.Windows.Forms.ListBox();
            this.ListBoxYOD = new System.Windows.Forms.ListBox();
            this.ListBoxFather = new System.Windows.Forms.ListBox();
            this.ListBoxMother = new System.Windows.Forms.ListBox();
            this.ListBoxPOD = new System.Windows.Forms.ListBox();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.NewDB_Button = new System.Windows.Forms.Button();
            this.SearchMenu = new System.Windows.Forms.ComboBox();
            this.AddUpdateDelete_ComboBox = new System.Windows.Forms.ComboBox();
            this.MemberList_ComboBox = new System.Windows.Forms.ComboBox();
            this.AddUpdateDelete_Text = new System.Windows.Forms.Label();
            this.ResetDB_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TreePNGBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ListBoxName
            // 
            this.ListBoxName.Font = new System.Drawing.Font("MS Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxName.FormattingEnabled = true;
            this.ListBoxName.ItemHeight = 19;
            this.ListBoxName.Location = new System.Drawing.Point(9, 137);
            this.ListBoxName.Name = "ListBoxName";
            this.ListBoxName.Size = new System.Drawing.Size(253, 251);
            this.ListBoxName.TabIndex = 3;
            this.ListBoxName.SelectedIndexChanged += new System.EventHandler(this.PeopleFoundListBox_SelectedIndexChanged);
            // 
            // SearchText
            // 
            this.SearchText.Location = new System.Drawing.Point(12, 47);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(249, 29);
            this.SearchText.TabIndex = 4;
            this.SearchText.TextChanged += new System.EventHandler(this.SearchText_TextChanged);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(267, 48);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(92, 29);
            this.SearchButton.TabIndex = 5;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // DisplayNameLabel
            // 
            this.DisplayNameLabel.AutoSize = true;
            this.DisplayNameLabel.ForeColor = System.Drawing.Color.Fuchsia;
            this.DisplayNameLabel.Location = new System.Drawing.Point(106, 110);
            this.DisplayNameLabel.Name = "DisplayNameLabel";
            this.DisplayNameLabel.Size = new System.Drawing.Size(61, 24);
            this.DisplayNameLabel.TabIndex = 7;
            this.DisplayNameLabel.Text = "Name";
            this.DisplayNameLabel.Click += new System.EventHandler(this.DisplayNameLabel_Click);
            // 
            // NameInsLabel
            // 
            this.NameInsLabel.AutoSize = true;
            this.NameInsLabel.ForeColor = System.Drawing.Color.Fuchsia;
            this.NameInsLabel.Location = new System.Drawing.Point(15, 496);
            this.NameInsLabel.Name = "NameInsLabel";
            this.NameInsLabel.Size = new System.Drawing.Size(61, 24);
            this.NameInsLabel.TabIndex = 9;
            this.NameInsLabel.Text = "Name";
            this.NameInsLabel.Click += new System.EventHandler(this.NameInsLabel_Click);
            // 
            // YearOfBirthInsLabel
            // 
            this.YearOfBirthInsLabel.AutoSize = true;
            this.YearOfBirthInsLabel.ForeColor = System.Drawing.Color.Fuchsia;
            this.YearOfBirthInsLabel.Location = new System.Drawing.Point(15, 531);
            this.YearOfBirthInsLabel.Name = "YearOfBirthInsLabel";
            this.YearOfBirthInsLabel.Size = new System.Drawing.Size(110, 24);
            this.YearOfBirthInsLabel.TabIndex = 10;
            this.YearOfBirthInsLabel.Text = "Year of birth";
            this.YearOfBirthInsLabel.Click += new System.EventHandler(this.YearOfBirthInsLabel_Click);
            // 
            // PlaceOfBirthInsLabel
            // 
            this.PlaceOfBirthInsLabel.AutoSize = true;
            this.PlaceOfBirthInsLabel.ForeColor = System.Drawing.Color.Fuchsia;
            this.PlaceOfBirthInsLabel.Location = new System.Drawing.Point(15, 566);
            this.PlaceOfBirthInsLabel.Name = "PlaceOfBirthInsLabel";
            this.PlaceOfBirthInsLabel.Size = new System.Drawing.Size(118, 24);
            this.PlaceOfBirthInsLabel.TabIndex = 11;
            this.PlaceOfBirthInsLabel.Text = "Place of birth";
            this.PlaceOfBirthInsLabel.Click += new System.EventHandler(this.PlaceOfBirthInsLabel_Click);
            // 
            // MotherInsLabel
            // 
            this.MotherInsLabel.AutoSize = true;
            this.MotherInsLabel.ForeColor = System.Drawing.Color.Fuchsia;
            this.MotherInsLabel.Location = new System.Drawing.Point(15, 600);
            this.MotherInsLabel.Name = "MotherInsLabel";
            this.MotherInsLabel.Size = new System.Drawing.Size(69, 24);
            this.MotherInsLabel.TabIndex = 12;
            this.MotherInsLabel.Text = "Mother";
            this.MotherInsLabel.Click += new System.EventHandler(this.MotherInsLabel_Click);
            // 
            // FatherInsLabel
            // 
            this.FatherInsLabel.AutoSize = true;
            this.FatherInsLabel.ForeColor = System.Drawing.Color.Fuchsia;
            this.FatherInsLabel.Location = new System.Drawing.Point(15, 635);
            this.FatherInsLabel.Name = "FatherInsLabel";
            this.FatherInsLabel.Size = new System.Drawing.Size(64, 24);
            this.FatherInsLabel.TabIndex = 13;
            this.FatherInsLabel.Text = "Father";
            this.FatherInsLabel.Click += new System.EventHandler(this.FatherInsLabel_Click);
            // 
            // YearOfDeathInsLabel
            // 
            this.YearOfDeathInsLabel.AutoSize = true;
            this.YearOfDeathInsLabel.ForeColor = System.Drawing.Color.Fuchsia;
            this.YearOfDeathInsLabel.Location = new System.Drawing.Point(14, 670);
            this.YearOfDeathInsLabel.Name = "YearOfDeathInsLabel";
            this.YearOfDeathInsLabel.Size = new System.Drawing.Size(121, 24);
            this.YearOfDeathInsLabel.TabIndex = 14;
            this.YearOfDeathInsLabel.Text = "Year of death";
            this.YearOfDeathInsLabel.Click += new System.EventHandler(this.YearOfDeathInsLabel_Click);
            // 
            // PlaceOfDeathInsLabel
            // 
            this.PlaceOfDeathInsLabel.AutoSize = true;
            this.PlaceOfDeathInsLabel.ForeColor = System.Drawing.Color.Fuchsia;
            this.PlaceOfDeathInsLabel.Location = new System.Drawing.Point(15, 705);
            this.PlaceOfDeathInsLabel.Name = "PlaceOfDeathInsLabel";
            this.PlaceOfDeathInsLabel.Size = new System.Drawing.Size(129, 24);
            this.PlaceOfDeathInsLabel.TabIndex = 15;
            this.PlaceOfDeathInsLabel.Text = "Place of death";
            this.PlaceOfDeathInsLabel.Click += new System.EventHandler(this.PlaceOfDeathInsLabel_Click);
            // 
            // TextBoxName
            // 
            this.TextBoxName.Location = new System.Drawing.Point(156, 493);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.Size = new System.Drawing.Size(249, 29);
            this.TextBoxName.TabIndex = 16;
            this.TextBoxName.TextChanged += new System.EventHandler(this.TextBoxName_TextChanged);
            // 
            // TextBoxYearOfBirth
            // 
            this.TextBoxYearOfBirth.Location = new System.Drawing.Point(156, 528);
            this.TextBoxYearOfBirth.Name = "TextBoxYearOfBirth";
            this.TextBoxYearOfBirth.Size = new System.Drawing.Size(249, 29);
            this.TextBoxYearOfBirth.TabIndex = 17;
            this.TextBoxYearOfBirth.TextChanged += new System.EventHandler(this.TextBoxYearOfBirth_TextChanged);
            // 
            // TextBoxPlaceOfBirth
            // 
            this.TextBoxPlaceOfBirth.Location = new System.Drawing.Point(156, 563);
            this.TextBoxPlaceOfBirth.Name = "TextBoxPlaceOfBirth";
            this.TextBoxPlaceOfBirth.Size = new System.Drawing.Size(249, 29);
            this.TextBoxPlaceOfBirth.TabIndex = 18;
            this.TextBoxPlaceOfBirth.TextChanged += new System.EventHandler(this.TextBoxPlaceOfBith_TextChanged);
            // 
            // TextBoxYearOfDeath
            // 
            this.TextBoxYearOfDeath.Location = new System.Drawing.Point(156, 667);
            this.TextBoxYearOfDeath.Name = "TextBoxYearOfDeath";
            this.TextBoxYearOfDeath.Size = new System.Drawing.Size(249, 29);
            this.TextBoxYearOfDeath.TabIndex = 21;
            this.TextBoxYearOfDeath.TextChanged += new System.EventHandler(this.TextBoxYearOfDeath_TextChanged);
            // 
            // TextBoxFather
            // 
            this.TextBoxFather.Location = new System.Drawing.Point(156, 632);
            this.TextBoxFather.Name = "TextBoxFather";
            this.TextBoxFather.Size = new System.Drawing.Size(249, 29);
            this.TextBoxFather.TabIndex = 20;
            this.TextBoxFather.TextChanged += new System.EventHandler(this.TextBoxFather_TextChanged);
            // 
            // TextBoxMother
            // 
            this.TextBoxMother.Location = new System.Drawing.Point(156, 597);
            this.TextBoxMother.Name = "TextBoxMother";
            this.TextBoxMother.Size = new System.Drawing.Size(249, 29);
            this.TextBoxMother.TabIndex = 19;
            this.TextBoxMother.TextChanged += new System.EventHandler(this.TextBoxMother_TextChanged);
            // 
            // TextBoxPlaceOfDeath
            // 
            this.TextBoxPlaceOfDeath.Location = new System.Drawing.Point(156, 702);
            this.TextBoxPlaceOfDeath.Name = "TextBoxPlaceOfDeath";
            this.TextBoxPlaceOfDeath.Size = new System.Drawing.Size(249, 29);
            this.TextBoxPlaceOfDeath.TabIndex = 22;
            this.TextBoxPlaceOfDeath.TextChanged += new System.EventHandler(this.TextBoxPlaceOfDeath_TextChanged);
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(411, 703);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(72, 29);
            this.OkButton.TabIndex = 23;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.InsertButton_Click);
            // 
            // TreePNGBox
            // 
            this.TreePNGBox.Image = ((System.Drawing.Image)(resources.GetObject("TreePNGBox.Image")));
            this.TreePNGBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("TreePNGBox.InitialImage")));
            this.TreePNGBox.Location = new System.Drawing.Point(845, 411);
            this.TreePNGBox.Name = "TreePNGBox";
            this.TreePNGBox.Size = new System.Drawing.Size(338, 320);
            this.TreePNGBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TreePNGBox.TabIndex = 26;
            this.TreePNGBox.TabStop = false;
            // 
            // FamilyTreeLogoLabel
            // 
            this.FamilyTreeLogoLabel.AutoSize = true;
            this.FamilyTreeLogoLabel.Font = new System.Drawing.Font("NSimSun", 69F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FamilyTreeLogoLabel.ForeColor = System.Drawing.Color.Crimson;
            this.FamilyTreeLogoLabel.Location = new System.Drawing.Point(641, 9);
            this.FamilyTreeLogoLabel.Name = "FamilyTreeLogoLabel";
            this.FamilyTreeLogoLabel.Size = new System.Drawing.Size(556, 92);
            this.FamilyTreeLogoLabel.TabIndex = 27;
            this.FamilyTreeLogoLabel.Text = "Family Tree";
            this.FamilyTreeLogoLabel.Click += new System.EventHandler(this.label12_Click);
            // 
            // DisplayYearOfBirthLabel
            // 
            this.DisplayYearOfBirthLabel.AutoSize = true;
            this.DisplayYearOfBirthLabel.ForeColor = System.Drawing.Color.Fuchsia;
            this.DisplayYearOfBirthLabel.Location = new System.Drawing.Point(267, 110);
            this.DisplayYearOfBirthLabel.Name = "DisplayYearOfBirthLabel";
            this.DisplayYearOfBirthLabel.Size = new System.Drawing.Size(91, 24);
            this.DisplayYearOfBirthLabel.TabIndex = 28;
            this.DisplayYearOfBirthLabel.Text = "Birth Year";
            this.DisplayYearOfBirthLabel.Click += new System.EventHandler(this.label13_Click);
            // 
            // DisplayMotherLabel
            // 
            this.DisplayMotherLabel.AutoSize = true;
            this.DisplayMotherLabel.ForeColor = System.Drawing.Color.Fuchsia;
            this.DisplayMotherLabel.Location = new System.Drawing.Point(571, 110);
            this.DisplayMotherLabel.Name = "DisplayMotherLabel";
            this.DisplayMotherLabel.Size = new System.Drawing.Size(69, 24);
            this.DisplayMotherLabel.TabIndex = 29;
            this.DisplayMotherLabel.Text = "Mother";
            this.DisplayMotherLabel.Click += new System.EventHandler(this.label14_Click);
            // 
            // DisplayPlaceOfDeathLabel
            // 
            this.DisplayPlaceOfDeathLabel.AutoSize = true;
            this.DisplayPlaceOfDeathLabel.ForeColor = System.Drawing.Color.Fuchsia;
            this.DisplayPlaceOfDeathLabel.Location = new System.Drawing.Point(1086, 110);
            this.DisplayPlaceOfDeathLabel.Name = "DisplayPlaceOfDeathLabel";
            this.DisplayPlaceOfDeathLabel.Size = new System.Drawing.Size(112, 24);
            this.DisplayPlaceOfDeathLabel.TabIndex = 30;
            this.DisplayPlaceOfDeathLabel.Text = "Death Town";
            // 
            // DisplayFatherLabel
            // 
            this.DisplayFatherLabel.AutoSize = true;
            this.DisplayFatherLabel.ForeColor = System.Drawing.Color.Fuchsia;
            this.DisplayFatherLabel.Location = new System.Drawing.Point(841, 110);
            this.DisplayFatherLabel.Name = "DisplayFatherLabel";
            this.DisplayFatherLabel.Size = new System.Drawing.Size(64, 24);
            this.DisplayFatherLabel.TabIndex = 31;
            this.DisplayFatherLabel.Text = "Father";
            // 
            // DisplayYearOfDeathLabel
            // 
            this.DisplayYearOfDeathLabel.AutoSize = true;
            this.DisplayYearOfDeathLabel.ForeColor = System.Drawing.Color.Fuchsia;
            this.DisplayYearOfDeathLabel.Location = new System.Drawing.Point(984, 110);
            this.DisplayYearOfDeathLabel.Name = "DisplayYearOfDeathLabel";
            this.DisplayYearOfDeathLabel.Size = new System.Drawing.Size(102, 24);
            this.DisplayYearOfDeathLabel.TabIndex = 32;
            this.DisplayYearOfDeathLabel.Text = "Death Date";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(808, 104);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(0, 24);
            this.label18.TabIndex = 33;
            // 
            // DisplayPlaceOfBirthLabel
            // 
            this.DisplayPlaceOfBirthLabel.AutoSize = true;
            this.DisplayPlaceOfBirthLabel.ForeColor = System.Drawing.Color.Fuchsia;
            this.DisplayPlaceOfBirthLabel.Location = new System.Drawing.Point(370, 110);
            this.DisplayPlaceOfBirthLabel.Name = "DisplayPlaceOfBirthLabel";
            this.DisplayPlaceOfBirthLabel.Size = new System.Drawing.Size(99, 24);
            this.DisplayPlaceOfBirthLabel.TabIndex = 34;
            this.DisplayPlaceOfBirthLabel.Text = "Birth Place";
            // 
            // ListBoxYOB
            // 
            this.ListBoxYOB.Font = new System.Drawing.Font("MS Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxYOB.FormattingEnabled = true;
            this.ListBoxYOB.ItemHeight = 19;
            this.ListBoxYOB.Location = new System.Drawing.Point(268, 137);
            this.ListBoxYOB.Name = "ListBoxYOB";
            this.ListBoxYOB.Size = new System.Drawing.Size(90, 251);
            this.ListBoxYOB.TabIndex = 35;
            this.ListBoxYOB.SelectedIndexChanged += new System.EventHandler(this.ListBoxYOB_SelectedIndexChanged);
            // 
            // ListBoxPOB
            // 
            this.ListBoxPOB.Font = new System.Drawing.Font("MS Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxPOB.FormattingEnabled = true;
            this.ListBoxPOB.ItemHeight = 19;
            this.ListBoxPOB.Location = new System.Drawing.Point(364, 137);
            this.ListBoxPOB.Name = "ListBoxPOB";
            this.ListBoxPOB.Size = new System.Drawing.Size(105, 251);
            this.ListBoxPOB.TabIndex = 36;
            this.ListBoxPOB.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // ListBoxYOD
            // 
            this.ListBoxYOD.Font = new System.Drawing.Font("MS Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxYOD.FormattingEnabled = true;
            this.ListBoxYOD.ItemHeight = 19;
            this.ListBoxYOD.Location = new System.Drawing.Point(994, 137);
            this.ListBoxYOD.Name = "ListBoxYOD";
            this.ListBoxYOD.Size = new System.Drawing.Size(90, 251);
            this.ListBoxYOD.TabIndex = 39;
            // 
            // ListBoxFather
            // 
            this.ListBoxFather.Font = new System.Drawing.Font("MS Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxFather.FormattingEnabled = true;
            this.ListBoxFather.ItemHeight = 19;
            this.ListBoxFather.Location = new System.Drawing.Point(735, 137);
            this.ListBoxFather.Name = "ListBoxFather";
            this.ListBoxFather.Size = new System.Drawing.Size(253, 251);
            this.ListBoxFather.TabIndex = 38;
            // 
            // ListBoxMother
            // 
            this.ListBoxMother.Font = new System.Drawing.Font("MS Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxMother.FormattingEnabled = true;
            this.ListBoxMother.ItemHeight = 19;
            this.ListBoxMother.Location = new System.Drawing.Point(475, 137);
            this.ListBoxMother.Name = "ListBoxMother";
            this.ListBoxMother.Size = new System.Drawing.Size(253, 251);
            this.ListBoxMother.TabIndex = 37;
            // 
            // ListBoxPOD
            // 
            this.ListBoxPOD.Font = new System.Drawing.Font("MS Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxPOD.FormattingEnabled = true;
            this.ListBoxPOD.ItemHeight = 19;
            this.ListBoxPOD.Location = new System.Drawing.Point(1090, 137);
            this.ListBoxPOD.Name = "ListBoxPOD";
            this.ListBoxPOD.Size = new System.Drawing.Size(105, 251);
            this.ListBoxPOD.TabIndex = 40;
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Font = new System.Drawing.Font("NSimSun", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchLabel.ForeColor = System.Drawing.Color.Crimson;
            this.SearchLabel.Location = new System.Drawing.Point(9, 19);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(82, 21);
            this.SearchLabel.TabIndex = 1;
            this.SearchLabel.Text = "Search";
            this.SearchLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(606, 569);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 41;
            // 
            // NewDB_Button
            // 
            this.NewDB_Button.Location = new System.Drawing.Point(440, 13);
            this.NewDB_Button.Name = "NewDB_Button";
            this.NewDB_Button.Size = new System.Drawing.Size(167, 28);
            this.NewDB_Button.TabIndex = 42;
            this.NewDB_Button.Text = "New Database";
            this.NewDB_Button.UseVisualStyleBackColor = true;
            this.NewDB_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // SearchMenu
            // 
            this.SearchMenu.BackColor = System.Drawing.Color.White;
            this.SearchMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchMenu.FormattingEnabled = true;
            this.SearchMenu.Items.AddRange(new object[] {
            "Normal Search:",
            "Find All:",
            "Find Siblings:",
            "Find Kids:",
            "Find Parents"});
            this.SearchMenu.Location = new System.Drawing.Point(167, 9);
            this.SearchMenu.Name = "SearchMenu";
            this.SearchMenu.Size = new System.Drawing.Size(192, 32);
            this.SearchMenu.TabIndex = 44;
            this.SearchMenu.SelectedIndexChanged += new System.EventHandler(this.SearchMenu_SelectedIndexChanged);
            // 
            // AddUpdateDelete_ComboBox
            // 
            this.AddUpdateDelete_ComboBox.BackColor = System.Drawing.Color.White;
            this.AddUpdateDelete_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AddUpdateDelete_ComboBox.FormattingEnabled = true;
            this.AddUpdateDelete_ComboBox.Items.AddRange(new object[] {
            "Add:",
            "Update:",
            "Delete:"});
            this.AddUpdateDelete_ComboBox.Location = new System.Drawing.Point(334, 417);
            this.AddUpdateDelete_ComboBox.Name = "AddUpdateDelete_ComboBox";
            this.AddUpdateDelete_ComboBox.Size = new System.Drawing.Size(106, 32);
            this.AddUpdateDelete_ComboBox.TabIndex = 45;
            // 
            // MemberList_ComboBox
            // 
            this.MemberList_ComboBox.BackColor = System.Drawing.Color.White;
            this.MemberList_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MemberList_ComboBox.FormattingEnabled = true;
            this.MemberList_ComboBox.Location = new System.Drawing.Point(334, 455);
            this.MemberList_ComboBox.Name = "MemberList_ComboBox";
            this.MemberList_ComboBox.Size = new System.Drawing.Size(249, 32);
            this.MemberList_ComboBox.TabIndex = 46;
            this.MemberList_ComboBox.SelectedIndexChanged += new System.EventHandler(this.MemberList_ComboBox_SelectedIndexChanged);
            // 
            // AddUpdateDelete_Text
            // 
            this.AddUpdateDelete_Text.AutoSize = true;
            this.AddUpdateDelete_Text.Font = new System.Drawing.Font("SimSun", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddUpdateDelete_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.AddUpdateDelete_Text.Location = new System.Drawing.Point(7, 434);
            this.AddUpdateDelete_Text.Name = "AddUpdateDelete_Text";
            this.AddUpdateDelete_Text.Size = new System.Drawing.Size(317, 29);
            this.AddUpdateDelete_Text.TabIndex = 47;
            this.AddUpdateDelete_Text.Text = "Add-/Update-/Delete";
            this.AddUpdateDelete_Text.Click += new System.EventHandler(this.AddUpdateDelete_Text_Click);
            // 
            // ResetDB_Button
            // 
            this.ResetDB_Button.Location = new System.Drawing.Point(440, 47);
            this.ResetDB_Button.Name = "ResetDB_Button";
            this.ResetDB_Button.Size = new System.Drawing.Size(167, 28);
            this.ResetDB_Button.TabIndex = 48;
            this.ResetDB_Button.Text = "Restore Database";
            this.ResetDB_Button.UseVisualStyleBackColor = true;
            this.ResetDB_Button.Click += new System.EventHandler(this.ResetDB_Button_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1209, 753);
            this.Controls.Add(this.ResetDB_Button);
            this.Controls.Add(this.AddUpdateDelete_Text);
            this.Controls.Add(this.MemberList_ComboBox);
            this.Controls.Add(this.AddUpdateDelete_ComboBox);
            this.Controls.Add(this.SearchMenu);
            this.Controls.Add(this.NewDB_Button);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.ListBoxPOD);
            this.Controls.Add(this.ListBoxYOD);
            this.Controls.Add(this.ListBoxFather);
            this.Controls.Add(this.ListBoxMother);
            this.Controls.Add(this.ListBoxPOB);
            this.Controls.Add(this.ListBoxYOB);
            this.Controls.Add(this.DisplayPlaceOfBirthLabel);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.DisplayYearOfDeathLabel);
            this.Controls.Add(this.DisplayFatherLabel);
            this.Controls.Add(this.DisplayPlaceOfDeathLabel);
            this.Controls.Add(this.DisplayMotherLabel);
            this.Controls.Add(this.DisplayYearOfBirthLabel);
            this.Controls.Add(this.FamilyTreeLogoLabel);
            this.Controls.Add(this.TreePNGBox);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.TextBoxPlaceOfDeath);
            this.Controls.Add(this.TextBoxYearOfDeath);
            this.Controls.Add(this.TextBoxFather);
            this.Controls.Add(this.TextBoxMother);
            this.Controls.Add(this.TextBoxPlaceOfBirth);
            this.Controls.Add(this.TextBoxYearOfBirth);
            this.Controls.Add(this.TextBoxName);
            this.Controls.Add(this.PlaceOfDeathInsLabel);
            this.Controls.Add(this.YearOfDeathInsLabel);
            this.Controls.Add(this.FatherInsLabel);
            this.Controls.Add(this.MotherInsLabel);
            this.Controls.Add(this.PlaceOfBirthInsLabel);
            this.Controls.Add(this.YearOfBirthInsLabel);
            this.Controls.Add(this.NameInsLabel);
            this.Controls.Add(this.DisplayNameLabel);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SearchText);
            this.Controls.Add(this.ListBoxName);
            this.Controls.Add(this.SearchLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Dashboard";
            this.Text = "Family Tree";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TreePNGBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox ListBoxName;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Label DisplayNameLabel;
        private System.Windows.Forms.Label NameInsLabel;
        private System.Windows.Forms.Label YearOfBirthInsLabel;
        private System.Windows.Forms.Label PlaceOfBirthInsLabel;
        private System.Windows.Forms.Label MotherInsLabel;
        private System.Windows.Forms.Label FatherInsLabel;
        private System.Windows.Forms.Label YearOfDeathInsLabel;
        private System.Windows.Forms.Label PlaceOfDeathInsLabel;
        private System.Windows.Forms.TextBox TextBoxName;
        private System.Windows.Forms.TextBox TextBoxYearOfBirth;
        private System.Windows.Forms.TextBox TextBoxPlaceOfBirth;
        private System.Windows.Forms.TextBox TextBoxYearOfDeath;
        private System.Windows.Forms.TextBox TextBoxFather;
        private System.Windows.Forms.TextBox TextBoxMother;
        private System.Windows.Forms.TextBox TextBoxPlaceOfDeath;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.PictureBox TreePNGBox;
        private System.Windows.Forms.Label FamilyTreeLogoLabel;
        private System.Windows.Forms.Label DisplayYearOfBirthLabel;
        private System.Windows.Forms.Label DisplayMotherLabel;
        private System.Windows.Forms.Label DisplayPlaceOfDeathLabel;
        private System.Windows.Forms.Label DisplayFatherLabel;
        private System.Windows.Forms.Label DisplayYearOfDeathLabel;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label DisplayPlaceOfBirthLabel;
        private System.Windows.Forms.ListBox ListBoxYOB;
        private System.Windows.Forms.ListBox ListBoxPOB;
        private System.Windows.Forms.ListBox ListBoxYOD;
        private System.Windows.Forms.ListBox ListBoxFather;
        private System.Windows.Forms.ListBox ListBoxMother;
        private System.Windows.Forms.ListBox ListBoxPOD;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button NewDB_Button;
        private System.Windows.Forms.ComboBox SearchMenu;
        private System.Windows.Forms.ComboBox AddUpdateDelete_ComboBox;
        private System.Windows.Forms.ComboBox MemberList_ComboBox;
        private System.Windows.Forms.Label AddUpdateDelete_Text;
        private System.Windows.Forms.Button ResetDB_Button;
    }
}

