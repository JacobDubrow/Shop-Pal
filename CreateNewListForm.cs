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
using CODE_PROJECT;
using static CODE_PROJECT.Home;

namespace CODE_PROJECT
{
    public partial class CreateNewListForm : Form
    {
        private TextBox txtListName;
        private Button btnCreate;
        private Button btnCancel;
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\s110383\source\repos\CODE PROJECT\Database.mdf"";Integrated Security=True";
        private int userId;

        public ShoppingList CreatedList { get; private set; }

        public CreateNewListForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void CreateNewListForm_Load(object sender, EventArgs e)
        {
            SetupForm();
        }

        private void SetupForm()
        {
            this.Text = "Create New Shopping List";
            this.Size = new Size(300, 150);

            txtListName = new TextBox();
            txtListName.Location = new Point(10, 10);
            txtListName.Size = new Size(260, 20);

            btnCreate = new Button();
            btnCreate.Text = "Create";
            btnCreate.Location = new Point(10, 40);
            btnCreate.Click += BtnCreate_Click;

            btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Location = new Point(100, 40);
            btnCancel.Click += BtnCancel_Click;

            this.Controls.Add(txtListName);
            this.Controls.Add(btnCreate);
            this.Controls.Add(btnCancel);
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtListName.Text))
            {
                MessageBox.Show("Please enter a list name");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = @"INSERT INTO ShoppingList (listName, userId) 
                                            VALUES (@listName, @userId);
                                            SELECT SCOPE_IDENTITY();";

                        cmd.Parameters.AddWithValue("@listName", txtListName.Text.Trim());
                        cmd.Parameters.AddWithValue("@userId", userId);

                        int listId = Convert.ToInt32(cmd.ExecuteScalar());

                        CreatedList = new ShoppingList
                        {
                            listID = listId.ToString(),
                            listName = txtListName.Text.Trim()
                        };
                    }
                }

                MessageBox.Show("Shopping list created successfully!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating shopping list: {ex.Message}");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    // Updated ShoppingList class to match
}