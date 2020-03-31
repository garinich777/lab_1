using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace lab_1.Model
{
    public class BaseArrayWorkerModel
    {
        private readonly ObservableCollection<int> _values = new ObservableCollection<int>();
        private readonly ObservableCollection<int> _even_values = new ObservableCollection<int>();
        private readonly ObservableCollection<int> _odd_values = new ObservableCollection<int>();

        public readonly ReadOnlyObservableCollection<int> Values;
        public readonly ReadOnlyObservableCollection<int> Even_Values;
        public readonly ReadOnlyObservableCollection<int> Odd_Values;

        public BaseArrayWorkerModel()
        {
            Values       = new ReadOnlyObservableCollection<int>(_values);
            Even_Values  = new ReadOnlyObservableCollection<int>(_even_values);
            Odd_Values   = new ReadOnlyObservableCollection<int>(_odd_values);
        }

        private void Shuffle(int index, int value)
        {
            if (index % 2 == 0)
                _even_values.Add(value);            
            else
                _odd_values.Add(value);
        }

        public void AddValue(int? value)
        {
            if (value.HasValue)
            {
                _values.Add(value.Value);
                Shuffle(_values.Count - 1, value.Value);
            }
        }

        private void Sort()
        {
            _even_values.Clear();
            _odd_values.Clear();
            for (int i = 0; i < _values.Count; i++)
                Shuffle(i, _values[i]);
        }

        public void RemoveValue(int? index)
        {
            if (index >= 0 && index < _values.Count && index.HasValue)
            {
                _values.RemoveAt(index.Value);
                Sort();
            }
        }

        public void RandomGenerate(int count)
        {
            Clear();
            int max_value = 10000;
            int min_value = -10000;
            var rand = new Random();
            for (int i = 0; i < count; i++)
                AddValue(rand.Next(min_value, max_value));
        }

        public bool TryReadFile(string path)
        {
            List<int> array = new List<int>();
            if (FileWorkerModel.TryReadArray(array, path))
            {
                _values.Clear();
                foreach (int el in array) _values.Add(el);                
                Sort();
                return true;
            }
            return false;            
        }

        public void WriteFile(string path)
        {
            FileWorkerModel.WriteFile(Values, path);
        }

        public void ResultWriteFile(string path)
        {
            FileWorkerModel.WriteFile(Even_Values, Odd_Values, path);
        }

        public void Clear()
        {
            _values.Clear();
            _even_values.Clear();
            _odd_values.Clear();
        }
    }
}
