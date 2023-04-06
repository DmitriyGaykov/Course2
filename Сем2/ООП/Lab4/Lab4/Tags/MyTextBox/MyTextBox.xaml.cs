using Lab4.Tags.Button;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab4.Tags.MyTextBox
{
    /// <summary>
    /// Логика взаимодействия для MyTextBox.xaml
    /// </summary>
    public partial class MyTextBox : TextBox
    {
        public static readonly DependencyProperty WritingBackgroundProperty = DependencyProperty.Register("WritingBackground",
                                                                                                          typeof(Brush), 
                                                                                                          typeof(MyTextBox), 
                                                                                                          new PropertyMetadata(new SolidColorBrush(Colors.White), null, CoerceWBG),
                                                                                                          ValidColor);
        private Brush temp;


        private static object CoerceWBG(DependencyObject obj, object value)
        {
            var c = new SolidColorBrush(Colors.Red);

           if(value is null)
           {
                return new SolidColorBrush(Colors.White);
           }
           else if (value is SolidColorBrush b && b.Color == c.Color)
           {
                value = new SolidColorBrush(Colors.LightSkyBlue);
           }

            return value;
        }

        private Brush preColor = null;
        public Brush WritingBackground
        {
            get => (Brush)GetValue(WritingBackgroundProperty);
            set
            {
                SetValue(WritingBackgroundProperty, value);
            }
        }
        public MyTextBox()
        {
            InitializeComponent();
            preColor = this.Background;

            this.TextChanged += this.MyTextBox_TextChanged;
            
            this.MouseEnter += (object sender, MouseEventArgs e) => 
            {
                this.Foreground = new SolidColorBrush(Colors.Bisque);
            };
            this.MouseLeave += (object sender, MouseEventArgs e) =>
            {
                this.Foreground = new SolidColorBrush(Colors.Black);
            };
        }

        private void MyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Background = this.Text != string.Empty ? WritingBackground : preColor;
        }

        public static bool ValidColor(object value)
        {
            return value is SolidColorBrush b && !b.Equals(new SolidColorBrush(Colors.FloralWhite)); 
        }
    }
    [ValueConversion(typeof(string), typeof(Brush))]
    class FromStringToBrush : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Проверяем, что значение не является null и что это строка.
            if (value != null && value is string stringValue)
            {
                try
                {
                    // Преобразуем строку в кисть, используя метод Parse из класса BrushConverter.
                    return new BrushConverter().ConvertFromString(stringValue);
                }
                catch (FormatException)
                {
                    // В случае ошибки возвращаем значение по умолчанию.
                    return Brushes.Black;
                }
            }

            // Возвращаем значение по умолчанию, если значение не задано или не является строкой.
            return Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
