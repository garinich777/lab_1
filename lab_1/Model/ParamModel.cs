using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1.Model
{
    class ParamModel
    {
        static public bool ShowInfo
        {
            get
            {
                return (bool)Properties.Settings.Default["show_info"];
            }
            set
            {
                Properties.Settings.Default["show_info"] = value;
                Properties.Settings.Default.Save();
            }
        }
    }
}
