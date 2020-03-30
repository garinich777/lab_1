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
        static private IniData data = new IniData();
        static private string param_file_name = "Configuration.ini";

        static public bool ShowInfo 
        { 
            get
            {
                if (File.Exists(param_file_name))
                {
                    data = new FileIniDataParser().ReadFile(param_file_name);
                    string show_info_text = data["UI"]["screen_info"];
                    return bool.Parse(show_info_text);
                }
                return true;
            }
            set
            {
                data["UI"]["screen_info"] = value.ToString();
                new FileIniDataParser().WriteFile(param_file_name, data);
            } 
        }
    }
}
