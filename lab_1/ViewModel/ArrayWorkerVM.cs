using lab_1.Model;
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
    public class ArrayWorkerVM
    {
        readonly BaseArrayWorkerModel _model = new BaseArrayWorkerModel();
        readonly RandomArrayWorkerModel _random_model = new RandomArrayWorkerModel();

        public ReadOnlyObservableCollection<int> MVValues { get; private set; }
        public ReadOnlyObservableCollection<int> MVEvenValues { get; private set; }
        public ReadOnlyObservableCollection<int> MVOddValues { get; private set; }

        public ArrayWorkerVM()
        {
            AddCommand = new DelegateCommand(i => {
                _model.AddValue((int?)i);
                MVValues = _model.Values;
                MVEvenValues = _model.Even_Values;
                MVOddValues = _model.Odd_Values;
            });

            RemoveCommand = new DelegateCommand(i => {
                if (((int?)i).HasValue) _model.RemoveValue(((int?)i).Value);
                MVValues = _model.Values;
                MVEvenValues = _model.Even_Values;
                MVOddValues = _model.Odd_Values;
            });

            RandomGenerateCommand = new DelegateCommand(count => {
                _random_model.RandomGenerate((int)count);
                MVValues = _random_model.Values;
                MVEvenValues = _random_model.Even_Values;
                MVOddValues = _random_model.Odd_Values;
            });
        }
        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand RandomGenerateCommand { get; }
    }
}
        
