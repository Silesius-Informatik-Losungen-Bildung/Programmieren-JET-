using MyShop.Models;
using MyShopApp.Logic;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace MyShopApp
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            // Elemente der grafischen Oberfläche werden instaziert
            InitializeComponent();


            // Company instanzieren
            var company = JsonSerializer.Deserialize<Company>(File.ReadAllText("Data\\company.json"));

            // Lieferanten für Produkte instanzieren
            var suppliers = JsonSerializer.Deserialize<List<Supplier>>(File.ReadAllText("Data\\suppliers.json"));
            var supplier1 = suppliers[0];
            var supplier2 = suppliers[1];

            // Produkt 1 instanzieren
            var products = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText("Data\\products.json"));

            var product1 = products[0];
            // Produkt 2 instanzieren
            var product2 = products[1];
           
            supplier1.Products = new List<Product> { product1, product2 };
            supplier2.Products = new List<Product> { product1 };


            // Produkte in Company einstellen
            // 1 Company kann mehrere Produkte haben (1:N - Beziehung, "eins zu viele")


            // Kunde instanzieren
            var customers = JsonSerializer.Deserialize<List<Customer>>(File.ReadAllText("Data\\customers.json"));
            var customer1 = customers[0];


            // Kunde der Company hinzufügen
            // 1 Company kann mehrere Kunden haben (1:N - Beziehung, "eins zu viele")

            var companyLogic = new CompanyLogic(company);
            companyLogic.AddCustomer(customer1);
            companyLogic.AddProduct(product1);
            companyLogic.AddProduct(product2);


            // Bestellung instanzieren
            var order1 = JsonSerializer.Deserialize<Order>(File.ReadAllText("Data\\orders.json"));

            var orderItems = JsonSerializer.Deserialize<List<OrderItem>>(File.ReadAllText("Data\\orderItems.json"));
            // Bestellpostionen instanzieren
            var orderItem1 = orderItems[0];
            orderItem1.Product = product1;

            var orderItem2 = orderItems[1];
            orderItem2.Product = product2;


            // Bestellpostionen der Bestellung hinzufügen
            // 1 Bestellung kann viele BestellPosition haben (1:N - Beziehung, "eins zu viele") 
            order1.AddOrderItem(orderItem1);
            order1.AddOrderItem(orderItem2);

            
            
            
            // Bestellung dem Kunden zuweisen
            // 1 Kunde kann viele Bestellgen tätigen (1:N - Beziehung, "eins zu viele") 

            var customerLogic = new CustomerLogic(customer1);
            customerLogic.AddOrder(order1);

            var customerCardLogic = new CustomerCardLogic(customer1.CustomerCard);
            customerCardLogic.AddPoints(order1.OrderItems.Count);

            //customer1.AddOrder(order1);


            // GUI - Aktionen:
            // Daten an entspr. DataGrid-Elemente binden
            pnlCompany.DataContext = company;
            ProductDataGrid.ItemsSource = company.Products;
            CustomerDataGrid.ItemsSource = company.Customers;
            OrderDataGrid.ItemsSource = company.Customers.Select(c => c.Orders);
        }

        // Was zu machen ist bei Klick auf den Button "Stammdaten"
        private void StammdatenClick(object sender, RoutedEventArgs e)
        {
            pnlCustomers.Visibility = Visibility.Collapsed;
            pnlProducts.Visibility = Visibility.Collapsed;
            pnlOrders.Visibility = Visibility.Collapsed;
            pnlCompany.Visibility = Visibility.Visible;
        }

        // Was zu machen ist bei Klick auf den Button "Produkte"
        private void ProdukteClick(object sender, RoutedEventArgs e)
        {
            pnlCompany.Visibility = Visibility.Collapsed;
            pnlCustomers.Visibility = Visibility.Collapsed;
            pnlOrders.Visibility = Visibility.Collapsed;
            pnlProducts.Visibility = Visibility.Visible;
        }

        // Was zu machen ist bei Klick auf den Button "Kunden"
        private void KundenClick(object sender, RoutedEventArgs e)
        {
            pnlCompany.Visibility = Visibility.Collapsed;
            pnlProducts.Visibility = Visibility.Collapsed;
            pnlOrders.Visibility = Visibility.Collapsed;
            pnlCustomers.Visibility = Visibility.Visible;
        }

        // Was zu machen ist bei Klick auf den Button "Bestellungen"
        private void BestellungenClick(object sender, RoutedEventArgs e)
        {
            pnlCompany.Visibility = Visibility.Collapsed;
            pnlProducts.Visibility = Visibility.Collapsed;
            pnlCustomers.Visibility = Visibility.Collapsed;
            pnlOrders.Visibility = Visibility.Visible;
        }
    }
}