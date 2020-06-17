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
    public partial class UpdateForms : Form
    {
        public static string connectionString = @"Data Source=DESKTOP-JEBEHPQ\SQLEXPRESS01;Initial Catalog=Kurs_DB;Integrated Security=True";
        public static SqlConnection sqlConnection = new SqlConnection(connectionString);
        public static SqlCommand cmd;
        public static SqlDataAdapter adapt;

        public UpdateForms()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormsForm ff = new FormsForm();
            Forms f = new Forms();
            f.UpdateForms(comboBox1, textBox2, textBox1, ff.dataGridView2);
        }

        private void UpdateForms_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Forms";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            string[] Form_ = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                Form_[i] = dt.Rows[i]["ID_Form"].ToString() + "." + dt.Rows[i]["FormName"].ToString();
                comboBox1.Items.Add(Form_[i]);
            }
        }
    }
}
