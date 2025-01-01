using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfAppEfCore
{
    /// <summary>
    /// Interaction logic for ModifyProductWindow.xaml
    /// </summary>
    public partial class ModifyProductWindow : Window
    {
        

        public Product ModifiedProduct { get; private set; }

        public ModifyProductWindow(Product product)
        {
            InitializeComponent();

            // Pre-fill the fields with product data
            NameTextBox.Text = product.Name;
            PriceTextBox.Text = product.Price.ToString();
            QuantityTextBox.Text = product.Quantity.ToString();

            // Copy the product for modification
            ModifiedProduct = product;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate and update product data
            if (decimal.TryParse(PriceTextBox.Text, out decimal price) &&
                int.TryParse(QuantityTextBox.Text, out int quantity) &&
                !string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                ModifiedProduct.Name = NameTextBox.Text;
                ModifiedProduct.Price = price;
                ModifiedProduct.Quantity = quantity;

                DialogResult = true; // Indicate success
                Close();
            }
            else
            {
                MessageBox.Show("Please enter valid data.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Indicate cancellation
            Close();
        }
    }
}
