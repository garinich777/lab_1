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
        private BaseArrayWorkerVM _baseArrayWorkerVM = new BaseArrayWorkerVM();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainVM();

            ((INotifyCollectionChanged)lb_array.Items).CollectionChanged += (s, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add) nb_add_value.Clear();
            };
            b_Add.Command = _baseArrayWorkerVM.AddCommand;
            b_Remove.Command = _baseArrayWorkerVM.RemoveCommand;
            lb_array.ItemsSource = _baseArrayWorkerVM.MVValues;
            lb_array_even.ItemsSource = _baseArrayWorkerVM.MVEvenValues;
            lb_array_odd.ItemsSource = _baseArrayWorkerVM.MVOddValues;
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            new RandomCreateWindow(_baseArrayWorkerVM).Show();
        }
    }
}
