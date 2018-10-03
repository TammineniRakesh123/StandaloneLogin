using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Collections.Generic;

namespace LoginPage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String passid = null;
        String uname = null;
        Dictionary<String, String> d1 = new Dictionary<String, String>();
         
        public MainWindow()
        {
            d1.Add("XX", "XX");
            d1.Add("rak", "rak");
            d1.Add("admin", "admin");
            InitializeComponent();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
          
           int i= new MainWindow().valid(uname, passid);
           if (i == 1)
           {
               MessageBox.Show("valid");
              
           }
           else
           {
               MessageBox.Show("inavad");
           }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
           uname=txt1.Text;
        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {
           passid = txt2.Text;

        }
        int valid(String uname, String passid)
        {
            foreach (String x in d1.Keys)
            {
                if (uname.Equals(x))
                {
                    if (passid.Equals(d1[x]))
                    {
                        return 1;
                    }
                }
               
            }
            return 2;
        }
    }
    public static class PasswordHelper
{
    public static readonly DependencyProperty PasswordProperty =
        DependencyProperty.RegisterAttached("Password",
        typeof(string), typeof(PasswordHelper),
        new FrameworkPropertyMetadata(string.Empty, OnPasswordPropertyChanged));
 
    public static readonly DependencyProperty AttachProperty =
        DependencyProperty.RegisterAttached("Attach",
        typeof(bool), typeof(PasswordHelper), new PropertyMetadata(false, Attach));
 
    private static readonly DependencyProperty IsUpdatingProperty =
       DependencyProperty.RegisterAttached("IsUpdating", typeof(bool), 
       typeof(PasswordHelper));
 
 
    public static void SetAttach(DependencyObject dp, bool value)
    {
        dp.SetValue(AttachProperty, value);
    }
 
    public static bool GetAttach(DependencyObject dp)
    {
        return (bool)dp.GetValue(AttachProperty);
    }
 
    public static string GetPassword(DependencyObject dp)
    {
        return (string)dp.GetValue(PasswordProperty);
    }
 
    public static void SetPassword(DependencyObject dp, string value)
    {
        dp.SetValue(PasswordProperty, value);
    }
 
    private static bool GetIsUpdating(DependencyObject dp)
    {
        return (bool)dp.GetValue(IsUpdatingProperty);
    }
 
    private static void SetIsUpdating(DependencyObject dp, bool value)
    {
        dp.SetValue(IsUpdatingProperty, value);
    }
 
    private static void OnPasswordPropertyChanged(DependencyObject sender,
        DependencyPropertyChangedEventArgs e)
    {
        PasswordBox passwordBox = sender as PasswordBox;
        passwordBox.PasswordChanged -= PasswordChanged;
 
        if (!(bool)GetIsUpdating(passwordBox))
        {
            passwordBox.Password = (string)e.NewValue;
        }
        passwordBox.PasswordChanged += PasswordChanged;
    }
 
    private static void Attach(DependencyObject sender,
        DependencyPropertyChangedEventArgs e)
    {
        PasswordBox passwordBox = sender as PasswordBox;
 
        if (passwordBox == null)
            return;
 
        if ((bool)e.OldValue)
        {
            passwordBox.PasswordChanged -= PasswordChanged;
        }
 
        if ((bool)e.NewValue)
        {
            passwordBox.PasswordChanged += PasswordChanged;
        }
    }
 
    private static void PasswordChanged(object sender, RoutedEventArgs e)
    {
        PasswordBox passwordBox = sender as PasswordBox;
        SetIsUpdating(passwordBox, true);
        SetPassword(passwordBox, passwordBox.Password);
        SetIsUpdating(passwordBox, false);
    }
}
}
