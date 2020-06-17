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
    public partial class InsertMan : Form
    {
        ManForms mf = new ManForms();
        public InsertMan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manufacturer m = new Manufacturer();
            m.InsertManufacturer(textBox1, textBox2, textBox3, mf.dataGridView3);
            
        }
    }
}
