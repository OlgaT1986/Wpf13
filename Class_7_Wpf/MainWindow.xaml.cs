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

namespace Class_7_Wpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void ExitExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void ExitCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (textBox != null && textBox.Text.Length == 0)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Документ открыт");
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Документ сохранен");
        }
       


        private void ComboBox_Font(object sender, SelectionChangedEventArgs e)
        {

            if (textBox != null)
            {
                string fontName = (sender as ComboBox).SelectedItem as String;
                FontFamily font = new FontFamily(fontName);
                textBox.FontFamily = font;

            }
        }

        private void ComboBox_Font_Size(object sender, SelectionChangedEventArgs e)
        {

            if (textBox != null)
            {
                string fontSize = (sender as ComboBox).SelectedItem as String;
                double size = Convert.ToDouble(fontSize);
                textBox.FontSize = size;

            }
        }

        private void Button_Click_B(object sender, RoutedEventArgs e)
        {
            if (textBox.FontWeight == FontWeights.Normal) // если текст Normal
            {
                textBox.FontWeight = FontWeights.Bold; // то делаем его жирный
            }
            else
            {
                textBox.FontWeight = FontWeights.Normal; // если нет  делаем Normal
            }
        }

        private void Button_Click_I(object sender, RoutedEventArgs e)
        {
            if (textBox.FontStyle == FontStyles.Normal)
            {
                textBox.FontStyle = FontStyles.Italic;
            }
            else
            {
                textBox.FontStyle = FontStyles.Normal;
            }
        }
        private void Button_Click_U(object sender, RoutedEventArgs e)
        {
            if (textBox.TextDecorations == null)
            {
                textBox.TextDecorations = TextDecorations.Underline;
            }
            else
            {
                textBox.TextDecorations = null;
            }
        }

        private void RadioButton_Black(object sender, RoutedEventArgs e)
        {
            Brush brush;
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Black;
            }
        }
        private void RadioButton_Red(object sender, RoutedEventArgs e)
        {
            Brush brush;
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Red;
            }
        }

        private void themes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries.Clear(); 
            Uri theme = new Uri(themes.SelectedIndex == 0 ? "Light.xaml" : "Dark.xaml", UriKind.Relative); 
            ResourceDictionary themeDict = Application.LoadComponent(theme) as ResourceDictionary; 
            Application.Current.Resources.MergedDictionaries.Add(themeDict); 
        }
    }
}
