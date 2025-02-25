using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CODE_PROJECT
{
    public partial class Home : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\s110383\source\repos\CODE PROJECT\Database.mdf"";Integrated Security=True";
        private List<ShoppingList> shoppingLists = new List<ShoppingList>();
        private int userId;

        public Home(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            LoadShoppingListsIntoDomainUpDown();
        }

        private void LoadShoppingListsIntoDomainUpDown()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT listName FROM ShoppingList WHERE userId=@userId ORDER BY listName", conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            ListList.Items.Clear();

                            while (reader.Read())
                            {
                                ListList.Items.Add(reader["listName"].ToString());
                            }

                            if (ListList.Items.Count > 0)
                            {
                                ListList.SelectedIndex = 0;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading shopping lists: {ex.Message}");
            }
        }

        private void CreateList_Click(object sender, EventArgs e)
        {
            using (var createListForm = new CreateNewListForm(userId))
            {
                if (createListForm.ShowDialog() == DialogResult.OK)
                {
                    ShoppingList newList = createListForm.CreatedList;
                    shoppingLists.Add(newList);
                    RefreshListDisplay();
                }
            }
        }

        private void RefreshListDisplay()
        {
            ListList.Items.Clear();
            foreach (var list in shoppingLists)
            {
                ListList.Items.Add(list.listName);
            }
        }

        private void LoadShoppingLists()
        {
            shoppingLists.Clear();
            ListList.Items.Clear();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT listID, listName, userId FROM ShoppingList WHERE userId=@userId", conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var list = new ShoppingList
                                {
                                    listID = reader["listID"].ToString(),
                                    listName = reader["listName"].ToString(),
                                    userId = reader["userId"].ToString() // Ensure this is correct if the column name is 'userId'
                                };
                                shoppingLists.Add(list);
                                ListList.Items.Add(list.listName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading shopping lists: {ex.Message}");
            }
        }

        private void ListList_SelectedItemChanged(object sender, EventArgs e)
        {
            if (ListList.SelectedItem != null)
            {
                string selectedListName = ListList.SelectedItem.ToString();
            }
        }

        private void OpenList_Click(object sender, EventArgs e)
        {
            if (ListList.SelectedItem == null)
            {
                MessageBox.Show("Please select a list to open");
                return;
            }

            try
            {
                string selectedListName = ListList.SelectedItem.ToString();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT listID, listName FROM ShoppingList WHERE listName = @listName AND userId = @userId", conn))
                    {
                        cmd.Parameters.AddWithValue("@listName", selectedListName);
                        cmd.Parameters.AddWithValue("@userId", userId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string listID = reader["listID"].ToString();
                                string listName = reader["listName"].ToString();
                                ListView listView = new ListView(listID, listName, this);
                                listView.Show();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening list: {ex.Message}");
            }
        }



        public void RemoveListFromDomainUpDown(string listName)
        {
            ListList.Items.Remove(listName);
        }

        public class ShoppingList
        {
            public string listID { get; set; }
            public string listName { get; set; }
            public string userId { get; set; } // Ensure this is correct if the column name is 'userId'
        }

        private void JoinMessage_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To join a list, please enter the list key provided by the list owner within a list of your own.");
        }
    }
}