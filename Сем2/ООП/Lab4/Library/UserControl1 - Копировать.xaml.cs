using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace Library;
public partial class GradientButton : UserControl
{
    public static readonly DependencyProperty TextProperty =
    DependencyProperty.Register("Text", typeof(string), typeof(GradientButton), new PropertyMetadata(string.Empty));
    public static readonly DependencyProperty CommandProperty =
    DependencyProperty.Register("Command", typeof(ICommand), typeof(GradientButton));

    public static readonly DependencyProperty CommandParameterProperty =
        DependencyProperty.Register("CommandParameter", typeof(object), typeof(GradientButton));

    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }

    public ICommand Command
    {
        get { return (ICommand)GetValue(CommandProperty); }
        set { SetValue(CommandProperty, value); }
    }

    public object CommandParameter
    {
        get { return GetValue(CommandParameterProperty); }
        set { SetValue(CommandParameterProperty, value); }
    }

    public GradientButton()
    {
        InitializeComponent();
    }
}