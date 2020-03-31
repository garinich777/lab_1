using System;
using System.Collections.ObjectModel;
using lab_1.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab_1.Test
{
    [TestClass]
    public class RemoveFuncTest
    {
        [TestMethod]
        public void Remove_EvenElementTest()
        {
            BaseArrayWorkerModel x = new BaseArrayWorkerModel();

            ObservableCollection<int> _values = new ObservableCollection<int>();
            ObservableCollection<int> _even_values = new ObservableCollection<int>();
            ObservableCollection<int> _odd_values = new ObservableCollection<int>();

            ReadOnlyObservableCollection<int> Values = new ReadOnlyObservableCollection<int>(_values);
            ReadOnlyObservableCollection<int> Even_Values = new ReadOnlyObservableCollection<int>(_even_values);
            ReadOnlyObservableCollection<int> Odd_Values = new ReadOnlyObservableCollection<int>(_odd_values);

            x.AddValue(0);
            x.AddValue(1);
            x.AddValue(2);
            x.AddValue(3);
            x.RemoveValue(0);

            _values.Add(1);
            _values.Add(2);
            _values.Add(3);

            _even_values.Add(1);
            _odd_values.Add(2);
            _even_values.Add(3);

            CollectionAssert.AreEqual(x.Values, Values);
            CollectionAssert.AreEqual(x.Even_Values, Even_Values);
            CollectionAssert.AreEqual(x.Odd_Values, Odd_Values);
        }

        [TestMethod]
        public void Remove_OddElementTest()
        {
            BaseArrayWorkerModel x = new BaseArrayWorkerModel();

            ObservableCollection<int> _values = new ObservableCollection<int>();
            ObservableCollection<int> _even_values = new ObservableCollection<int>();
            ObservableCollection<int> _odd_values = new ObservableCollection<int>();

            ReadOnlyObservableCollection<int> Values = new ReadOnlyObservableCollection<int>(_values);
            ReadOnlyObservableCollection<int> Even_Values = new ReadOnlyObservableCollection<int>(_even_values);
            ReadOnlyObservableCollection<int> Odd_Values = new ReadOnlyObservableCollection<int>(_odd_values);

            x.AddValue(0);
            x.AddValue(1);
            x.AddValue(2);
            x.AddValue(3);
            x.RemoveValue(1);

            _values.Add(0);
            _values.Add(2);
            _values.Add(3);

            _even_values.Add(0);
            _odd_values.Add(2);
            _even_values.Add(3);

            CollectionAssert.AreEqual(x.Values, Values);
            CollectionAssert.AreEqual(x.Even_Values, Even_Values);
            CollectionAssert.AreEqual(x.Odd_Values, Odd_Values);
        }
    }
}
