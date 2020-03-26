using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace lab_1.Model
{
    class BaseArrayWorkerModel
    {
        private readonly ObservableCollection<int> _values = new ObservableCollection<int>();
        private readonly ObservableCollection<int> _even_values = new ObservableCollection<int>();
        private readonly ObservableCollection<int> _odd_values = new ObservableCollection<int>();

        public readonly ReadOnlyObservableCollection<int> Values;
        public readonly ReadOnlyObservableCollection<int> Even_Values;
        public readonly ReadOnlyObservableCollection<int> Odd_Values;

        public BaseArrayWorkerModel()
        {
            Values = new ReadOnlyObservableCollection<int>(_values);
            Even_Values = new ReadOnlyObservableCollection<int>(_even_values);
            Odd_Values = new ReadOnlyObservableCollection<int>(_odd_values);
        }

        public void AddValue(int? value)
        {
            if (value.HasValue)
            {
                _values.Add(value.Value);

                if (_values.Count % 2 == 0)
                    _odd_values.Add(value.Value);
                else
                    _even_values.Add(value.Value);
            }
        }

        public void RemoveValue(int? index)
        {
            if (index >= 0 && index < _values.Count && index.HasValue)
            {
                _even_values.Clear();
                _odd_values.Clear();
                _values.RemoveAt(index.Value);
                int i = 0;
                foreach(int el in Values) 
                {
                    if (i % 2 == 0)
                        _even_values.Add(el);
                    else
                        _odd_values.Add(el);
                    i++;
                }
            }
        }

        public void RandomGenerate(int count)
        {
            _values.Clear();
            _even_values.Clear();
            _odd_values.Clear();
            var rand = new Random();
            for (int i = 0; i < count; i++)
                AddValue(rand.Next(-10000, 10000));
        }
    }
}
