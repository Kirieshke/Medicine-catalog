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
    public partial class FormsForm : Form
    {
        public static string connectionString = @"Data Source=DESKTOP-JEBEHPQ\SQLEXPRESS01;Initial Catalog=Kurs_DB;Integrated Security=True";
        public static SqlConnection sqlConnection = new SqlConnection(connectionString);
        public static SqlCommand cmd;
        public static SqlDataAdapter adapt;

        public FormsForm()
        {
            InitializeComponent();
        }

        private void FormsForm_Load(object sender, EventArgs e)
        {          
            Forms f = new Forms();
            f.FormsLoad(dataGridView2);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            InsertForms f = new InsertForms();
            f.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            UpdateForms f = new UpdateForms();
            f.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {

            dataGridView2.Rows.Clear();
            Forms f = new Forms();
            f.FormsLoad(dataGridView2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteForms f = new DeleteForms();
            f.Show();
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
