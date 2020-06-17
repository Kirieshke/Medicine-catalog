using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public class Manufacturer
    {
        public static string connectionString = @"Data Source=DESKTOP-JEBEHPQ\SQLEXPRESS01;Initial Catalog=Kurs_DB;Integrated Security=True";
        public static SqlConnection sqlConnection = new SqlConnection(connectionString);
        public static SqlCommand cmd;
        public static SqlDataAdapter adapt;
        public void ManufacturerLoad(DataGridView dgv)
        {
            sqlConnection.Open();
            string query2 = "select NameManufacturer, Country, InfoManufacturer from Manufacturer ";
            List<string[]> data2 = new List<string[]>();
            SqlCommand command2 = new SqlCommand(query2, sqlConnection);
            SqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                data2.Add(new string[3]);

                data2[data2.Count - 1][0] = reader2[0].ToString();
                data2[data2.Count - 1][1] = reader2[1].ToString();
                data2[data2.Count - 1][2] = reader2[2].ToString();
            }
            reader2.Close();
            foreach (string[] s in data2)
            {
                dgv.Rows.Add(s);
            }
            sqlConnection.Close();
        }

        public void ManGuestLoad(DataGridView dgv)
        {
            sqlConnection.Open();
            string query = "select NameManufacturer from Manufacturer ";
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

        public void InsertManufacturer(TextBox tb1, TextBox tb2, TextBox tb3, DataGridView dgv)
        {
            cmd = new SqlCommand("insert into Manufacturer(NameManufacturer,Country, InfoManufacturer) values(@NameManufacturer,@Country, @InfoManufacturer)", sqlConnection);
            sqlConnection.Open();
            cmd.Parameters.AddWithValue("@NameManufacturer", tb1.Text);
            cmd.Parameters.AddWithValue("@Country", tb2.Text);
            cmd.Parameters.AddWithValue("@InfoManufacturer", tb3.Text);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Record Inserted Successfully");

            dgv.Rows.Clear();
            sqlConnection.Open();
            string query = "select * from Manufacturer ";
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
                dgv.Rows.Add(s);
            }
            sqlConnection.Close();

            sqlConnection.Close();
        }
        public void UpdateManufacturer(ComboBox tb1, TextBox tb2, TextBox tb3, TextBox tb4, DataGridView dgv)
        {
            string[] sq = tb1.Text.Split(new char[] { '.' });
            for (int i = 0; i < sq.Length; ++i)
            {
                cmd = new SqlCommand("update Manufacturer set NameManufacturer=@NameManufacturer, Country = @Country, InfoManufacturer = @InfoManufacturer where ID_Manufacturer = @ID_Manufacturer", sqlConnection);
            sqlConnection.Open();
                cmd.Parameters.AddWithValue("@ID_Manufacturer", sq[0]);
                cmd.Parameters.AddWithValue("@NameManufacturer", tb2.Text);
                cmd.Parameters.AddWithValue("@Country", tb3.Text);
                cmd.Parameters.AddWithValue("@InfoManufacturer", tb4.Text); 

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Record Updated Successfully");

            dgv.Rows.Clear();
            sqlConnection.Open();
            string query = "select * from Manufacturer";
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
                dgv.Rows.Add(s);
            }
            sqlConnection.Close();
            sqlConnection.Close();
            }
        }
        public void DeleteManufacturer(ComboBox tb1, DataGridView dgv)
        {
            string[] sq = tb1.Text.Split(new char[] { '.' });
            for (int i = 0; i < sq.Length; ++i)
            {
                cmd = new SqlCommand("delete from Manufacturer where ID_Manufacturer=@ID_Manufacturer", sqlConnection);
                sqlConnection.Open();
                cmd.Parameters.AddWithValue("@ID_Manufacturer ", sq[0]);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Record Deleted Successfully!");

                dgv.Rows.Clear();
                sqlConnection.Open();
                string query = "select * from Manufacturer";
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
                    dgv.Rows.Add(s);
                }
                sqlConnection.Close();
            }
        }
    }
}
