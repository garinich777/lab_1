using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace lab_1.View
{
    public partial class ParametersWindowView : Window
    {

        private bool _show_info;
        public bool ShowInfo 
        { 
            get { return _show_info; } 
            set { _show_info = value; } 
        }

        public ParametersWindowView(bool show_info)
        {
            InitializeComponent();
            _show_info = show_info;
            cb_no_info.IsChecked = !_show_info;
        }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            _show_info = !cb_no_info.IsChecked.Value;
            Close();
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
    }
}
