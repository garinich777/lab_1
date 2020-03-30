using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1.Model
{
    public static class FileWorkerModel
    {
        public static bool TryReadArray(List<int> array, string path)
        {
            string file_content;
            using (StreamReader reader = new StreamReader(path))
            {
                file_content = reader.ReadToEnd();
            }

            array.Clear();
            string[] file_elements = file_content.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string el in file_elements)
            {
                int int_el = 0;
                if (int.TryParse(el, out int_el))
                    array.Add(int_el);
                else
                    return false;
            }
            return true;
        }

        public static void WriteFile(ReadOnlyObservableCollection<int> array, string path)
        {
            string content = string.Empty;
            foreach (int el in array)
                content += el.ToString() + " ";
            
            using (StreamWriter writer = new StreamWriter(path))
                writer.Write(content);
            
        }
    }
}
