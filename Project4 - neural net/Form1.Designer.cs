namespace Project4___neural_net
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LoadTestingFileBtn = new System.Windows.Forms.Button();
            this.LoadTrainingFileBtn = new System.Windows.Forms.Button();
            this.BatchRunBtn = new System.Windows.Forms.Button();
            this.CreateNeuralNetBtn = new System.Windows.Forms.Button();
            this.groupBoxPlayer1Type = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.testingModeBtn = new System.Windows.Forms.RadioButton();
            this.trainingModeBtn = new System.Windows.Forms.RadioButton();
            this.RunBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Layer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nodes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.NextImageBtn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBoxPlayer1Type.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(456, 542);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(448, 516);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.LoadTestingFileBtn);
            this.panel2.Controls.Add(this.LoadTrainingFileBtn);
            this.panel2.Controls.Add(this.BatchRunBtn);
            this.panel2.Controls.Add(this.CreateNeuralNetBtn);
            this.panel2.Controls.Add(this.groupBoxPlayer1Type);
            this.panel2.Controls.Add(this.RunBtn);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(442, 510);
            this.panel2.TabIndex = 2;
            // 
            // LoadTestingFileBtn
            // 
            this.LoadTestingFileBtn.Enabled = false;
            this.LoadTestingFileBtn.Location = new System.Drawing.Point(53, 300);
            this.LoadTestingFileBtn.Name = "LoadTestingFileBtn";
            this.LoadTestingFileBtn.Size = new System.Drawing.Size(142, 23);
            this.LoadTestingFileBtn.TabIndex = 21;
            this.LoadTestingFileBtn.Text = "Load Testing Set";
            this.LoadTestingFileBtn.UseVisualStyleBackColor = true;
            this.LoadTestingFileBtn.Click += new System.EventHandler(this.LoadTestingFileBtn_Click);
            // 
            // LoadTrainingFileBtn
            // 
            this.LoadTrainingFileBtn.Enabled = false;
            this.LoadTrainingFileBtn.Location = new System.Drawing.Point(53, 266);
            this.LoadTrainingFileBtn.Name = "LoadTrainingFileBtn";
            this.LoadTrainingFileBtn.Size = new System.Drawing.Size(142, 23);
            this.LoadTrainingFileBtn.TabIndex = 20;
            this.LoadTrainingFileBtn.Text = "Load Training Set";
            this.LoadTrainingFileBtn.UseVisualStyleBackColor = true;
            this.LoadTrainingFileBtn.Click += new System.EventHandler(this.LoadTrainingFileBtn_Click);
            // 
            // BatchRunBtn
            // 
            this.BatchRunBtn.Enabled = false;
            this.BatchRunBtn.Location = new System.Drawing.Point(174, 461);
            this.BatchRunBtn.Name = "BatchRunBtn";
            this.BatchRunBtn.Size = new System.Drawing.Size(125, 23);
            this.BatchRunBtn.TabIndex = 19;
            this.BatchRunBtn.Text = "Batch Run";
            this.BatchRunBtn.UseVisualStyleBackColor = true;
            this.BatchRunBtn.Click += new System.EventHandler(this.BatchRunBtn_Click);
            // 
            // CreateNeuralNetBtn
            // 
            this.CreateNeuralNetBtn.Location = new System.Drawing.Point(53, 229);
            this.CreateNeuralNetBtn.Name = "CreateNeuralNetBtn";
            this.CreateNeuralNetBtn.Size = new System.Drawing.Size(142, 23);
            this.CreateNeuralNetBtn.TabIndex = 18;
            this.CreateNeuralNetBtn.Text = "Create New Neural Net";
            this.CreateNeuralNetBtn.UseVisualStyleBackColor = true;
            this.CreateNeuralNetBtn.Click += new System.EventHandler(this.CreateNeuralNetBtn_Click);
            // 
            // groupBoxPlayer1Type
            // 
            this.groupBoxPlayer1Type.Controls.Add(this.label2);
            this.groupBoxPlayer1Type.Controls.Add(this.numericUpDown2);
            this.groupBoxPlayer1Type.Controls.Add(this.label1);
            this.groupBoxPlayer1Type.Controls.Add(this.numericUpDown1);
            this.groupBoxPlayer1Type.Controls.Add(this.testingModeBtn);
            this.groupBoxPlayer1Type.Controls.Add(this.trainingModeBtn);
            this.groupBoxPlayer1Type.Enabled = false;
            this.groupBoxPlayer1Type.Location = new System.Drawing.Point(19, 345);
            this.groupBoxPlayer1Type.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxPlayer1Type.Name = "groupBoxPlayer1Type";
            this.groupBoxPlayer1Type.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxPlayer1Type.Size = new System.Drawing.Size(262, 77);
            this.groupBoxPlayer1Type.TabIndex = 17;
            this.groupBoxPlayer1Type.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Alpha:";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.DecimalPlaces = 2;
            this.numericUpDown2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown2.Location = new System.Drawing.Point(192, 26);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(53, 20);
            this.numericUpDown2.TabIndex = 23;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Iterations:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(122, 26);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(47, 20);
            this.numericUpDown1.TabIndex = 21;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // testingModeBtn
            // 
            this.testingModeBtn.AutoSize = true;
            this.testingModeBtn.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.testingModeBtn.Location = new System.Drawing.Point(14, 47);
            this.testingModeBtn.Margin = new System.Windows.Forms.Padding(2);
            this.testingModeBtn.Name = "testingModeBtn";
            this.testingModeBtn.Size = new System.Drawing.Size(90, 17);
            this.testingModeBtn.TabIndex = 16;
            this.testingModeBtn.Text = "Testing Mode";
            this.testingModeBtn.UseVisualStyleBackColor = true;
            // 
            // trainingModeBtn
            // 
            this.trainingModeBtn.AutoSize = true;
            this.trainingModeBtn.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.trainingModeBtn.Checked = true;
            this.trainingModeBtn.Location = new System.Drawing.Point(11, 26);
            this.trainingModeBtn.Margin = new System.Windows.Forms.Padding(2);
            this.trainingModeBtn.Name = "trainingModeBtn";
            this.trainingModeBtn.Size = new System.Drawing.Size(93, 17);
            this.trainingModeBtn.TabIndex = 15;
            this.trainingModeBtn.TabStop = true;
            this.trainingModeBtn.Text = "Training Mode";
            this.trainingModeBtn.UseVisualStyleBackColor = true;
            this.trainingModeBtn.CheckedChanged += new System.EventHandler(this.trainingModeBtn_CheckedChanged);
            // 
            // RunBtn
            // 
            this.RunBtn.Enabled = false;
            this.RunBtn.Location = new System.Drawing.Point(23, 461);
            this.RunBtn.Name = "RunBtn";
            this.RunBtn.Size = new System.Drawing.Size(103, 23);
            this.RunBtn.TabIndex = 2;
            this.RunBtn.Text = "Run";
            this.RunBtn.UseVisualStyleBackColor = true;
            this.RunBtn.Click += new System.EventHandler(this.RunBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Layer,
            this.Nodes});
            this.dataGridView1.Location = new System.Drawing.Point(23, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(202, 208);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_DefaultValuesNeeded);
            this.dataGridView1.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_UserAddedRow);
            this.dataGridView1.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_UserDeletedRow);
            // 
            // Layer
            // 
            this.Layer.HeaderText = "Layer";
            this.Layer.Name = "Layer";
            this.Layer.ReadOnly = true;
            this.Layer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Layer.Width = 60;
            // 
            // Nodes
            // 
            this.Nodes.HeaderText = "# of Nodes";
            this.Nodes.Name = "Nodes";
            this.Nodes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Nodes.Width = 80;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(448, 516);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "digitView";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.NextImageBtn);
            this.panel1.Location = new System.Drawing.Point(8, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 436);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(36, 75);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // NextImageBtn
            // 
            this.NextImageBtn.Location = new System.Drawing.Point(126, 39);
            this.NextImageBtn.Name = "NextImageBtn";
            this.NextImageBtn.Size = new System.Drawing.Size(35, 23);
            this.NextImageBtn.TabIndex = 2;
            this.NextImageBtn.Text = ">";
            this.NextImageBtn.UseVisualStyleBackColor = true;
            this.NextImageBtn.Click += new System.EventHandler(this.NextImageBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 542);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBoxPlayer1Type.ResumeLayout(false);
            this.groupBoxPlayer1Type.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button NextImageBtn;
        private System.Windows.Forms.Button RunBtn;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBoxPlayer1Type;
        private System.Windows.Forms.RadioButton testingModeBtn;
        private System.Windows.Forms.RadioButton trainingModeBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button CreateNeuralNetBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Layer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nodes;
        private System.Windows.Forms.Button BatchRunBtn;
        private System.Windows.Forms.Button LoadTestingFileBtn;
        private System.Windows.Forms.Button LoadTrainingFileBtn;
    }
}

