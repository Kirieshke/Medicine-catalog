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
    public partial class InsertDisease : Form
    {
        DiseaseForm f = new DiseaseForm();
        public InsertDisease()
        {
            InitializeComponent();
        }

        private void InsertDisease_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Disease d = new Disease();
            d.InsertDisease(textBox1, textBox2, f.dataGridView1);
        }
    }
}
