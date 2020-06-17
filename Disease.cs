using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlTypes;
namespace WindowsFormsApp3
{

    class Disease
    {

        public static string connectionString = @"Data Source=DESKTOP-JEBEHPQ\SQLEXPRESS01;Initial Catalog=Kurs_DB;Integrated Security=True";
        public static SqlConnection sqlConnection = new SqlConnection(connectionString);
        public static SqlCommand cmd;


        public void DiseaseLoad(DataGridView dgv)
        {   
            sqlConnection.Open();
            string query = "select NameDIsease, DiseaseInfo from Disease ";
            List<string[]> data = new List<string[]>();
            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                data.Add(new string[2]);
                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
             
            }
            foreach (DataGridViewRow row in dgv.Rows)
            {
                dgv.SelectedRows.Clear();
                row.Selected = true;
            }
            sqlConnection.Close();
        }

        public void DiseaseLoadGuest(DataGridView dgv)
        {
            sqlConnection.Open();
            string query = "select NameDisease from Disease ";
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

        public void InsertDisease(TextBox tb1,TextBox tb2, DataGridView dgv)
        {
            cmd = new SqlCommand("insert into Disease(NameDisease, DiseaseInfo) values(@NameDisease, @DiseaseInfo)", sqlConnection);
            sqlConnection.Open();

            cmd.Parameters.AddWithValue("@NameDisease", tb1.Text);
            cmd.Parameters.AddWithValue("@DiseaseInfo", tb2.Text);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Record Inserted Successfully");

            dgv.Rows.Clear();
            sqlConnection.Open();
            string query = "select NameDisease, DiseaseInfo from Disease ";
            List<string[]> data = new List<string[]>();
            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                data.Add(new string[2]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
  
            }
            foreach (string[] s in data)
            {
                dgv.Rows.Add(s);
            }
            sqlConnection.Close();

            sqlConnection.Close();

            //////////////////////////////////////////////////////////////////////////////////////////
           
        }

        public void UpdateDisease(ComboBox tb1, TextBox tb2, TextBox tb3, DataGridView dgv)
        {

            string[] sq = tb1.Text.Split(new char[] {'.'});
            for (int i = 0; i < sq.Length; ++i)
            {
                cmd = new SqlCommand("update Disease set NameDisease=@NameDisease, DiseaseInfo = @DiseaseInfo where ID_Disease = @ID_Disease", sqlConnection);
                sqlConnection.Open();

             
                cmd.Parameters.AddWithValue("@ID_Disease", sq[0]);
                cmd.Parameters.AddWithValue("@NameDisease", tb2.Text);
                cmd.Parameters.AddWithValue("@DiseaseInfo", tb3.Text);

                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Record Updated Successfully");

                dgv.Rows.Clear();
                sqlConnection.Open();
                string query = "select NameDisease, DiseaseInfo from Disease order by ID_Disease";
                List<string[]> data = new List<string[]>();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    data.Add(new string[2]);

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

        public void DeleteDisease(ComboBox tb1, DataGridView dgv)
        {
            string[] sq = tb1.Text.Split(new char[] { '.' });
            for (int i = 0; i < sq.Length; ++i)
            {
                cmd = new SqlCommand("delete from Disease where  ID_DIsease = @ID_DIsease", sqlConnection);
                sqlConnection.Open();
                cmd.Parameters.AddWithValue("@ID_Disease", sq[0]);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Record Deleted Successfully!");

                dgv.Rows.Clear();
                sqlConnection.Open();
                string query = "select * from Disease";
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
