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
using System.Windows.Forms.DataVisualization.Charting;
namespace WindowsFormsApp3
{
    public partial class Count_Symptom : Form
    {
        public static string connectionString = @"Data Source=192.168.0.101;Initial Catalog=Kurs_DB;User ID=test;Password=2222";
        public static SqlConnection sqlConnection = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand();
        public Count_Symptom()
        {
            InitializeComponent();
        }

        private void Count_Symptom_Load(object sender, EventArgs e)
        {
            sqlConnection.Open();
            string query2 = "select NameDisease, count(Symptom.ID_Symptom) From (Disease inner join Symptom_Disease on Disease.ID_Disease = Symptom_Disease.ID_Disease) inner join Symptom on Symptom_Disease.ID_Symptom = Symptom.ID_Symptom  Group by NameDisease";
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
                dataGridView1.Rows.Add(s);
            }
            sqlConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select NameDisease, count(Symptom.ID_Symptom) From(Disease inner join Symptom_Disease on Disease.ID_Disease = Symptom_Disease.ID_Disease) inner join Symptom on Symptom_Disease.ID_Symptom = Symptom.ID_Symptom  Group by NameDisease";
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sda.Fill(dt);

            sqlConnection.Close();

            chart1.Series.Add("Количество");
            chart1.Series["Количество"].Points.Clear();
            int count;
            string Name;
            Axis ax = new Axis();
            ax.Title = "Болезнь";
            chart1.ChartAreas[0].AxisX = ax;
            Axis ay = new Axis();
            ay.Title = "Количество Симптомов";
            chart1.ChartAreas[0].AxisY = ay;

            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                count = dt.Rows[i].Field<int>(1);
                Name = dt.Rows[i].Field<string>(0);
                chart1.Series["Количество"].Points.AddXY(Name.ToString(), count.ToString());
            }
        }
    }
}
