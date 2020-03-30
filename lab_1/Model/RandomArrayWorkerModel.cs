using lab_1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1.ViewModel
{
    class RandomArrayWorkerModel : BaseArrayWorkerModel
    {
        public void RandomGenerate(int count)
        {
            _odd_values.Clear();
            _even_values.Clear();
            _values.Clear();
            var rand = new Random();
            for (int i = 0; i < count; i++)
                AddValue(rand.Next(-10000, 10000));
        }
    }
}
