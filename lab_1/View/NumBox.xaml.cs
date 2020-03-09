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
        private int _value;
        private int _max_value;
        private int _min_value;

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            protected set { SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(NumBox), new PropertyMetadata(0));

        public int MaxValue
        {
            get { return (int)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }
        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(int), typeof(NumBox), new PropertyMetadata(10000));

        public int MinValue
        {
            get { return (int)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }
        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(int), typeof(NumBox), new PropertyMetadata(-10000));

        public NumBox()
        {
            InitializeComponent();
            _min_value = MinValue;
            _max_value = MaxValue;
            _value = Value;
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
                Regex _minus_zero = new Regex("-0");
                Regex _start_zero = new Regex("^0.+");

                if (_num_regex.IsMatch(tbNumBox.Text)) RemoveSymbol();                
                
                else if (_minus_regex.IsMatch(tbNumBox.Text.Remove(0, 1))) RemoveSymbol();

                else if (_minus_zero.IsMatch(tbNumBox.Text)) RemoveSymbol();

                else if (_start_zero.IsMatch(tbNumBox.Text)) RemoveSymbol();

                int.TryParse(tbNumBox.Text, out _value);
                if (_value < _min_value || _value > _max_value) RemoveSymbol();
            }
        }
    }
}
