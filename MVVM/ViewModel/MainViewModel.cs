using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM.ViewModel;
using System.Windows.Input;


namespace MVVM.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand ButtonCommand { get; set; }
        public string Display
        {
            get
            {
                return m_calculator.Display;
            }
            set
            {
                if (value == m_calculator.Display)
                    return;
                m_calculator.Display = value;
                base.OnPropertyChanged("Display");
            }
        }
        private Model.Calculator m_calculator;
        public MainViewModel()
        {
            m_calculator = new Model.Calculator();
            ButtonCommand = new RelayCommand(
            new Action<object>(delegate(object obj)
            {
                m_calculator.Process(obj as string);
                base.OnPropertyChanged("Display");
            }));
        }
    }
}