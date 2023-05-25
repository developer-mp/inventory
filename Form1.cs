using System.Data;

namespace Inventory
{
    public partial class Inventory : Form

        
    {
        DataTable inventory = new DataTable();
        public Inventory()
        {
            InitializeComponent();
        }
         private void newButton_Click(object sender, EventArgs e)
        {
            skuTextBox.Text = "";
            nameTextBox.Text = "";
            priceTextBox.Text = "";
            descTextBox.Text = "";
            quantityTextBox.Text = "";
            categoryBox.SelectedIndex = -1;

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            String sku = skuTextBox.Text;
            String name = nameTextBox.Text;
            String price = priceTextBox.Text;
            String quantity = quantityTextBox.Text;
            String desc = descTextBox.Text;
            String category = (string)categoryBox.SelectedItem;

            inventory.Rows.Add(sku, name, category, price, desc, quantity);

            newButton_Click(sender, e);

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                inventory.Rows[inventoryGridView.CurrentCell.RowIndex].Delete();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }

        }

        private void inventoryGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                skuTextBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[0].ToString();
                nameTextBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[1].ToString();
                priceTextBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[3].ToString();
                descTextBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[4].ToString();
                quantityTextBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[5].ToString();

                String itemToLookFor = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[2].ToString();
                categoryBox.SelectedIndex = categoryBox.Items.IndexOf(itemToLookFor);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }

        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            inventory.Columns.Add("SKU");
            inventory.Columns.Add("Name");
            inventory.Columns.Add("Category");
            inventory.Columns.Add("Price");
            inventory.Columns.Add("Description");
            inventory.Columns.Add("Quantity");

            inventoryGridView.DataSource = inventory;
        }

        private void inventoryGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}