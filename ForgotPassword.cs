using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CODE_PROJECT
{
    public partial class ForgotPassword : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\s110383\source\repos\CODE PROJECT\Database.mdf"";Integrated Security=True";

        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void ForgotPassword_Load(object sender, EventArgs e)
        {

        }


        private void Submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter a username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT password FROM LoginTable WHERE username=@username", cn))
                    {
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                string password = dr["password"].ToString();
                                MessageBox.Show($"Your password is: {password}", "Password Retrieved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Username not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}