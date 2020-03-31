using lab_1.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace lab_1.View
{
    public partial class RandomCreateWindow : Window
    {
        private BaseArrayWorkerVM _baseArrayWorkerVM;
        public RandomCreateWindow(BaseArrayWorkerVM baseArrayWorkerVM)
        {
            InitializeComponent();
            _baseArrayWorkerVM = baseArrayWorkerVM;
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void СreateArrayClick(object sender, RoutedEventArgs e)
        {
            if (nb_array_size.Value.HasValue)
            {
                MessageBoxResult messageBoxResult = MessageBoxView.Show("Создать рандомный массив?", "Старый массив будет утерян! Создать рандомный массив?", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (messageBoxResult != MessageBoxResult.Yes)
                {
                    ((Button)sender).Command = null;
                    ((Button)sender).CommandParameter = null;
                }
                else
                {
                    ((Button)sender).Command = _baseArrayWorkerVM.RandomGenerateCommand;
                    ((Button)sender).CommandParameter = nb_array_size.Value.Value;
                    Close();
                }
            }
            else
            {
                MessageBoxView.Show("Введите параметр!", "Введите размер массива", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
