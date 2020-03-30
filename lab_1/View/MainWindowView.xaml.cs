using lab_1.ViewModel;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;


namespace lab_1.View
{
    public partial class MainWindow : Window
    {
        private BaseArrayWorkerVM _baseArrayWorkerVM = new BaseArrayWorkerVM();
        public MainWindow()
        {
            InitializeComponent();
            MyInitializeComponent();
        }

        private void GoToProgramClick(object sender, RoutedEventArgs e)
        {
            g_аbout_program.Visibility = Visibility.Collapsed;
            g_program.Visibility = Visibility.Visible;
        }

        private void ButtonAnimation(object sender, EventArgs e)
        {
            b_goto_program.Visibility = Visibility.Visible;
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

        private void OpenFileClick(object sender, RoutedEventArgs e)
        {
            string file_path = string.Empty;
            string file_name = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    file_path = openFileDialog.FileName;
                    file_name = Path.GetFileName(file_path);
                }
            }
            if (file_path != string.Empty)
            {
                if (!_baseArrayWorkerVM.FileRead(file_path))
                    MessageBoxView.Show(file_name, "Файл " + file_name + " содержит недопустимые значения", MessageBoxType.Error);
                else
                    MessageBoxView.Show(file_name, "Файл " + file_name + " успешно прочитан", MessageBoxType.Information);
            }
        }

        private void WriteFileClick(object sender, RoutedEventArgs e)
        {
            string file_path = string.Empty;
            string file_name = string.Empty;
            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
            {
                saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(file_path = saveFileDialog1.FileName))
                    {
                        file_name = Path.GetFileName(file_path);
                        _baseArrayWorkerVM.FileWrite(file_path);
                        MessageBoxView.Show(file_name, "Файл " + file_name + " успешно записан", MessageBoxType.Information);
                    }
                }
            }
        }

        private void ShowParametersClick(object sender, RoutedEventArgs e)
        {
            bool show_param = ParamVM.ShowInfo;
            ParametersWindowView param_window = new ParametersWindowView(show_param);
            param_window.ShowDialog();
            ParamVM.ShowInfo = param_window.ShowInfo;
        }

        private void MyInitializeComponent()
        {
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

            if (ParamVM.ShowInfo)
            {
                g_аbout_program.Visibility = Visibility.Visible;
                g_program.Visibility = Visibility.Collapsed;
            }
            else
            {
                g_аbout_program.Visibility = Visibility.Collapsed;
                g_program.Visibility = Visibility.Visible;
            }

            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

            timer.Tick += new EventHandler(ButtonAnimation);
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Start();
        }
    }
}
