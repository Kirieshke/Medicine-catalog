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
    public partial class InsertSymptom : Form
    {
       
        public InsertSymptom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SymptomForm ss = new SymptomForm();
            Symptom s = new Symptom();
            s.InsertSymptom(textBox1,textBox2,ss.dataGridView1);
        }

        private void InsertSymptom_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
