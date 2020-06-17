using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class SymptomForm : Form
    {
        public SymptomForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertSymptom s = new InsertSymptom();
            s.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Symptom s = new Symptom();
            s.SymptomLoad(dataGridView1);
        }

        private void SymptomForm_Load(object sender, EventArgs e)
        {
            Symptom s = new Symptom();
            s.SymptomLoad(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateSymptom s = new UpdateSymptom();
            s.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteSymptom s = new DeleteSymptom();
            s.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Instraction s = new Instraction();
            s.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Admin admin = new Admin();
            admin.Show();
        }
    }
}
