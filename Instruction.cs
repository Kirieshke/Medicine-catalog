using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    class Instruction
    {
        public static string connectionString = @"Data Source=DESKTOP-JEBEHPQ\SQLEXPRESS01;Initial Catalog=Kurs_DB;Integrated Security=True";
        public static SqlConnection sqlConnection = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand();
        public void InsertInstruction(TextBox tb1, DataGridView dgv)
        {
            cmd = new SqlCommand("insert into MedicineForms(NameDisease) values(@NameDisease)", sqlConnection);
            sqlConnection.Open();


            cmd.Parameters.AddWithValue("@NameDisease", tb1.Text);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Record Inserted Successfully");

            dgv.Rows.Clear();
            sqlConnection.Open();
            string query = "select * from Disease ";
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
}