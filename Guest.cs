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
    public partial class Guest : Form
    {
        public static string connectionString = @"Data Source=DESKTOP-JEBEHPQ\SQLEXPRESS01;Initial Catalog=Kurs_DB;Integrated Security=True";
        public static SqlConnection sqlConnection = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand();

        public Guest()
        {
            InitializeComponent();
        }

        public void SearchInCB()
        {
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox3.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox3.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox4.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox4.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox5.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox5.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox6.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox6.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox7.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox7.AutoCompleteSource = AutoCompleteSource.ListItems;

        }
        private void Guest_Load(object sender, EventArgs e)
        {
            SearchInCB();

            Disease d = new Disease();
            d.DiseaseLoadGuest(dataGridView1);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select NameDisease From Disease";
            cmd.Connection = sqlConnection;

            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["NameDisease"]);
            }
            reader.Close();
            sqlConnection.Close();
            ///////////////////////////////////////////////////////////////////////
            Forms f = new Forms();
            f.FormGuestLoad(dataGridView2);

            cmd.CommandText = "Select FormName From Forms";
            cmd.Connection = sqlConnection;

            sqlConnection.Open();
            SqlDataReader reader1 = cmd.ExecuteReader();
            while (reader1.Read())
            {
                comboBox2.Items.Add(reader1["FormName"]);
            }
            reader1.Close();
            sqlConnection.Close();
            ///////////////////////////////////////////////////////////////////////
            Manufacturer man = new Manufacturer();
            man.ManGuestLoad(dataGridView3);

            cmd.CommandText = "Select NameManufacturer From Manufacturer";
            cmd.Connection = sqlConnection;

            sqlConnection.Open();
            SqlDataReader reader2 = cmd.ExecuteReader();
            while (reader2.Read())
            {
                comboBox3.Items.Add(reader2["NameManufacturer"]);
            }
            reader2.Close();
            sqlConnection.Close();
            ///////////////////////////////////////////////////////////////////////
            Medicine med = new Medicine();
            med.MedGuestLoad(dataGridView4);


            cmd.CommandText = "Select NameMedicine From Medicine";
            cmd.Connection = sqlConnection;

            sqlConnection.Open();
            SqlDataReader reader3 = cmd.ExecuteReader();
            while (reader3.Read())
            {
                comboBox4.Items.Add(reader3["NameMedicine"]);
            }
            reader3.Close();
            sqlConnection.Close();
            ///////////////////////////////////////////////////////////////////////


            cmd.CommandText = "Select NameSymptom From Symptom";
            cmd.Connection = sqlConnection;

            sqlConnection.Open();
            SqlDataReader reader4 = cmd.ExecuteReader();
            while (reader4.Read())
            {
                comboBox5.Items.Add(reader4["NameSymptom"]);

            }
            reader4.Close();
            sqlConnection.Close();

            //////////////////////////////////////////////////////////////

            cmd.CommandText = "Select NameSymptom From Symptom";
            cmd.Connection = sqlConnection;

            sqlConnection.Open();
            SqlDataReader reader5 = cmd.ExecuteReader();
            while (reader5.Read())
            {
                comboBox7.Items.Add(reader5["NameSymptom"]);

            }
            reader5.Close();
            sqlConnection.Close();

            /////////////////////////////////////////////////////////////

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

            ////////////////////////////////////////////////////////////////

           

            ///////////////////////////////////////////////////////////////////////
            sqlConnection.Open();
            string query2 = "select NameManufacturer, NameMedicine From (Manufacturer inner join MedManufacturer on Manufacturer.ID_Manufacturer = MedManufacturer.ID_Manufacturer) inner join Medicine on MedManufacturer.ID_Medicine = Medicine.ID_Medicine ";
            List<string[]> data2 = new List<string[]>();
            SqlCommand command2 = new SqlCommand(query2, sqlConnection);
            SqlDataReader reader8 = command2.ExecuteReader();

            while (reader8.Read())
            {
                data2.Add(new string[2]);
                data2[data2.Count - 1][0] = reader8[0].ToString();
                data2[data2.Count - 1][1] = reader8[1].ToString();

            }
            foreach (string[] s in data2)
            {
                dataGridView7.Rows.Add(s);
            }
            sqlConnection.Close();

            ////////////////////////////////////////////////////////
            sqlConnection.Open();
            string query3 = "select NameSymptom From Symptom";
            List<string[]> data3 = new List<string[]>();
            SqlCommand command3 = new SqlCommand(query3, sqlConnection);
            SqlDataReader reader9 = command3.ExecuteReader();

            while (reader9.Read())
            {
                data3.Add(new string[1]);
                data3[data3.Count - 1][0] = reader9[0].ToString();
              

            }
            foreach (string[] s in data3)
            {
                dataGridView8.Rows.Add(s);
            }
            sqlConnection.Close();

        }

        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView9.Rows.Clear();
            sqlConnection.Open();
            GuestClass g = new GuestClass();
            g.DiseaseG(richTextBox1, comboBox1);
            dataGridView9.Visible = true;
            string query2 = "Select NameDisease, NameMedicine From(Disease inner join Therapy on Disease.ID_Disease = Therapy.ID_Disease) inner join Medicine on Therapy.ID_Medicine = Medicine.ID_Medicine where NameDisease ='" + comboBox1.Text + "' Group by Disease.NameDisease, Medicine.NameMedicine";
            List<string[]> data2 = new List<string[]>();
            SqlCommand command2 = new SqlCommand(query2, sqlConnection);
            SqlDataReader reader8 = command2.ExecuteReader();

            while (reader8.Read())
            {
                data2.Add(new string[2]);
                data2[data2.Count - 1][0] = reader8[0].ToString();
                data2[data2.Count - 1][1] = reader8[1].ToString();

            }
            foreach (string[] s in data2)
            {
                dataGridView9.Rows.Add(s);
            }
            sqlConnection.Close();
            /////////////////////////////////////////////////////////////////////////////////////////////

            dataGridView11.Rows.Clear();
            sqlConnection.Open();
            GuestClass g1 = new GuestClass();
            g1.DiseaseG(richTextBox1, comboBox1);
            dataGridView11.Visible = true;
            string query = "Select NameMedicine, FormName, NameManufacturer From((((Disease inner join Therapy on Disease.ID_Disease = Therapy.ID_Disease) inner join Medicine on Therapy.ID_Medicine = Medicine.ID_Medicine) inner join MedicineForms on Medicine.ID_Medicine = MedicineForms.ID_Medicine) inner join Forms on MedicineForms.ID_Form = Forms.ID_Form)  inner join Manufacturer on MedicineForms.ID_Manufacturer = Manufacturer.ID_Manufacturer where NameDisease ='" + comboBox1.Text + "' ";
            List<string[]> data = new List<string[]>();
            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                data.Add(new string[3]);
                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();

            }
            foreach (string[] s in data)
            {
                dataGridView11.Rows.Add(s);
            }
            sqlConnection.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            GuestClass g = new GuestClass();
            g.FormsG(richTextBox2, comboBox2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView6.Rows.Clear();
            GuestClass g = new GuestClass();
            g.ManufacturerG(richTextBox3, comboBox3);
            sqlConnection.Open();
            dataGridView6.Visible = true;
            string query3 = "Select NameManufacturer, NameMedicine From(Manufacturer inner join MedManufacturer on Manufacturer.ID_Manufacturer = MedManufacturer.ID_Manufacturer) inner join Medicine on  MedManufacturer.ID_Medicine = Medicine.ID_Medicine where NameManufacturer ='" + comboBox3.Text + "' Group by Manufacturer.NameManufacturer, Medicine.NameMedicine";
            List<string[]> data3 = new List<string[]>();
            SqlCommand command3 = new SqlCommand(query3, sqlConnection);
            SqlDataReader reader9 = command3.ExecuteReader();

            while (reader9.Read())
            {
                data3.Add(new string[2]);
                data3[data3.Count - 1][0] = reader9[0].ToString();
                data3[data3.Count - 1][1] = reader9[1].ToString();

            }
            foreach (string[] s in data3)
            {
                dataGridView6.Rows.Add(s);
            }
            sqlConnection.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            GuestClass g = new GuestClass();
            g.MedicineG(richTextBox4, comboBox4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select NameDisease from (Disease inner join Symptom_Disease on Disease.ID_Disease = Symptom_Disease.ID_DIsease) inner join Symptom on Symptom_Disease.ID_Symptom = Symptom.ID_Symptom where '" + comboBox5.Text.ToString() + "' in (Select NameSymptom from Symptom_Disease as SD inner join Symptom on Symptom_Disease.ID_Symptom = Symptom.ID_Symptom where Symptom_Disease.ID_Disease = SD.ID_Disease) group by Disease.ID_Disease, NameDisease", sqlConnection);
            sqlConnection.Open();
            cmd.Parameters.AddWithValue("@NameSymptom", comboBox5.Text);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();


            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            comboBox6.Items.Clear();
            while (reader.Read()) 
            {
                comboBox6.Items.Add(reader["NameDisease"]);
            }
            sqlConnection.Close();

            //////////////////////////////////////////////////////////////////////
           

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView7.Rows.Clear();
            sqlConnection.Open();
            GuestClass g = new GuestClass();
            g.DiseaseG(richTextBox1, comboBox1);
            dataGridView7.Visible = true;
            string query2 = "Select NameDisease, NameMedicine From(Disease inner join Therapy on Disease.ID_Disease = Therapy.ID_Disease) inner join Medicine on Therapy.ID_Medicine = Medicine.ID_Medicine where NameDisease ='" + comboBox6.Text + "' Group by Disease.NameDisease, Medicine.NameMedicine";
            List<string[]> data2 = new List<string[]>();
            SqlCommand command2 = new SqlCommand(query2, sqlConnection);
            SqlDataReader reader8 = command2.ExecuteReader();

            while (reader8.Read())
            {
                data2.Add(new string[2]);
                data2[data2.Count - 1][0] = reader8[0].ToString();
                data2[data2.Count - 1][1] = reader8[1].ToString();

            }
            foreach (string[] s in data2)
            {
                dataGridView7.Rows.Add(s);
            }
            sqlConnection.Close();

            ///////////////////////////////
            dataGridView10.Rows.Clear();

            sqlConnection.Open();
           
            g.DiseaseG(richTextBox5, comboBox6);
            dataGridView10.Visible = true;
            string query3 = "Select NameDisease, NameSymptom From(Disease inner join Symptom_Disease on Disease.ID_Disease = Symptom_Disease.ID_Disease) inner join Symptom on Symptom_Disease.ID_Symptom = Symptom.ID_Symptom where NameDisease ='" + comboBox6.Text + "' Group by Disease.NameDisease, NameSymptom";
            List<string[]> data3 = new List<string[]>();
            SqlCommand command3 = new SqlCommand(query3, sqlConnection);
            SqlDataReader reader9 = command3.ExecuteReader();

            while (reader9.Read())
            {
                data3.Add(new string[2]);
                data3[data3.Count - 1][0] = reader9[0].ToString();
                data3[data3.Count - 1][1] = reader9[1].ToString();

            }
            foreach (string[] s in data3)
            {
                dataGridView10.Rows.Add(s);
            }
            sqlConnection.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GuestClass g = new GuestClass();
            g.SymptomG(richTextBox6, comboBox7);
            
        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}