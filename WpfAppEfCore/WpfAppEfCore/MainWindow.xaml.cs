using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppEfCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AppDbContext _context = new AppDbContext();

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }


        private void LoadData()
        {
            ProductGrid.ItemsSource = _context.Products.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addProductWindow = new AddProductWindow();
            if (addProductWindow.ShowDialog() == true) // Show window modally
            {
                _context.Products.Add(addProductWindow.NewProduct);
                _context.SaveChanges();
                LoadData(); // Refresh the grid
            }
        }

        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            /*
            if (ProductGrid.SelectedItem is Product selectedProduct)
            {
                selectedProduct.Name = "Modified Product";
                selectedProduct.Price += 10; // Example modification
                selectedProduct.Quantity += 1; // Example modification
                _context.SaveChanges();
                LoadData();
            }

            */
            // Get the selected product
            if (ProductGrid.SelectedItem is Product selectedProduct)
            {
                var modifyProductWindow = new ModifyProductWindow(selectedProduct);

                if (modifyProductWindow.ShowDialog() == true) // Show window modally
                {
                    _context.Products.Update(modifyProductWindow.ModifiedProduct); // Update the product in EF Core
                    _context.SaveChanges();
                    LoadData(); // Refresh the grid
                }
            }
            else
            {
                MessageBox.Show("Please select a product to modify.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductGrid.SelectedItem is Product selectedProduct)
            {
                _context.Products.Remove(selectedProduct);
                _context.SaveChanges();
                LoadData();
            }
        }

    }
}