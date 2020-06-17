using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp3
{
        public class Medicine
        {
        public static string connectionString = @"Data Source=DESKTOP-JEBEHPQ\SQLEXPRESS01;Initial Catalog=Kurs_DB;Integrated Security=True";
        public static SqlConnection sqlConnection = new SqlConnection(connectionString);
        public static SqlCommand cmd;
        public static SqlDataAdapter adapt;
            public void MedicineLoad(DataGridView dgv)
            {
                sqlConnection.Open();
                string query3 = "select NameMedicine, InfoMedicine from Medicine ";
                List<string[]> data3 = new List<string[]>();
                SqlCommand command3 = new SqlCommand(query3, sqlConnection);
                SqlDataReader reader3 = command3.ExecuteReader();
                while (reader3.Read())
                {
                    data3.Add(new string[3]);

                    data3[data3.Count - 1][0] = reader3[0].ToString();
                    data3[data3.Count - 1][1] = reader3[1].ToString();

                }

                reader3.Close();

                foreach (string[] s in data3)
                {
                    dgv.Rows.Add(s);
                }
                sqlConnection.Close();
            }

        public void MedGuestLoad(DataGridView dgv)
        {
            sqlConnection.Open();
            string query = "select NameMedicine from Medicine ";
            List<string[]> data = new List<string[]>();
            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                data.Add(new string[1]);

                data[data.Count - 1][0] = reader[0].ToString();

            }
            foreach (string[] s in data)
            {
                dgv.Rows.Add(s);
            }
            sqlConnection.Close();
        }

        public void InsertMedicine(TextBox tb1, TextBox tb2, DataGridView dgv)
        {
            cmd = new SqlCommand("insert into Medicine(NameMedicine, InfoMedicine) values(@NameMedicine, @InfoMedicine)", sqlConnection);
            sqlConnection.Open();
            cmd.Parameters.AddWithValue("@NameMedicine", tb1.Text);
            cmd.Parameters.AddWithValue("InfoMedicine", tb2.Text);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Record Inserted Successfully");

            dgv.Rows.Clear();
            sqlConnection.Open();
            string query = "select * from Medicine ";
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
        public void UpdateMedicine(ComboBox tb1, TextBox tb2, TextBox tb3, DataGridView dgv)
            {
            string[] sq = tb1.Text.Split(new char[] { '.' });
            for (int i = 0; i < sq.Length; ++i)
            {
                cmd = new SqlCommand("update Medicine set NameMedicine=@NameMedicine, InfoMedicine = @InfoMedicine where ID_Medicine = @ID_Medicine", sqlConnection);
                sqlConnection.Open();
                cmd.Parameters.AddWithValue("@ID_Medicine", sq[0]);
                cmd.Parameters.AddWithValue("@NameMedicine", tb2.Text);
                cmd.Parameters.AddWithValue("@InfoMedicine", tb3.Text);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Record Updated Successfully");

                dgv.Rows.Clear();
                sqlConnection.Open();
                string query = "select * from Medicine";
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
            public void DeleteMedicine(ComboBox tb1, DataGridView dgv)
            {
            string[] sq = tb1.Text.Split(new char[] { '.' });
            for (int i = 0; i < sq.Length; ++i)
            {
                cmd = new SqlCommand("delete from Medicine where ID_Medicine=@ID_Medicine", sqlConnection);
                sqlConnection.Open();
                cmd.Parameters.AddWithValue("@ID_Medicine ", sq[0]);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Record Deleted Successfully!");

                dgv.Rows.Clear();
                sqlConnection.Open();
                string query = "select * from Medicine";
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

