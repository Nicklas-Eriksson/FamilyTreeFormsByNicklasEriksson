using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FamilyTree
{
    public partial class Dashboard2 : Form
    {
        private Label SQLSandbox;
        private Button BackToFamilyTree;
        private ListBox SQLResultListBox;
        private Label ResultLabel;
        private TextBox SQLCommandBox;
        private Button ExecuteButton;
        private System.ComponentModel.IContainer components;
        private ErrorProvider errorProvider1;
        private Label labelCommands;
        private Label labelTables;
        private ComboBox comboBoxCommands;
        private ComboBox comboBoxTables;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label5;
        private Label label6;
        private Label label3;
        private Label label4;
        private Label label2;
        private Label label1;
        private ComboBox comboBox5;
        private ComboBox comboBox6;
        private ComboBox comboBox7;
        private ComboBox comboBox8;
        private ComboBox comboBox3;
        private ComboBox comboBox4;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Label labelTypes;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox1;
        private Label labelValues;
        private Label label17;
        private TextBox textBox8;
        private Button button1;
        private Label labelNewTable;
        private TextBox textBox4;
        private Button button2;
        private PictureBox TreePNGBox;

        public Dashboard2()
        {
            InitializeComponent();
        }


        private void Dashboard2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SQLResultListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BackToFamilyTree_Click(object sender, EventArgs e)
        {

        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            ResetListbox();
            var DA = new DataAccess();
            //var SQLResults = new List<Person>();
             
            //var SQLResults = DA.SQLSandbox(SQLCommandBox.Text);
            //DisplayResults(SQLResults);
        }

        private void DisplayResults(string insertedString)
        {
            
            //    SQLResultListBox.DataSource = insertedString.ToList();
            //    SQLResultListBox.DisplayMember
            

            //var DB = new Dashboard();
          
        }

        private void ResetListbox()
        {
            SQLResultListBox.DataSource = null;
            SQLResultListBox.Items.Clear();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard2));
            this.TreePNGBox = new System.Windows.Forms.PictureBox();
            this.SQLSandbox = new System.Windows.Forms.Label();
            this.BackToFamilyTree = new System.Windows.Forms.Button();
            this.SQLResultListBox = new System.Windows.Forms.ListBox();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.SQLCommandBox = new System.Windows.Forms.TextBox();
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.comboBoxTables = new System.Windows.Forms.ComboBox();
            this.comboBoxCommands = new System.Windows.Forms.ComboBox();
            this.labelTables = new System.Windows.Forms.Label();
            this.labelCommands = new System.Windows.Forms.Label();
            this.labelValues = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.labelTypes = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.labelNewTable = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TreePNGBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // TreePNGBox
            // 
            this.TreePNGBox.Image = ((System.Drawing.Image)(resources.GetObject("TreePNGBox.Image")));
            this.TreePNGBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("TreePNGBox.InitialImage")));
            this.TreePNGBox.Location = new System.Drawing.Point(1122, 12);
            this.TreePNGBox.Name = "TreePNGBox";
            this.TreePNGBox.Size = new System.Drawing.Size(72, 70);
            this.TreePNGBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TreePNGBox.TabIndex = 27;
            this.TreePNGBox.TabStop = false;
            // 
            // SQLSandbox
            // 
            this.SQLSandbox.AutoSize = true;
            this.SQLSandbox.Font = new System.Drawing.Font("SimSun", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SQLSandbox.ForeColor = System.Drawing.Color.Crimson;
            this.SQLSandbox.Location = new System.Drawing.Point(711, 9);
            this.SQLSandbox.Name = "SQLSandbox";
            this.SQLSandbox.Size = new System.Drawing.Size(391, 64);
            this.SQLSandbox.TabIndex = 28;
            this.SQLSandbox.Tag = "H1";
            this.SQLSandbox.Text = "SQL Sandbox";
            // 
            // BackToFamilyTree
            // 
            this.BackToFamilyTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackToFamilyTree.Location = new System.Drawing.Point(12, 12);
            this.BackToFamilyTree.Name = "BackToFamilyTree";
            this.BackToFamilyTree.Size = new System.Drawing.Size(119, 27);
            this.BackToFamilyTree.TabIndex = 29;
            this.BackToFamilyTree.Text = "Family Tree";
            this.BackToFamilyTree.UseVisualStyleBackColor = true;
            this.BackToFamilyTree.Click += new System.EventHandler(this.BackToFamilyTree_Click);
            // 
            // SQLResultListBox
            // 
            this.SQLResultListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SQLResultListBox.FormattingEnabled = true;
            this.SQLResultListBox.ItemHeight = 20;
            this.SQLResultListBox.Location = new System.Drawing.Point(646, 333);
            this.SQLResultListBox.Name = "SQLResultListBox";
            this.SQLResultListBox.Size = new System.Drawing.Size(532, 324);
            this.SQLResultListBox.TabIndex = 31;
            this.SQLResultListBox.SelectedIndexChanged += new System.EventHandler(this.SQLResultListBox_SelectedIndexChanged);
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Font = new System.Drawing.Font("SimSun", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.ResultLabel.Location = new System.Drawing.Point(639, 293);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(137, 37);
            this.ResultLabel.TabIndex = 33;
            this.ResultLabel.Tag = "H2";
            this.ResultLabel.Text = "Result";
            // 
            // SQLCommandBox
            // 
            this.SQLCommandBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SQLCommandBox.Location = new System.Drawing.Point(42, 402);
            this.SQLCommandBox.Multiline = true;
            this.SQLCommandBox.Name = "SQLCommandBox";
            this.SQLCommandBox.Size = new System.Drawing.Size(211, 28);
            this.SQLCommandBox.TabIndex = 34;
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExecuteButton.Location = new System.Drawing.Point(472, 630);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(93, 27);
            this.ExecuteButton.TabIndex = 35;
            this.ExecuteButton.Text = "Execute";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.RightToLeftChanged += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // comboBoxTables
            // 
            this.comboBoxTables.FormattingEnabled = true;
            this.comboBoxTables.Location = new System.Drawing.Point(18, 309);
            this.comboBoxTables.Name = "comboBoxTables";
            this.comboBoxTables.Size = new System.Drawing.Size(174, 21);
            this.comboBoxTables.TabIndex = 36;
            // 
            // comboBoxCommands
            // 
            this.comboBoxCommands.FormattingEnabled = true;
            this.comboBoxCommands.Location = new System.Drawing.Point(217, 309);
            this.comboBoxCommands.Name = "comboBoxCommands";
            this.comboBoxCommands.Size = new System.Drawing.Size(282, 21);
            this.comboBoxCommands.TabIndex = 37;
            // 
            // labelTables
            // 
            this.labelTables.AutoSize = true;
            this.labelTables.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTables.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelTables.Location = new System.Drawing.Point(14, 282);
            this.labelTables.Name = "labelTables";
            this.labelTables.Size = new System.Drawing.Size(88, 24);
            this.labelTables.TabIndex = 38;
            this.labelTables.Tag = "H2";
            this.labelTables.Text = "Tables";
            this.labelTables.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // labelCommands
            // 
            this.labelCommands.AutoSize = true;
            this.labelCommands.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommands.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelCommands.Location = new System.Drawing.Point(213, 282);
            this.labelCommands.Name = "labelCommands";
            this.labelCommands.Size = new System.Drawing.Size(114, 24);
            this.labelCommands.TabIndex = 39;
            this.labelCommands.Tag = "H2";
            this.labelCommands.Text = "Commands";
            this.labelCommands.Click += new System.EventHandler(this.label2_Click);
            // 
            // labelValues
            // 
            this.labelValues.AutoSize = true;
            this.labelValues.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValues.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelValues.Location = new System.Drawing.Point(38, 375);
            this.labelValues.Name = "labelValues";
            this.labelValues.Size = new System.Drawing.Size(88, 24);
            this.labelValues.TabIndex = 40;
            this.labelValues.Tag = "H2";
            this.labelValues.Text = "Values";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(42, 436);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(211, 28);
            this.textBox1.TabIndex = 41;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(42, 504);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(211, 28);
            this.textBox2.TabIndex = 43;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(42, 470);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(211, 28);
            this.textBox3.TabIndex = 42;
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(42, 606);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(211, 28);
            this.textBox5.TabIndex = 46;
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(42, 572);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(211, 28);
            this.textBox6.TabIndex = 45;
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(42, 538);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(211, 28);
            this.textBox7.TabIndex = 44;
            // 
            // labelTypes
            // 
            this.labelTypes.AutoSize = true;
            this.labelTypes.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTypes.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelTypes.Location = new System.Drawing.Point(289, 375);
            this.labelTypes.Name = "labelTypes";
            this.labelTypes.Size = new System.Drawing.Size(75, 24);
            this.labelTypes.TabIndex = 48;
            this.labelTypes.Tag = "H2";
            this.labelTypes.Text = "Types";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "INT",
            "NVARCHAR(40)"});
            this.comboBox1.Location = new System.Drawing.Point(293, 402);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(144, 21);
            this.comboBox1.TabIndex = 49;
            this.comboBox1.Tag = "TypeBoxes";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "INT",
            "NVARCHAR(40)"});
            this.comboBox2.Location = new System.Drawing.Point(293, 436);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(144, 21);
            this.comboBox2.TabIndex = 50;
            this.comboBox2.Tag = "TypeBoxes";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "INT",
            "NVARCHAR(40)"});
            this.comboBox3.Location = new System.Drawing.Point(293, 470);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(144, 21);
            this.comboBox3.TabIndex = 52;
            this.comboBox3.Tag = "TypeBoxes";
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "INT",
            "NVARCHAR(40)"});
            this.comboBox4.Location = new System.Drawing.Point(293, 504);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(144, 21);
            this.comboBox4.TabIndex = 51;
            this.comboBox4.Tag = "TypeBoxes";
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "INT",
            "NVARCHAR(40)"});
            this.comboBox5.Location = new System.Drawing.Point(293, 538);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(144, 21);
            this.comboBox5.TabIndex = 56;
            this.comboBox5.Tag = "TypeBoxes";
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Items.AddRange(new object[] {
            "INT",
            "NVARCHAR(40)"});
            this.comboBox6.Location = new System.Drawing.Point(293, 572);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(144, 21);
            this.comboBox6.TabIndex = 55;
            this.comboBox6.Tag = "TypeBoxes";
            // 
            // comboBox7
            // 
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Items.AddRange(new object[] {
            "INT",
            "NVARCHAR(40)"});
            this.comboBox7.Location = new System.Drawing.Point(293, 602);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(144, 21);
            this.comboBox7.TabIndex = 54;
            this.comboBox7.Tag = "TypeBoxes";
            // 
            // comboBox8
            // 
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Items.AddRange(new object[] {
            "INT",
            "NVARCHAR(40)"});
            this.comboBox8.Location = new System.Drawing.Point(293, 636);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(144, 21);
            this.comboBox8.TabIndex = 53;
            this.comboBox8.Tag = "TypeBoxes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(14, 402);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 21);
            this.label1.TabIndex = 57;
            this.label1.Tag = "Numbers";
            this.label1.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(265, 402);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 21);
            this.label2.TabIndex = 58;
            this.label2.Tag = "Numbers";
            this.label2.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(265, 436);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 21);
            this.label3.TabIndex = 60;
            this.label3.Tag = "Numbers";
            this.label3.Text = "2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(14, 436);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 21);
            this.label4.TabIndex = 59;
            this.label4.Tag = "Numbers";
            this.label4.Text = "2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(265, 469);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 21);
            this.label5.TabIndex = 62;
            this.label5.Tag = "Numbers";
            this.label5.Text = "3";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(14, 470);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 21);
            this.label6.TabIndex = 61;
            this.label6.Tag = "Numbers";
            this.label6.Text = "3";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label7.Location = new System.Drawing.Point(265, 572);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 21);
            this.label7.TabIndex = 68;
            this.label7.Tag = "Numbers";
            this.label7.Text = "6";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label8.Location = new System.Drawing.Point(14, 572);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 21);
            this.label8.TabIndex = 67;
            this.label8.Tag = "Numbers";
            this.label8.Text = "6";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label9.Location = new System.Drawing.Point(265, 538);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 21);
            this.label9.TabIndex = 66;
            this.label9.Tag = "Numbers";
            this.label9.Text = "5";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label10.Location = new System.Drawing.Point(14, 538);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 21);
            this.label10.TabIndex = 65;
            this.label10.Tag = "Numbers";
            this.label10.Text = "5";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label11.Location = new System.Drawing.Point(265, 504);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 21);
            this.label11.TabIndex = 64;
            this.label11.Tag = "Numbers";
            this.label11.Text = "4";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label12.Location = new System.Drawing.Point(14, 504);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 21);
            this.label12.TabIndex = 63;
            this.label12.Tag = "Numbers";
            this.label12.Text = "4";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label13.Location = new System.Drawing.Point(265, 636);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 21);
            this.label13.TabIndex = 72;
            this.label13.Tag = "Numbers";
            this.label13.Text = "8";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label14.Location = new System.Drawing.Point(14, 636);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 21);
            this.label14.TabIndex = 71;
            this.label14.Tag = "Numbers";
            this.label14.Text = "8";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label15.Location = new System.Drawing.Point(265, 602);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(22, 21);
            this.label15.TabIndex = 70;
            this.label15.Tag = "Numbers";
            this.label15.Text = "7";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label16.Location = new System.Drawing.Point(14, 602);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 21);
            this.label16.TabIndex = 69;
            this.label16.Tag = "Numbers";
            this.label16.Text = "7";
            // 
            // labelNewTable
            // 
            this.labelNewTable.AutoSize = true;
            this.labelNewTable.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewTable.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelNewTable.Location = new System.Drawing.Point(34, 114);
            this.labelNewTable.Name = "labelNewTable";
            this.labelNewTable.Size = new System.Drawing.Size(218, 24);
            this.labelNewTable.TabIndex = 73;
            this.labelNewTable.Tag = "H2";
            this.labelNewTable.Text = "Create New Table";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(271, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 27);
            this.button1.TabIndex = 74;
            this.button1.Text = "Execute";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox8
            // 
            this.textBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(78, 153);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(174, 26);
            this.textBox8.TabIndex = 75;
            this.textBox8.TextChanged += new System.EventHandler(this.textBox8_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label17.Location = new System.Drawing.Point(14, 153);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 21);
            this.label17.TabIndex = 76;
            this.label17.Tag = "";
            this.label17.Text = "Name";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(518, 306);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 27);
            this.button2.TabIndex = 77;
            this.button2.Text = "Execute";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(42, 640);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(211, 28);
            this.textBox4.TabIndex = 78;
            // 
            // Dashboard2
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1206, 685);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelNewTable);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.comboBox6);
            this.Controls.Add(this.comboBox7);
            this.Controls.Add(this.comboBox8);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.labelTypes);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelValues);
            this.Controls.Add(this.labelCommands);
            this.Controls.Add(this.labelTables);
            this.Controls.Add(this.comboBoxCommands);
            this.Controls.Add(this.comboBoxTables);
            this.Controls.Add(this.ExecuteButton);
            this.Controls.Add(this.SQLCommandBox);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.SQLResultListBox);
            this.Controls.Add(this.BackToFamilyTree);
            this.Controls.Add(this.SQLSandbox);
            this.Controls.Add(this.TreePNGBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dashboard2";
            this.Load += new System.EventHandler(this.Dashboard2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TreePNGBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
