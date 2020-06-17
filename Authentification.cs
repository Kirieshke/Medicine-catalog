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

namespace WindowsFormsApp3
{
    public partial class Authentification : Form
    {
        public Authentification()
        {
            InitializeComponent();
        }

        private void Authentification_Load(object sender, EventArgs e)
        {  
            int ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
            int ScreenHeight = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point((ScreenWidth / 2) - (this.Width / 2), (ScreenHeight / 2) - (this.Height / 2));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-JEBEHPQ\SQLEXPRESS01;Initial Catalog=Kurs_DB;Integrated Security=True");
            SqlDataAdapter adapt = new SqlDataAdapter("Select Role From Registration Where Username = '" + textBox1.Text + "' and Password ='" + textBox2.Text + "' ", sqlConnection);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            try
            {
                if (dt.Rows[0][0].ToString() == "Admin")
                {
                    this.Hide();
                    Admin admin = new Admin();
                    admin.Show();
                }
                else if (dt.Rows[0][0].ToString() == "Guest")
                {
                    this.Hide();
                    Guest guest = new Guest();
                    guest.Show();
                }
                else if (dt.Rows[0][0].ToString() == "Analyst")
                {
                    this.Hide();
                    AnalystMen am = new AnalystMen();
                    am.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неправильное имя пользователя или пароль");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }
    }
}
