using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CODE_PROJECT
{
    public partial class Registration : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\s110383\source\repos\CODE PROJECT\Database.mdf"";Integrated Security=True";

        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            // Optional initialization code can go here if needed
            // For now, we'll leave it empty but keep the method
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtusername.Text) ||
                string.IsNullOrWhiteSpace(txtpassword.Text) ||
                string.IsNullOrWhiteSpace(txtconfirmpassword.Text))
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtpassword.Text != txtconfirmpassword.Text)
            {
                MessageBox.Show("Passwords must match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();

                    // Check if username exists
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM LoginTable WHERE username = @username", cn))
                    {
                        cmd.Parameters.AddWithValue("@username", txtusername.Text);
                        int existingUserCount = (int)cmd.ExecuteScalar();

                        if (existingUserCount > 0)
                        {
                            MessageBox.Show("Username already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Insert new user and retrieve userId
                    int userId;
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO LoginTable (username, password) OUTPUT INSERTED.userId VALUES (@username, @password)", cn))
                    {
                        cmd.Parameters.AddWithValue("@username", txtusername.Text);
                        cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                        userId = (int)cmd.ExecuteScalar();
                    }

                    MessageBox.Show("Account created successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Home home = new Home(userId);
                    home.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}