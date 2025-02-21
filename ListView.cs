using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace CODE_PROJECT
{
    public partial class ListView : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\s110383\source\repos\CODE PROJECT\Database.mdf"";Integrated Security=True";
        private string _listID; // Store the listID
        private string _listName; // Store the listName
        private string jsonFilePath = "passkeys.json"; // Path to the JSON file
        private Home homeForm; // Reference to the Home form

        // Constructor that accepts the listID, listName, and Home form reference
        public ListView(string listID, string listName, Home homeForm)
        {
            InitializeComponent();
            _listID = listID; // Initialize the listID field
            _listName = listName; // Initialize the listName field
            this.Text = $"Shopping List - {_listName}"; // Set the form title
            this.homeForm = homeForm; // Initialize the Home form reference
            InitializeUI();
            InitializeJsonFile();
        }

        private void ListView_Load(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void LoadItems()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT ItemId, ItemName, Purchased FROM ListItemTable WHERE listID = @listID", conn))
                    {
                        cmd.Parameters.AddWithValue("@listID", _listID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            listBoxItems.Items.Clear();

                            while (reader.Read())
                            {
                                string itemId = reader["ItemId"].ToString();
                                string itemName = reader["ItemName"].ToString();
                                bool purchased = Convert.ToBoolean(reader["Purchased"]);

                                string displayString = $"{itemName} - Purchased: {purchased}";
                                listBoxItems.Items.Add(new ListItem { Id = itemId, DisplayString = displayString });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading items: {ex.Message}");
            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxItems.SelectedItem != null)
            {
                string selectedItem = listBoxItems.SelectedItem.ToString();

                // Parse the selectedItem (more robust parsing is recommended)
                string[] parts = selectedItem.Split(new string[] { " - Purchased: " }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2)
                {
                    string itemName = parts[0];
                    string purchased = parts[1];
                    // ... Do something with the extracted values ...
                    MessageBox.Show($"Selected Item:\nName: {itemName}\nPurchased: {purchased}");
                }
            }
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            string newItemName = Prompt.ShowDialog("Enter item name:", "Add Item");

            if (!string.IsNullOrEmpty(newItemName))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO ListItemTable (listID, ItemName, Purchased) VALUES (@listID, @ItemName, @Purchased)", conn))
                        {
                            cmd.Parameters.AddWithValue("@listID", _listID);
                            cmd.Parameters.AddWithValue("@ItemName", newItemName);
                            cmd.Parameters.AddWithValue("@Purchased", false);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Reload items to include the newly added item
                    LoadItems();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding item: {ex.Message}");
                }
            }
        }

        private void MarkPurchased_Click(object sender, EventArgs e)
        {
            if (listBoxItems.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to mark as purchased or remove.");
                return;
            }

            ListItem selectedItem = (ListItem)listBoxItems.SelectedItem;
            string[] parts = selectedItem.DisplayString.Split(new string[] { " - Purchased: " }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2)
            {
                string itemName = parts[0];
                bool isPurchased = Convert.ToBoolean(parts[1]);

                var result = MessageBox.Show($"Do you want to mark '{itemName}' as purchased?", "Mark Purchased", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    UpdateItemPurchasedStatus(selectedItem.Id, true);

                    // Prompt to remove the item after marking it as purchased
                    result = MessageBox.Show($"Do you want to remove '{itemName}' from the list?", "Remove Item", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        RemoveItem(selectedItem.Id);
                    }
                }
                else if (result == DialogResult.No)
                {
                    result = MessageBox.Show($"Do you want to remove '{itemName}' from the list?", "Remove Item", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        RemoveItem(selectedItem.Id);
                    }
                }
            }
        }

        private void UpdateItemPurchasedStatus(string itemId, bool purchased)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE ListItemTable SET Purchased = @Purchased WHERE ItemId = @ItemId", conn))
                    {
                        cmd.Parameters.AddWithValue("@Purchased", purchased);
                        cmd.Parameters.AddWithValue("@ItemId", itemId);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Reload items to reflect changes
                LoadItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating item status: {ex.Message}");
            }
        }

        private void RemoveItem(string itemId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM ListItemTable WHERE ItemId = @ItemId", conn))
                    {
                        cmd.Parameters.AddWithValue("@ItemId", itemId);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Reload items to reflect changes
                LoadItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing item: {ex.Message}");
            }
        }

        private void ClearList_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to clear the entire list?", "Clear List", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM ListItemTable WHERE listID = @listID", conn))
                        {
                            cmd.Parameters.AddWithValue("@listID", _listID);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Reload items to reflect changes
                    LoadItems();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error clearing list: {ex.Message}");
                }
            }
        }

        private void ShareList_Click(object sender, EventArgs e)
        {
            string passkey = GeneratePasskey();
            List<ListItem> items = GetItemsFromListView();
            string encodedContents = EncodeListContents(items);

            SavePasskeyToJson(passkey, encodedContents);

            // Copy the passkey to clipboard
            Clipboard.SetText(passkey);

            MessageBox.Show($"Passkey copied to clipboard: {passkey}");
        }

        private void ImportList_Click(object sender, EventArgs e)
        {
            string passkey = Prompt.ShowDialog("Enter passkey:", "Import List");

            if (string.IsNullOrEmpty(passkey))
            {
                MessageBox.Show("Please enter a valid passkey.");
                return;
            }

            string encodedContents = GetEncodedContentsFromJson(passkey);

            if (encodedContents == null)
            {
                MessageBox.Show("Invalid passkey.");
                return;
            }

            List<ListItem> items = JsonConvert.DeserializeObject<List<ListItem>>(encodedContents);
            LoadItemsIntoListView(items);
        }

        private void LeaveList_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to leave this list?", "Leave List", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // Remove the list from the DomainUpDown control in Home form
                homeForm.RemoveListFromDomainUpDown(_listName);
                this.Close();
            }
        }

        private string GeneratePasskey()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[16];
                rng.GetBytes(data);
                return BitConverter.ToString(data).Replace("-", "").ToLower();
            }
        }

        private string EncodeListContents(List<ListItem> items)
        {
            return JsonConvert.SerializeObject(items);
        }

        private void SavePasskeyToJson(string passkey, string encodedContents)
        {
            Dictionary<string, string> passkeyData;

            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);
                passkeyData = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
            else
            {
                passkeyData = new Dictionary<string, string>();
            }

            passkeyData[passkey] = encodedContents;

            string updatedJson = JsonConvert.SerializeObject(passkeyData, Formatting.Indented);
            File.WriteAllText(jsonFilePath, updatedJson);
        }

        private string GetEncodedContentsFromJson(string passkey)
        {
            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);
                var passkeyData = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

                if (passkeyData.ContainsKey(passkey))
                {
                    return passkeyData[passkey];
                }
            }

            return null;
        }

        private List<ListItem> GetItemsFromListView()
        {
            List<ListItem> items = new List<ListItem>();
            foreach (ListItem item in listBoxItems.Items)
            {
                items.Add(item);
            }
            return items;
        }

        private void LoadItemsIntoListView(List<ListItem> items)
        {
            listBoxItems.Items.Clear();
            foreach (var item in items)
            {
                listBoxItems.Items.Add(item);
            }
        }

        private void InitializeUI()
        {

        }

        private void InitializeJsonFile()
        {
            if (!File.Exists(jsonFilePath))
            {
                File.WriteAllText(jsonFilePath, "{}");
            }
        }
    }

    public class ListItem
    {
        public string Id { get; set; }
        public string DisplayString { get; set; }

        public override string ToString()
        {
            return DisplayString;
        }
    }

    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 200 };
            Button confirmation = new Button() { Text = "OK", Left = 150, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}