using lab_1.Model;

namespace lab_1.ViewModel
{
    class ParamVM
    {
        public static bool ShowInfo 
        { 
            get { return ParamModel.ShowInfo; } 
            set { ParamModel.ShowInfo = value; }        
        }
    }
}
