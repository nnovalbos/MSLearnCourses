using System;
using System.Globalization;
using System.Reflection;
using FlagData;
using Xamarin.Forms;

namespace FlagFacts.Converters
{
    public class EmbeddedImageConverter : IValueConverter
    {
        public Type ResolvingAssemblyType { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var imageUrl = (value ?? string.Empty).ToString();
            if (string.IsNullOrEmpty(imageUrl))
                return null;

            return ImageSource.FromResource(imageUrl,
                ResolvingAssemblyType?.GetTypeInfo().Assembly);

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException($"{nameof(EmbeddedImageConverter)} cannot be used on two-way bindings.");
        }
    }
}
