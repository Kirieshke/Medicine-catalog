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
    public partial class DeleteSymptom : Form
    {
        public static string connectionString = @"Data Source=DESKTOP-JEBEHPQ\SQLEXPRESS01;Initial Catalog=Kurs_DB;Integrated Security=True";
        public static SqlConnection sqlConnection = new SqlConnection(connectionString);
        public static SqlCommand cmd;
        public DeleteSymptom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SymptomForm ss = new SymptomForm();
            Symptom s = new Symptom();
            s.DeleteSymptom(comboBox1, ss.dataGridView1);
        }

        private void DeleteSymptom_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Symptom";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            string[] Symptom_ = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                Symptom_[i] = dt.Rows[i]["ID_Symptom"].ToString() + "." + dt.Rows[i]["NameSymptom"].ToString();
                comboBox1.Items.Add(Symptom_[i]);
            }

            sqlConnection.Close();
        }
    }
}
