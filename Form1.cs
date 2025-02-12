using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CODE_PROJECT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       // private SqlConnection cn; // Declare as a class-level field
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\s110383\source\repos\CODE PROJECT\Database.mdf"";Integrated Security=True";

        private void Form1_Load(object sender, EventArgs e)
        {
           // SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\s110383\source\repos\CODE PROJECT\Database.mdf"";Integrated Security=True");
           // cn.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration registration = new Registration();
            registration.ShowDialog();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtpassword.Text != string.Empty || txtusername.Text != string.Empty)
            {
                using (SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\s110383\source\repos\CODE PROJECT\Database.mdf"";Integrated Security=True")) // Use using statement
                {
                    cn.Open(); // Open connection inside the using block

                    using (SqlCommand cmd = new SqlCommand("select * from LoginTable where username='" + txtusername.Text + "' and password='" + txtpassword.Text + "'", cn)) // Use using statement
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader()) // Use using statement
                        {
                            if (dr.Read())
                            {
                                this.Hide();
                                Home home = new Home();
                                home.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("No Account avilable with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        } // dr is closed automatically here
                    } // cmd is disposed automatically here
                } // cn is closed automatically here
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
