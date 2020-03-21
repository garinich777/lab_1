using lab_1.Model;

namespace lab_1.ViewModel
{
    class AboutMessageVM
    {
        public string Message { get { return AboutMessageModel.GetAboutMessage(); } }
    }
}
