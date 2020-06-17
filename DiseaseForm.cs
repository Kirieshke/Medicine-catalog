using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp3
{
    public partial class DiseaseForm : Form
    {
        public static string connectionString = @"Data Source=DESKTOP-JEBEHPQ\SQLEXPRESS01;Initial Catalog=Kurs_DB;Integrated Security=True";
        public static SqlConnection sqlConnection = new SqlConnection(connectionString);
        public static SqlCommand cmd;
        public static SqlDataAdapter adapt;
        public DiseaseForm()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
          
            Disease disease = new Disease();
            disease.DiseaseLoad(dataGridView1);

        }

        public void dataGridView1_CellContentClick(object sender, EventArgs e)
        {
          
        }

      
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Admin admin = new Admin();
            admin.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            InsertDisease insertDisease = new InsertDisease();
            insertDisease.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            UpdateDisease updateDisease = new UpdateDisease();
            updateDisease.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DeleteDisease deleteDisease = new DeleteDisease();
            deleteDisease.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Disease disease = new Disease();
            disease.DiseaseLoad(dataGridView1);
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            TherapyForm t = new TherapyForm();
            t.Show();
        }
    }
}
