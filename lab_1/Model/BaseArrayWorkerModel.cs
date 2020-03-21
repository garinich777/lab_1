using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace lab_1.Model
{
    class BaseArrayWorkerModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private readonly ObservableCollection<int> _values = new ObservableCollection<int>();
        public readonly ReadOnlyObservableCollection<int> Values;

        public BaseArrayWorkerModel()
        {
            Values = new ReadOnlyObservableCollection<int>(_values);
        }

        public void AddValue(int? value)
        {
            if (value.HasValue)
            {
                _values.Add(value.Value);
                OnPropertyChanged("Sum");
            }
        }
        public void RemoveValue(int? index)
        {
            if (index >= 0 && index < _values.Count && index.HasValue)
            {
                _values.RemoveAt(index.Value);
                OnPropertyChanged("Sum");
            }
        }
        public int Sum => Values.Sum();
    }
}
