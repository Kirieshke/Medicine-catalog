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
    public partial class UpdateMedicine : Form
    {
        public static string connectionString = @"Data Source=DESKTOP-JEBEHPQ\SQLEXPRESS01;Initial Catalog=Kurs_DB;Integrated Security=True";
        public static SqlConnection sqlConnection = new SqlConnection(connectionString);
        public static SqlCommand cmd;
        MedicineForm mf = new MedicineForm();

        public UpdateMedicine()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Medicine med = new Medicine();
            med.UpdateMedicine(comboBox1, textBox2,textBox1, mf.dataGridView4);
        }

        private void UpdateMedicine_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Medicine";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            string[] Medicine_ = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                Medicine_[i] = dt.Rows[i]["ID_Medicine"].ToString() + "." + dt.Rows[i]["NameMedicine"].ToString();
                comboBox1.Items.Add(Medicine_[i]);
            }

            sqlConnection.Close();
        }
    }
}
