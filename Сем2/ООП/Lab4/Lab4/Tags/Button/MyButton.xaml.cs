using Library;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Image = System.Windows.Controls.Image;

namespace Lab4.Tags.Button
{
    /// <summary>
    /// Логика взаимодействия для MyButton.xaml
    /// </summary>
    public partial class MyButton : UserControl
    {
        public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register("Radius", typeof(CornerRadius), typeof(MyButton), new PropertyMetadata(new CornerRadius(10)));
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text",
                                                                                             typeof(string), 
                                                                                             typeof(MyButton), 
                                                                                             new PropertyMetadata("MyButton", null, CoerceText),
                                                                                             ValidText);

        public CornerRadius Radius
        {
            get => (CornerRadius)base.GetValue(RadiusProperty);
            set => base.SetValue(RadiusProperty, value);
        }

        public string Text
        {
            get => (string)base.GetValue(TextProperty);
            set => base.SetValue(TextProperty, value);
        }

        public MyButton() : base() 
        {
            InitializeComponent();

            this.CommandBindings.Add(new CommandBinding(Commands.SayHello, CommandSayHello));
        }

        public void CommandSayHello(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello world!");
        }

        private static bool ValidText(object value) => value is String s && 
                                                       s.Length < 20;

        private static object CoerceText(DependencyObject obj, object value)
        {
            string str = value as string;

            str = str?.Replace("привет", "hello");

            return str ?? "MyButton";
        }
    }

    [ValueConversion(typeof(double), typeof(CornerRadius))]
    public class DoubleToCornerRadius : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is CornerRadius cr)
            {
                return cr;
            }

            return 20;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is CornerRadius cr)
            {
                return double.Parse(cr.ToString());
            }

            return 0;
        }
    }
}
