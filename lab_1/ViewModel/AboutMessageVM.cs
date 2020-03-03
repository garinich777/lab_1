using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using lab_1.Model;

namespace lab_1.ViewModel
{
    class AboutMessageVM
    {
        public string Message { get { return AboutMessageModel.GetAboutMessage(); } }
    }
}
