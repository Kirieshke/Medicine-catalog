using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;
namespace WindowsFormsApp3
{
    public partial class AnalystMen : Form
    {
        public static string connectionString = @"Data Source=192.168.0.101;Initial Catalog=Kurs_DB;User ID=test;Password=2222";
        public static SqlConnection sqlConnection = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand();
        public AnalystMen()
        {
            InitializeComponent();
        }

        private void AnalystMen_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Count_Medicine c = new Count_Medicine();
            c.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Count_Symptom count = new Count_Symptom();
            count.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Medicine_for_Disease m = new Medicine_for_Disease();
            m.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ParamQuery param = new ParamQuery();
            param.Show();
        }
    }
}
