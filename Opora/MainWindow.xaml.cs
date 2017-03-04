using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Opora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TextBoxH.Text = TextBoxH1.Text = TextBoxH2.Text = TextBoxX.Text = TextBoxResult.Text = (0.0).ToString("F1");
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            double h, h1, h2, x;
            if (!TryParse(TextBoxH.Text, out h) || !TryParse(TextBoxH1.Text, out h1) || !TryParse(TextBoxH2.Text, out h2) ||
                !TryParse(TextBoxX.Text, out x))
            {
                MessageBox.Show("Неверные исходные данные", Title);
                return;
            }

            double result = x - Math.Abs(h1 - h2) * h;
            TextBoxResult.Text = result.ToString();

            TextBlockWarning.Visibility = result > 12 ? Visibility.Visible : Visibility.Collapsed;
        }

        private bool TryParse(string s, out double result)
        {
            string separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            s = s.Replace(".", separator).Replace(",", separator);
            return double.TryParse(s, out result);
        }
    }
}
