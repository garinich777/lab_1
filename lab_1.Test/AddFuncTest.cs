using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab_1.Model;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace lab_1.Test
{
    [TestClass]
    public class AddFuncTest
    {
        [TestMethod]
        public void Add_ElementTest_EvenCount()
        {
            ObservableCollection<int> _values = new ObservableCollection<int>();
            ObservableCollection<int> _even_values = new ObservableCollection<int>();
            ObservableCollection<int> _odd_values = new ObservableCollection<int>();

            ReadOnlyObservableCollection<int> Values = new ReadOnlyObservableCollection<int>(_values);
            ReadOnlyObservableCollection<int> Even_Values = new ReadOnlyObservableCollection<int>(_even_values);
            ReadOnlyObservableCollection<int> Odd_Values = new ReadOnlyObservableCollection<int>(_odd_values);

            BaseArrayWorkerModel x = new BaseArrayWorkerModel();
            x.AddValue(0);
            x.AddValue(1);
            x.AddValue(2);
            x.AddValue(3);

            _values.Add(0);
            _values.Add(1);
            _values.Add(2);
            _values.Add(3);

            _even_values.Add(0);
            _odd_values.Add(1);
            _even_values.Add(2);
            _odd_values.Add(3);

            CollectionAssert.AreEqual(x.Values, Values);
            CollectionAssert.AreEqual(x.Even_Values, Even_Values);
            CollectionAssert.AreEqual(x.Odd_Values, Odd_Values);
        }

        [TestMethod]
        public void Add_ElementTest_OddCount()
        {
            ObservableCollection<int> _values = new ObservableCollection<int>();
            ObservableCollection<int> _even_values = new ObservableCollection<int>();
            ObservableCollection<int> _odd_values = new ObservableCollection<int>();

            ReadOnlyObservableCollection<int> Values = new ReadOnlyObservableCollection<int>(_values);
            ReadOnlyObservableCollection<int> Even_Values = new ReadOnlyObservableCollection<int>(_even_values);
            ReadOnlyObservableCollection<int> Odd_Values = new ReadOnlyObservableCollection<int>(_odd_values);

            BaseArrayWorkerModel x = new BaseArrayWorkerModel();
            x.AddValue(0);
            x.AddValue(1);
            x.AddValue(2);
            x.AddValue(3);
            x.AddValue(4);

            _values.Add(0);
            _values.Add(1);
            _values.Add(2);
            _values.Add(3);
            _values.Add(4);

            _even_values.Add(0);
            _odd_values.Add(1);
            _even_values.Add(2);
            _odd_values.Add(3);
            _even_values.Add(4);

            CollectionAssert.AreEqual(x.Values, Values);
            CollectionAssert.AreEqual(x.Even_Values, Even_Values);
            CollectionAssert.AreEqual(x.Odd_Values, Odd_Values);
        }
    }
}
