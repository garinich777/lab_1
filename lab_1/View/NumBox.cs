using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace lab_1.View
{
    public partial class NumBox : TextBox
    {
        private int _value;
        private int _max_value;
        private int _min_value;

        private static Regex _num_regex = new Regex("[^0-9-]");
        private static Regex _minus_regex = new Regex("[^0-9]");
        private static Regex _minus_zero = new Regex("-0");
        private static Regex _start_zero = new Regex("^0.+");

        public event RoutedEventHandler ErrorSymbol
        {
            add { AddHandler(ErrorSymbolEvent, value); }
            remove { RemoveHandler(ErrorSymbolEvent, value); }
        }
        public static readonly RoutedEvent ErrorSymbolEvent =
            EventManager.RegisterRoutedEvent("ErrorSymbol", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(NumBox));

        void RaiseErrorSymbolEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(ErrorSymbolEvent);
            RaiseEvent(newEventArgs);
        }

        public int? Value
        {
            get { return (int?)GetValue(ValueProperty); }
            protected set { SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int?), typeof(NumBox), new PropertyMetadata(null));

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
            TextChanged += tbNumBox_TextChanged;
            _min_value = MinValue;
            _max_value = MaxValue;         
            _value = 0;
        }

        private void RemoveSymbol()
        {
            Text = Text.Remove(Text.Length - 1);
            SelectionStart = Text.Length;
            RaiseErrorSymbolEvent();
        }

        private void tbNumBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _min_value = MinValue;
            _max_value = MaxValue;
            if (Text != "")
            {
                if (_num_regex.IsMatch(Text)) RemoveSymbol();

                else if (_minus_regex.IsMatch(Text.Remove(0, 1))) RemoveSymbol();

                else if (_minus_zero.IsMatch(Text)) RemoveSymbol();

                else if (_start_zero.IsMatch(Text)) RemoveSymbol();

                int.TryParse(Text, out _value);
                if (_value < _min_value || _value > _max_value) RemoveSymbol();

                if (Text == "-" && _min_value >= 0) RemoveSymbol();

                Value = _value;
            }
            else
                Value = null;
        }
    }
}
