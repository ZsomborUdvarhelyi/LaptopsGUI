using LaptopsCLI;
using System.IO;
using System.Windows;

namespace LaptopsGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Laptop> laptops = [];
        private int viewedCount = 0;
        public MainWindow()
        {
            InitializeComponent();
            

            using StreamReader sr = new(@"..\..\..\src\laptops.txt");
            _ = sr.ReadLine();
            while (!sr.EndOfStream) laptops.Add(new Laptop(sr.ReadLine()!));

            var manufacturers = laptops.GroupBy(l => l.Manufacturer.ManufacturerName).Count();
            var totalLaptops = laptops.Count;
            tbSummary.Text = $"{manufacturers} gyártó {totalLaptops} gépe közül választhat.";


            lbLaptops.ItemsSource = laptops;
        }

        private void LbLaptops_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lbLaptops.SelectedIndex >= 0)
            {
                var selectedLaptop = laptops[lbLaptops.SelectedIndex];
                tbDetails.Text = GetLaptopDetails(selectedLaptop);
                viewedCount++;

            }
        }

        private string GetLaptopDetails(Laptop laptop)
        {
            var screenParts = laptop.Screen.Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
            var screenSize = screenParts[0];
            var resolution = screenParts.Last();

            var priceInHUF = Math.Round(double.Parse(laptop.Price.Replace(",", ".")) * 4.12);

            return $"Kategória\n\t{laptop.Category.CategoryName}\n" +
                   $"Képátló\n\t{screenSize}\"\n" +
                   $"Felbontás\n\t{resolution}\n" +
                   $"Processzor\n\t{laptop.CPU}\n" +
                   $"RAM\n\t{laptop.RAM} GB\n" +
                   $"Háttértár(ak)\n\t{laptop.Storage}" +
                   $"\nOperációs rendszer\n\t{laptop.OS}" +
                   $"\nÁr\n\t{priceInHUF} Ft";
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show($"Ön {viewedCount} terméket tekintett meg. Bezárja az alkalmazást?", "Kilépés", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Close();
            }
        }
    }
}