using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace P3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<DataItem> DataItems { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataItems = new ObservableCollection<DataItem>();
            User.ItemsSource = DataItems;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Name = name.Text;
            string Organization = org.Text;
            string Status = "";

            if(status.IsChecked == true)
            {
                Status = "подтверждено";
            }
            else
            {
                Status = "в ожидании";
            }

            if (name.Text=="")
            {
                MessageBox.Show("Поле имени не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if(org.Text=="")
            {
                MessageBox.Show("Поле организации не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DataItems.Add(new DataItem { Name = Name, Organization = Organization, Status = Status });
            name.Clear();
            org.Clear();
           
        }
    }
    public class DataItem
    {
        public string Name { get; set; }
        public string Organization { get; set; }
        public string Status { get; set; }
    }
}
