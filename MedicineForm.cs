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
    public partial class MedicineForm : Form
    {
        public MedicineForm()
        {
            InitializeComponent();
        }

        private void MedicineForm_Load(object sender, EventArgs e)
        {
            Medicine med = new Medicine();
            med.MedicineLoad(dataGridView4);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            InsertMedicine med = new InsertMedicine();
            med.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateMedicine med = new UpdateMedicine();
            med.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteMedicine med = new DeleteMedicine();
            med.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView4.Rows.Clear();
            Medicine medicine = new Medicine();
            medicine.MedicineLoad(dataGridView4);
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
