namespace WindowsFormsApp3
{
    partial class Instraction
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
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.FormName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name_Medicine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name_Manufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age_From = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age_To = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Healing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dosage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView5
            // 
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FormName,
            this.Name_Medicine,
            this.Name_Manufacturer,
            this.Duration,
            this.Frequency,
            this.Age_From,
            this.Age_To,
            this.Healing,
            this.Dosage});
            this.dataGridView5.Location = new System.Drawing.Point(12, 3);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.RowHeadersWidth = 51;
            this.dataGridView5.RowTemplate.Height = 24;
            this.dataGridView5.Size = new System.Drawing.Size(1525, 452);
            this.dataGridView5.TabIndex = 1;
            // 
            // FormName
            // 
            this.FormName.HeaderText = "FormName";
            this.FormName.MinimumWidth = 6;
            this.FormName.Name = "FormName";
            this.FormName.Width = 125;
            // 
            // Name_Medicine
            // 
            this.Name_Medicine.HeaderText = "Name_Medicine";
            this.Name_Medicine.MinimumWidth = 6;
            this.Name_Medicine.Name = "Name_Medicine";
            this.Name_Medicine.Width = 125;
            // 
            // Name_Manufacturer
            // 
            this.Name_Manufacturer.HeaderText = "Name_Manufacturer";
            this.Name_Manufacturer.MinimumWidth = 6;
            this.Name_Manufacturer.Name = "Name_Manufacturer";
            this.Name_Manufacturer.Width = 125;
            // 
            // Duration
            // 
            this.Duration.HeaderText = "Duration";
            this.Duration.MinimumWidth = 6;
            this.Duration.Name = "Duration";
            this.Duration.Width = 125;
            // 
            // Frequency
            // 
            this.Frequency.HeaderText = "Frequency";
            this.Frequency.MinimumWidth = 6;
            this.Frequency.Name = "Frequency";
            this.Frequency.Width = 125;
            // 
            // Age_From
            // 
            this.Age_From.HeaderText = "Age_From";
            this.Age_From.MinimumWidth = 6;
            this.Age_From.Name = "Age_From";
            this.Age_From.Width = 125;
            // 
            // Age_To
            // 
            this.Age_To.HeaderText = "Age_To";
            this.Age_To.MinimumWidth = 6;
            this.Age_To.Name = "Age_To";
            this.Age_To.Width = 125;
            // 
            // Healing
            // 
            this.Healing.HeaderText = "Healing";
            this.Healing.MinimumWidth = 6;
            this.Healing.Name = "Healing";
            this.Healing.Width = 125;
            // 
            // Dosage
            // 
            this.Dosage.HeaderText = "Dosage";
            this.Dosage.MinimumWidth = 6;
            this.Dosage.Name = "Dosage";
            this.Dosage.Width = 125;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 480);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 55);
            this.button1.TabIndex = 2;
            this.button1.Text = "Добавить информацию";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(751, 480);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(201, 55);
            this.button2.TabIndex = 3;
            this.button2.Text = "Обновить данные";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Instraction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 655);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView5);
            this.Name = "Instraction";
            this.Text = "Instraction";
            this.Load += new System.EventHandler(this.Instraction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn FormName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_Medicine;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_Manufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age_From;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age_To;
        private System.Windows.Forms.DataGridViewTextBoxColumn Healing;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dosage;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.Button button2;
    }
}