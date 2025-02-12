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
    //   public class ShoppingList
    //   {
    //       public string listId { get; set; }
    //       public string listName { get; set; }
    //   }

    public class ShoppingList
    {
        public string listID { get; set; }
        public string listName { get; set; }
        public string createdBy { get; set; }
    }

    public partial class Home : Form
    {
        private List<ShoppingList> shoppingLists = new List<ShoppingList>();
        private ListBox listBoxShoppingLists;
        private Button btnCreateNewList;

        public Home()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            // Initialize components that should be set up when form loads
            InitializeUI();
        }

        private void InitializeUI()
        {
            // Create and set up the ListBox
            listBoxShoppingLists = new ListBox();
            listBoxShoppingLists.Dock = DockStyle.Fill;

            // Create and set up the Create New List button
            btnCreateNewList = new Button();
            btnCreateNewList.Text = "Create New Shopping List";
            btnCreateNewList.Click += CreateList_Click;
            btnCreateNewList.Location = new Point(10, 10);

            // Add controls to form
            this.Controls.Add(listBoxShoppingLists);
            this.Controls.Add(btnCreateNewList);
        }

        private void CreateList_Click(object sender, EventArgs e)
        {
            using (var createListForm = new CreateNewListForm())
            {
                if (createListForm.ShowDialog() == DialogResult.OK)
                {
                    // Add the new list to our collection
                    ShoppingList newList = createListForm.CreatedList;
                    shoppingLists.Add(newList);

                    // Update the ListBox
                    RefreshListDisplay();
                }
            }
        }

        private void RefreshListDisplay()
        {
            listBoxShoppingLists.Items.Clear();
            foreach (var list in shoppingLists)
            {
                listBoxShoppingLists.Items.Add(list.listName);
            }
        }
    }
}
