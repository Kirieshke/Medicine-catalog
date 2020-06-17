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
    public partial class Medicine_for_Disease : Form
    {
        public static string connectionString = @"Data Source=DESKTOP-JEBEHPQ\SQLEXPRESS01;Initial Catalog=Kurs_DB;Integrated Security=True";
        public static SqlConnection sqlConnection = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand();
        public Medicine_for_Disease()
        {
            InitializeComponent();
        }

        private void Medicine_for_Disease_Load(object sender, EventArgs e)
        {
            sqlConnection.Open();
            string query2 = "select NameDisease, count(Medicine.ID_Medicine) from (Disease inner join Therapy on Disease.ID_Disease = Therapy.ID_Disease) inner join Medicine on Therapy.ID_Medicine = Medicine.ID_Medicine Group by NameDisease";
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
            string query = "select NameDisease, count(Medicine.ID_Medicine) from (Disease inner join Therapy on Disease.ID_Disease = Therapy.ID_Disease) inner join Medicine on Therapy.ID_Medicine = Medicine.ID_Medicine Group by NameDisease";
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
            ay.Title = "Количество Лекарств";
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
