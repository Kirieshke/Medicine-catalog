using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace WindowsFormsApp3
{
    public class Symptom
    {

        public static string connectionString = @"Data Source=DESKTOP-JEBEHPQ\SQLEXPRESS01;Initial Catalog=Kurs_DB;Integrated Security=True";
        public static SqlConnection sqlConnection = new SqlConnection(connectionString);
        public static SqlCommand cmd;

        public void SymptomLoad(DataGridView dgv)
        {
            sqlConnection.Open();
            string query4 = "select NameSymptom, SymptomInfo from Symptom ";
            List<string[]> data4 = new List<string[]>();
            SqlCommand command4 = new SqlCommand(query4, sqlConnection);
            SqlDataReader reader4 = command4.ExecuteReader();
            while (reader4.Read())
            {
                data4.Add(new string[2]);

                data4[data4.Count - 1][0] = reader4[0].ToString();
                data4[data4.Count - 1][1] = reader4[1].ToString();
            }

            reader4.Close();

            foreach (string[] s in data4)
            {
                dgv.Rows.Add(s);
            }
            sqlConnection.Close();
        }
        public void InsertSymptom(TextBox tb1,TextBox tb2, DataGridView dgv)
        {
            cmd = new SqlCommand("insert into Symptom(NameSymptom, SymptomInfo) values(@NameSymptom, @SymptomInfo)", sqlConnection);
            sqlConnection.Open();

            cmd.Parameters.AddWithValue("@NameSymptom", tb1.Text);
            cmd.Parameters.AddWithValue("@SymptomInfo", tb2.Text);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Record Inserted Successfully");

            dgv.Rows.Clear();
            sqlConnection.Open();
            string query = "select * from Symptom";
            List<string[]> data = new List<string[]>();
            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                data.Add(new string[3]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();

            }
            foreach (string[] s in data)
            {
                dgv.Rows.Add(s);
            }
            sqlConnection.Close();

            sqlConnection.Close();
        }
        public void UpdateSymptom(ComboBox tb1, TextBox tb2, TextBox tb3, DataGridView dgv)
        {
            string[] sq = tb1.Text.Split(new char[] { '.' });
            for (int i = 0; i < sq.Length; ++i)
            {
                cmd = new SqlCommand("update Symptom set NameSymptom=@NameSymptom, SymptomInfo = @SymptomInfo where ID_Symptom = @ID_Symptom", sqlConnection);
            sqlConnection.Open();
                cmd.Parameters.AddWithValue("@ID_Symptom", sq[0]);
                cmd.Parameters.AddWithValue("@NameSymptom", tb2.Text);
                cmd.Parameters.AddWithValue("@SymptomInfo", tb3.Text);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Record Updated Successfully");

            dgv.Rows.Clear();
            sqlConnection.Open();
            string query = "select * from Symptom";
            List<string[]> data = new List<string[]>();
            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                data.Add(new string[3]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();

            }
            foreach (string[] s in data)
            {
                dgv.Rows.Add(s);
            }
            sqlConnection.Close();
            sqlConnection.Close();
        }
        }
        public void DeleteSymptom(ComboBox tb1, DataGridView dgv)
        {
            string[] sq = tb1.Text.Split(new char[] { '.' });
            for (int i = 0; i < sq.Length; ++i)
            {
                cmd = new SqlCommand("delete from Symptom where ID_Symptom=@ID_Symptom", sqlConnection);
                sqlConnection.Open();
                cmd.Parameters.AddWithValue("@ID_Symptom ", sq[0]);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Record Deleted Successfully!");

                dgv.Rows.Clear();
                sqlConnection.Open();
                string query = "select * from Symptom";


                List<string[]> data = new List<string[]>();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    data.Add(new string[3]);

                    data[data.Count - 1][0] = reader[0].ToString();
                    data[data.Count - 1][1] = reader[1].ToString();

                }
                foreach (string[] s in data)
                {
                    dgv.Rows.Add(s);
                }
                sqlConnection.Close();
            }
        }
    }
}
