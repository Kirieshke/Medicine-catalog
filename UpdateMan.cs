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
    public partial class UpdateMan : Form
    {
        public static string connectionString = @"Data Source=DESKTOP-JEBEHPQ\SQLEXPRESS01;Initial Catalog=Kurs_DB;Integrated Security=True";
        public static SqlConnection sqlConnection = new SqlConnection(connectionString);
        public static SqlCommand cmd;
        ManForms mf = new ManForms();
        
        public UpdateMan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manufacturer manufacturer = new Manufacturer();
            manufacturer.UpdateManufacturer(comboBox1,textBox2,textBox3,textBox1, mf.dataGridView3);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateMan_Load(object sender, EventArgs e)
        {

            comboBox1.Items.Clear();
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Manufacturer";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            string[] Manufacturer_ = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                Manufacturer_[i] = dt.Rows[i]["ID_Manufacturer"].ToString() + "." + dt.Rows[i]["NameManufacturer"].ToString();
                comboBox1.Items.Add(Manufacturer_[i]);
            }

            sqlConnection.Close();
        }
    }
}
