using AppControleFinanceiro.Models;
using System.Globalization;

namespace AppControleFinanceiro.Libraries.Converters
{
    public class TransactionValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Transaction transaction = (Transaction)value;

            if (transaction == null)
                return string.Empty;

            if (transaction.Type == TransactionType.Income)
                return transaction.Value.ToString("C");

            return $"- {transaction.Value.ToString("C")}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
