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
using System.IO;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainClass A = new MainClass();

        public MainWindow()
        {
            InitializeComponent();
            
           
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            A.SetPath(Convert.ToString(TextBox.Text));
        }

        private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextBox.Text = "";
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ListBox.Items.Clear();
            string[] dirnames = Directory.GetDirectories(A.GetPath());
            foreach (string dirname in dirnames)
            {
                ListBox.Items.Add(dirname);
            }
            
        }

        private void ListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox.SelectedItem == null)
            {
                
            }
            else
            {
                A.SetPath(ListBox.SelectedItem.ToString());
                TextBox.Text = A.GetPath();

            }
        }
    }

    public class MainClass
    {
        private string path { get; set; }

        public MainClass()
        {
            path = "D://";
        }

        public void SetPath(string valuePath)
        {
            path = valuePath;
        }

        public string GetPath()
        {
            return path;
        }
    }
}
