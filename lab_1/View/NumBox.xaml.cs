using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class NumBox : UserControl
    {
        public NumBox()
        {
            InitializeComponent();
        }

        private void RemoveSymbol()
        {
            tbNumBox.Text = tbNumBox.Text.Remove(tbNumBox.Text.Length - 1);
            tbNumBox.SelectionStart = tbNumBox.Text.Length;
        }

        private void tbNumBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbNumBox.Text != "")
            {
                Regex _num_regex = new Regex("[^0-9-]");
                Regex _minus_regex = new Regex("[^0-9]");

                if (_num_regex.IsMatch(tbNumBox.Text)) RemoveSymbol();                
                
                else if (_minus_regex.IsMatch(tbNumBox.Text.Remove(0, 1))) RemoveSymbol();

                int value = 0;
                int.TryParse(tbNumBox.Text, out value);
                if (Math.Abs(value) > 10000) RemoveSymbol();
            }
        }
    }
}
