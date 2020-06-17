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
    public partial class UpdateDisease : Form
    {
        public static string connectionString = @"Data Source=DESKTOP-JEBEHPQ\SQLEXPRESS01;Initial Catalog=Kurs_DB;Integrated Security=True";
        public static SqlConnection sqlConnection = new SqlConnection(connectionString);
        public static SqlCommand cmd;
        public static SqlDataAdapter adapt;

        DiseaseForm f = new DiseaseForm();
        public UpdateDisease()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Disease d = new Disease();
            d.UpdateDisease(comboBox1, textBox1, textBox2, f.dataGridView1);
        }

        private void UpdateDisease_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Disease";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            string[] Disease_ = new string[dt.Rows.Count];
            for(int i = 0; i < dt.Rows.Count; ++i)
            {
                Disease_[i] = dt.Rows[i]["ID_Disease"].ToString() + "." + dt.Rows[i]["NameDisease"].ToString();
                comboBox1.Items.Add(Disease_[i]);
            }

            sqlConnection.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
