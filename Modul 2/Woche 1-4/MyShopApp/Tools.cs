using MyShop.Models;
using System.Globalization;
using System.Windows.Data;

namespace MyShopApp
{
    public static class UniqueIntegerGenerator
    {
        private static int counter = 0;
        public static int GetNextUniqueInteger()
        {
            return Interlocked.Increment(ref counter);
        }
    }
    public class SupplierConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is List<Supplier> suppliers)
            {
                return string.Join(", ", suppliers.Select(s => s.Name));
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class OrderListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is List<Order> orders)
            {
                return string.Join(", ", orders.Select(o => $"#{o.OrderId} am {o.Timestamp}"));
            }
            return "Keine Bestellungen";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class CustomerCardConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is CustomerCard card)
            {
                return $"Karte: {card.CustomerCardId}";
            }
            return "Keine Kundenkarte";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class OrderItemListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is List<OrderItem> orderItems)
            {
                return string.Join(", ", orderItems.Select(item => $"{item.Product.Name} x{item.Quantity}"));
            }
            return "Keine Bestellpositionen";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
