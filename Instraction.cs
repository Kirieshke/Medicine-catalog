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
    public partial class Instraction : Form
    {
        public static string connectionString = @"Data Source=DESKTOP-JEBEHPQ\SQLEXPRESS01;Initial Catalog=Kurs_DB;Integrated Security=True";
        public static SqlConnection sqlConnection = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand();
        public Instraction()
        {
            InitializeComponent();
        }
        public void InstractionLoad(DataGridView dgvя)
        {
            sqlConnection.Open();
            string query = "Select FormName, NameMedicine, NameManufacturer, Duration, Frequency, Age_From, Age_To, Healing, Dosage From((Forms inner join MedicineForms on Forms.ID_Form = MedicineForms.ID_Form)inner join Medicine on MedicineForms.ID_Medicine = Medicine.ID_Medicine) inner join Manufacturer on MedicineForms.ID_Manufacturer = Manufacturer.ID_Manufacturer ";
            List<string[]> data = new List<string[]>();
            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataReader reader6 = command.ExecuteReader();

            while (reader6.Read())
            {
                data.Add(new string[9]);
                data[data.Count - 1][0] = reader6[0].ToString();
                data[data.Count - 1][1] = reader6[1].ToString();
                data[data.Count - 1][2] = reader6[2].ToString();
                data[data.Count - 1][3] = reader6[3].ToString();
                data[data.Count - 1][4] = reader6[4].ToString();
                data[data.Count - 1][5] = reader6[5].ToString();
                data[data.Count - 1][6] = reader6[6].ToString();
                data[data.Count - 1][7] = reader6[7].ToString();
                data[data.Count - 1][8] = reader6[8].ToString();
            }
            foreach (string[] s in data)
            {
                dataGridView5.Rows.Add(s);
            }
            sqlConnection.Close();

        }
        private void Instraction_Load(object sender, EventArgs e)
        {
            sqlConnection.Open();
            string query = "Select FormName, NameMedicine, NameManufacturer, Duration, Frequency, Age_From, Age_To, Healing, Dosage From((Forms inner join MedicineForms on Forms.ID_Form = MedicineForms.ID_Form)inner join Medicine on MedicineForms.ID_Medicine = Medicine.ID_Medicine) inner join Manufacturer on MedicineForms.ID_Manufacturer = Manufacturer.ID_Manufacturer ";
            List<string[]> data = new List<string[]>();
            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataReader reader6 = command.ExecuteReader();

            while (reader6.Read())
            {
                data.Add(new string[9]);
                data[data.Count - 1][0] = reader6[0].ToString();
                data[data.Count - 1][1] = reader6[1].ToString();
                data[data.Count - 1][2] = reader6[2].ToString();
                data[data.Count - 1][3] = reader6[3].ToString();
                data[data.Count - 1][4] = reader6[4].ToString();
                data[data.Count - 1][5] = reader6[5].ToString();
                data[data.Count - 1][6] = reader6[6].ToString();
                data[data.Count - 1][7] = reader6[7].ToString();
                data[data.Count - 1][8] = reader6[8].ToString();
            }
            foreach (string[] s in data)
            {
                dataGridView5.Rows.Add(s);
            }
            sqlConnection.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertInstruction ii = new InsertInstruction();
            ii.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView5.Rows.Clear();
            
            InstractionLoad(dataGridView5);
        }
    }
}
