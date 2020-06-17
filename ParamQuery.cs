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
    public partial class ParamQuery : Form
    {
        public static string connectionString = @"Data Source=192.168.0.101;Initial Catalog=Kurs_DB;User ID=test;Password=2222";
        public static SqlConnection sqlConnection = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand();
        public ParamQuery()
        {
            InitializeComponent();
        }

        private void ParamQuery_Load(object sender, EventArgs e)
        {
            cmd.CommandText = "Select FormName From Forms";
            cmd.Connection = sqlConnection;

            sqlConnection.Open();
            SqlDataReader reader5 = cmd.ExecuteReader();
            while (reader5.Read())
            {
                comboBox1.Items.Add(reader5["FormName"]);

            }
            reader5.Close();
            sqlConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            string query2 = "select NameManufacturer,  COUNT(ID_Medicine) From (Manufacturer inner join MedicineForms on Manufacturer.ID_Manufacturer = MedicineForms.ID_Manufacturer) inner join Forms on MedicineForms.ID_Form = Forms.ID_Form Where FormName = '"+ comboBox1.Text + "' Group by NameManufacturer, FormName";

      
            SqlCommand cmd = new SqlCommand(query2, sqlConnection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sda.Fill(dt);

            sqlConnection.Close();

            chart1.Series.Clear();
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
