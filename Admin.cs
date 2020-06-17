using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace WindowsFormsApp3
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            string[] forms = new string[] { "Disease", "Forms", "Manufacturer", "Medicine", "Symptom" };
            comboBox1.Items.AddRange(forms);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var item = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            if (item == "Disease")
            {
                DiseaseForm df = new DiseaseForm();
                df.Show();
            }
            else if (item == "Forms")
            {
                FormsForm ff = new FormsForm();
                ff.Show();
            }
            else if (item == "Manufacturer")
            {
                ManForms mf = new ManForms();
                mf.Show();
            }
            else if (item == "Medicine")
            {
                MedicineForm med= new MedicineForm();
                med.Show();
            }
            else if(item == "Symptom")
            {
                SymptomForm sf = new SymptomForm();
                sf.Show();
            }
            else
            {
                MessageBox.Show("Choose something");
                return;
            }

            this.Close();
        }
    }
}
