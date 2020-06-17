using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public class GuestClass
    {
        public static string connectionString = @"Data Source=DESKTOP-JEBEHPQ\SQLEXPRESS01;Initial Catalog=Kurs_DB;Integrated Security=True";
        public static SqlConnection sqlConnection = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand();

        public void DiseaseG(RichTextBox rtb1, ComboBox cb1)
        {
            cmd = new SqlCommand("Select DiseaseInfo from Disease where NameDisease = @NameDisease", sqlConnection);
            sqlConnection.Open();
            cmd.Parameters.AddWithValue("@NameDisease", cb1.Text);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();

            sqlConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                rtb1.Text = reader["DiseaseInfo"].ToString();
            }

            sqlConnection.Close();
        }

        public void FormsG(RichTextBox rtb1, ComboBox cb1)
        {
            cmd = new SqlCommand("Select FormInfo from Forms where FormName = @FormName", sqlConnection);
            sqlConnection.Open();
            cmd.Parameters.AddWithValue("@FormName", cb1.Text);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();

            sqlConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                rtb1.Text = reader["FormInfo"].ToString();
            }

            sqlConnection.Close();
        }

        public void ManufacturerG(RichTextBox rtb1, ComboBox cb1)
        {
            cmd = new SqlCommand("Select InfoManufacturer from Manufacturer where NameManufacturer = @NameManufacturer", sqlConnection);
            sqlConnection.Open();
            cmd.Parameters.AddWithValue("@NameManufacturer", cb1.Text);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();

            sqlConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                rtb1.Text = reader["InfoManufacturer"].ToString();
            }

            sqlConnection.Close();
        }

        public void MedicineG(RichTextBox rtb1, ComboBox cb1)
        {
            cmd = new SqlCommand("Select InfoMedicine from Medicine where NameMedicine = @NameMedicine", sqlConnection);
            sqlConnection.Open();
            cmd.Parameters.AddWithValue("@NameMedicine", cb1.Text);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();

            sqlConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                rtb1.Text = reader["InfoMedicine"].ToString();
            }

            sqlConnection.Close();
        }

        public void SymptomG(RichTextBox tb1, ComboBox cb1)
        {
            cmd = new SqlCommand("Select SymptomInfo from Symptom where NameSymptom = @NameSymptom", sqlConnection);
            sqlConnection.Open();
            cmd.Parameters.AddWithValue("@NameSymptom", cb1.Text);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();

            sqlConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tb1.Text = reader["SymptomInfo"].ToString();
            }

            sqlConnection.Close();

        }
        public void Diagnoz(RichTextBox tb1, ComboBox c3)
        {

        }
    }
}

