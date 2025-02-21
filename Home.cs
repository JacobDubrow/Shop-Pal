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
    public partial class Home : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\s110383\source\repos\CODE PROJECT\Database.mdf"";Integrated Security=True";
        private List<ShoppingList> shoppingLists = new List<ShoppingList>();

        public Home()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            InitializeUI();
            LoadShoppingListsIntoDomainUpDown();
        }

        private void LoadShoppingListsIntoDomainUpDown()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT listName FROM ShoppingList ORDER BY listName", conn))
                    {
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

        private void InitializeUI()
        {

        }

        private void CreateList_Click(object sender, EventArgs e)
        {
            using (var createListForm = new CreateNewListForm())
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
                    using (SqlCommand cmd = new SqlCommand("SELECT listID, listName, createdBy FROM ShoppingList", conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var list = new ShoppingList
                                {
                                    listID = reader["listID"].ToString(),
                                    listName = reader["listName"].ToString(),
                                    createdBy = reader["createdBy"].ToString()
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
                // Here you can add code to handle when a different list is selected
                // For now, we'll just show which list is selected
                // MessageBox.Show($"Selected list: {selectedListName}");
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
                    using (SqlCommand cmd = new SqlCommand("SELECT listID, listName FROM ShoppingList WHERE listName = @listName", conn))
                    {
                        cmd.Parameters.AddWithValue("@listName", selectedListName);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Get the list details
                                string listID = reader["listID"].ToString();
                                string listName = reader["listName"].ToString();

                                // Open the ListView form with the specific listID and listName
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
            public string createdBy { get; set; }
        }
    }
}