using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static shop.CustomerInfo;
using static shop.Payment;

namespace shop
{
    public partial class Shop : Form
    {
        private Sale sale;

        public Shop()
        {
            TextParser parser = new TextParser();
            List<Product> products = parser.ParseProducts("../../products.xml");

            sale = new Sale();

            InitializeComponent();
            AddDynamicProducts(products);
        }
        public void AddDynamicProducts(List<Product> products)
        {
            // making a individual panel
            foreach (Product product in products)
            {
                Panel nieuwProduct = new Panel();
                nieuwProduct.BackColor = Color.PowderBlue;
                nieuwProduct.Size = new Size(200, 250);
                nieuwProduct.BorderStyle = BorderStyle.Fixed3D;

                Label title = new Label();
                title.Text = "title: " + product.title;
                title.Location = new Point(12, 10);
                title.Size = new Size(175, 30);
                title.BackColor = Color.White;
                title.Font = new Font("Microsoft Sans Serif", 14);
                title.AutoSize = false;
                title.TextAlign = ContentAlignment.MiddleCenter;
                title.BorderStyle = BorderStyle.FixedSingle;

                Label description = new Label();
                description.Text = "- " + product.description;
                description.Location = new Point(10, 45);
                description.Size = new Size(180, 100);
                // description.BackColor = Color.White;
                description.Font = new Font("Microsoft Sans Serif", 14);

                Label price = new Label();
                price.Text = product.price.ToString() + " euro";
                price.Location = new Point(10, 140);
                price.Size = new Size(180, 30);
                price.Font = new Font("Microsoft Sans Serif", 14);
                price.AutoSize = false;
                price.TextAlign = ContentAlignment.MiddleCenter;

                Label quantityLabel = new Label();
                quantityLabel.Text = "Quantiy: ";
                quantityLabel.Location = new Point(10, 170);
                quantityLabel.Size = new Size(90, 30);
                // quantityLabel.BackColor = Color.White;
                quantityLabel.Font = new Font("Microsoft Sans Serif", 14);

                TextBox quantityBox = new TextBox();
                quantityBox.Location = new Point(100, 170);
                quantityBox.Size = new Size(90, 10);
                quantityBox.BackColor = Color.White;
                quantityBox.Font = new Font("Microsoft Sans Serif", 12);
                // dummy
                quantityBox.Text = "1";

                Button add = new Button();
                add.Text = "Add to shopping cart";
                add.Size = new Size(140, 40);
                add.Location = new Point(30, 200);
                add.ForeColor = Color.White;
                add.BackColor = Color.Red;
                add.Font = new Font(add.Font, FontStyle.Bold);
                add.Click += delegate (object sender, EventArgs e) { AddItem_Click(sender, e, product, quantityBox.Text); };
                add.Click += new EventHandler(this.RefreshShoppingcart);

                nieuwProduct.Controls.Add(title);
                nieuwProduct.Controls.Add(description);
                nieuwProduct.Controls.Add(price);
                nieuwProduct.Controls.Add(quantityLabel);
                nieuwProduct.Controls.Add(quantityBox);
                nieuwProduct.Controls.Add(add);
                flowLayoutPanel1.Controls.Add(nieuwProduct);
            }
        }
        public void RefreshShoppingcart(object sender, EventArgs e)
        {
            List<CartItem> items = sale.getCartItems();
            flowLayoutPanel2.Controls.Clear();
            foreach (CartItem item in items)
            {
                Panel line = new Panel();
                line.BackColor = Color.PowderBlue;
                line.Size = new Size(362, 29);
                line.BorderStyle = BorderStyle.FixedSingle;

                Label title = new Label();
                title.Text = item.product.title;
                title.Location = new Point(10, 5);
                title.Size = new Size(180, 19);
                title.Font = new Font("Microsoft Sans Serif", 12);

                Label quantity = new Label();
                quantity.Text = item.quantity.ToString();
                quantity.Location = new Point(300, 5);
                quantity.Size = new Size(180, 19);
                quantity.Font = new Font("Microsoft Sans Serif", 12);

                line.Controls.Add(quantity);
                line.Controls.Add(title);
                flowLayoutPanel2.Controls.Add(line);
            }
            NumberOfItemsLabel.Text = sale.GetQuantity().ToString();
            totalPriceLabel.Text = sale.GetPrice().ToString();
        }

        public void AddItem_Click(object sender, EventArgs e, Product product, string quantity)
        {
            sale.AddItem(product, quantity);
        }

        private void Pay_Click(object sender, EventArgs e)
        {
            PaymentMethod betaalwijze = PaymentMethod.DebitCard;

            if (comboBox1.SelectedItem.ToString() == "Credit card")
            {
                betaalwijze = PaymentMethod.CreditCard;
            } else
            {
                betaalwijze = PaymentMethod.DebitCard;
            }

            sale.SetCustomerInfo(textBox1.Text, textBox4.Text, betaalwijze, textBox7.Text, textBox9.Text, textBox11.Text);
        }

        private void DeleteCart_Click(object sender, EventArgs e)
        {
            sale.Cancel();

            NumberOfItemsLabel.Text = "0";
            totalPriceLabel.Text = "0";
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel2.Invalidate();
        }
    }
}
