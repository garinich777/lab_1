﻿using lab_1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace lab_1.ViewModel
{
    class BaseArrayWorkerVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        readonly BaseArrayWorkerModel _model = new BaseArrayWorkerModel();
        public BaseArrayWorkerVM()
        {
            _model.PropertyChanged += (s, e) => { OnPropertyChanged(e.PropertyName); };

            AddCommand = new DelegateCommand(i => {
                _model.AddValue((int?)i);
            });

            RemoveCommand = new DelegateCommand(i => {
                if (((int?)i).HasValue) _model.RemoveValue(((int?)i).Value);
            });

            RandomGenerateCommand = new DelegateCommand(count => {
                _model.RandomGenerate(int.Parse((string)count));
            });
        }
        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand RandomGenerateCommand { get; }
        public ReadOnlyObservableCollection<int> MVValues => _model.Values;
        public ReadOnlyObservableCollection<int> MVEvenValues => _model.Even_Values;
        public ReadOnlyObservableCollection<int> MVOddValues => _model.Odd_Values;
    }
}
        
