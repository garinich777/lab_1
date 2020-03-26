using lab_1.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

namespace lab_1.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainVM();
            ((INotifyCollectionChanged)lb_array.Items).CollectionChanged +=
             lb_array_CollectionChanged;
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {                  
            Close();
        }

        private void CollapseClick(object sender, RoutedEventArgs e)
        {     
            WindowState = WindowState.Minimized;
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void lb_array_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
                nb_add_value.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("dd");
        }
    }
}
