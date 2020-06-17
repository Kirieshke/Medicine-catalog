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
    public partial class ManForms : Form
    {
        public ManForms()
        {
            InitializeComponent();
        }

        private void ManForms_Load(object sender, EventArgs e)
        {
            Manufacturer m = new Manufacturer();
            m.ManufacturerLoad(dataGridView3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertMan man = new InsertMan();
            man.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateMan man = new UpdateMan();
            man.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteMan man = new DeleteMan();
            man.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            Manufacturer manufacturer = new Manufacturer();
            manufacturer.ManufacturerLoad(dataGridView3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Admin admin = new Admin();
            admin.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Instraction s = new Instraction();
            s.Show();
        }
    }
}
