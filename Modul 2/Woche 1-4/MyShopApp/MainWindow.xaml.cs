using MyShop.Models;
using MyShopApp.Logic;
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
            var company = new Company
            {
                Name = "Billa",
                Email = "bill@billa.xy",
                Phone = "3432432432",
                PostCode = 1140,
                City = "Wien",
                Street = "Kendlerstr 34",
                Uid = "AT123456789",
                Website = "www.example.com",
                Contact = "Alexander",
            };

            // Lieferanten für Produkte instanzieren
            var supplier1 = new Supplier
            {
                Name = "Lieferant 1",
                Email = "aaa@bbb.at",
                Street = " Kendlerstr 34",
                City = "Wien",
                PostCode = 1140,
                Phone = "32423423"
            };
            var supplier2 = new Supplier
            {
                Name = "Lieferant 2",
                Email = "dsds@dsdsd.at",
                Street = " Kendlerstr 34",
                City = "Wien",
                PostCode = 1140,
                Phone = "65487789789",
            };

            // Produkt 1 instanzieren
            var product1 = new Product
            {
                Name = "Kugeschreiber gelb",
                Price = 1.20m,
                // Mehrere Produkte können von mehreren Lieferanten geliefert werden (N:M - Beziehung, "viele zu viele")
                Suppliers = new List<Supplier> { supplier1, supplier2 }
            };

            // Produkt 2 instanzieren
            var product2 = new Product
            {
                Name = "Druckpapier premium",
                Price = 9.9m,
                // Mehrere Produkte können von mehreren Lieferanten geliefert werden (N:M - Beziehung, "viele zu viele")
                Suppliers = new List<Supplier> { supplier1 }
            };


            supplier1.Products = new List<Product> { product1, product2 };
            supplier2.Products = new List<Product> { product1 };


            // Produkte in Company einstellen
            // 1 Company kann mehrere Produkte haben (1:N - Beziehung, "eins zu viele")

         




            // Kunde instanzieren
            var customer1 = new Customer
            {
                Email = "aaa@bbb.at",
                Lastname = "Mustermann",
                Street = " Kendlerstr 34",
                City = "Wien",
                PostCode = 1140,
                Phone = "000111111",
                Firstname = "Maximilian",
                // 1 Kunde kann nur einen KundenPass BZW: ein KundenPass kann nur einen Kunden haben (1:1 - Beziehung, "eins zu eins") 
                CustomerCard = new CustomerCard()
            };

            // Kunde der Company hinzufügen
            // 1 Company kann mehrere Kunden haben (1:N - Beziehung, "eins zu viele")

            var companyLogic = new CompanyLogic(company);
            companyLogic.AddCustomer(customer1);
            companyLogic.AddProduct(product1);
            companyLogic.AddProduct(product2);


            // Bestellung instanzieren
            var order1 = new Order();

            // Bestellpostionen instanzieren
            var orderItem1 = new OrderItem
            {
                Quantity = 2,
                Product = product1
            };

            var orderItem2 = new OrderItem
            {
                Quantity = 1,
                Product = product2
            };

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