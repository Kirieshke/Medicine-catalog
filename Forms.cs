using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace WindowsFormsApp3
{
    public class Forms
    {
        public static string connectionString = @"Data Source=DESKTOP-JEBEHPQ\SQLEXPRESS01;Initial Catalog=Kurs_DB;Integrated Security=True";
        public static SqlConnection sqlConnection = new SqlConnection(connectionString);
        public static SqlCommand cmd;
        public static SqlDataAdapter adapt;
        public void FormsLoad(DataGridView dgv)
        {
            sqlConnection.Open();
            string query1 = "select FormName, FormInfo from Forms ";
            List<string[]> data1 = new List<string[]>();
            SqlCommand command1 = new SqlCommand(query1, sqlConnection);
            SqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                data1.Add(new string[2]);

                data1[data1.Count - 1][0] = reader1[0].ToString();
                data1[data1.Count - 1][1] = reader1[1].ToString();

            }

            reader1.Close();

            foreach (string[] s in data1)
            {
                dgv.Rows.Add(s);
            }
            sqlConnection.Close();
        }

        public void FormGuestLoad(DataGridView dgv)
        {
            sqlConnection.Open();
            string query = "select FormName from Forms ";
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
        public void InsertForms(TextBox tb1, TextBox tb2, DataGridView dgv)
        {
            try
            {
                cmd = new SqlCommand("insert into Forms(FormName, FormInfo) values(@FormName, @FormInfo)", sqlConnection);
                sqlConnection.Open();
                cmd.Parameters.AddWithValue("@FormName", tb1.Text);
                cmd.Parameters.AddWithValue("@FormInfo", tb2.Text);
                cmd.ExecuteNonQuery();
            }
            catch(SqlException)
            {
                MessageBox.Show("Произошёл шрекс"); 
            }
            
            sqlConnection.Close();
            MessageBox.Show("Record Inserted Successfully");

            dgv.Rows.Clear();
            sqlConnection.Open();
            string query = "select * from Forms ";
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
        public void UpdateForms(ComboBox tb1, TextBox tb2,TextBox tb3, DataGridView dgv)
        {
            try
            {
                string[] sq = tb1.Text.Split(new char[] { '.' });
                for (int i = 0; i < sq.Length; ++i)
                {
                    cmd = new SqlCommand("update Forms set FormName=@FormName, FormInfo = @FormInfo where ID_Form = @ID_Form", sqlConnection);
                    sqlConnection.Open();
                    cmd.Parameters.AddWithValue("@ID_Form", sq[0]);
                    cmd.Parameters.AddWithValue("@FormName", tb2.Text);
                    cmd.Parameters.AddWithValue("@FormInfo", tb3.Text);
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("Record Updated Successfully");

                    dgv.Rows.Clear();
                    sqlConnection.Open();
                    string query = "select * from Forms";
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
            catch
            {
                MessageBox.Show("Произошел Шрекс");
            }
        }
        public void DeleteForms(ComboBox tb1, DataGridView dgv)
        {
            string[] sq = tb1.Text.Split(new char[] { '.' });
            for (int i = 0; i < sq.Length; ++i)
            {
                cmd = new SqlCommand("delete from Forms where ID_Form=@ID_Form", sqlConnection);
                sqlConnection.Open();
                cmd.Parameters.AddWithValue("@ID_Form ", sq[0]);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Record Deleted Successfully!");

                dgv.Rows.Clear();
                sqlConnection.Open();
                string query = "select * from Forms";
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
