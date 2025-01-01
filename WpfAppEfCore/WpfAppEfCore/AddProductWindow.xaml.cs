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
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public Product NewProduct { get; private set; }

        public AddProductWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate and save product data
            if (decimal.TryParse(PriceTextBox.Text, out decimal price) &&
                int.TryParse(QuantityTextBox.Text, out int quantity) &&
                !string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                NewProduct = new Product
                {
                    Name = NameTextBox.Text,
                    Price = price,
                    Quantity = quantity
                };
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
