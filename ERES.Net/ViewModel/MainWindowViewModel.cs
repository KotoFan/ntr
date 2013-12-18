using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;

namespace StudentList.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
       
        public ICommand ButtonCommand { get; set; }

      
        private String _imie;
        private String _nazwisko;

        public String Imie
        {
            get
            {
                return _imie;
            }
            set
            {
                _imie = value;
                OnPropertyChanged("Imie");

            }
        }

        public String Nazwisko
        {
            get
            {
                return _nazwisko;
            }
            set
            {
                _nazwisko = value;
                OnPropertyChanged("Nazwisko");

            }
        }



        public MainWindowViewModel()
        {
            

            ButtonCommand = new RelayCommand(
           new Action<object>(delegate(object obj)
           {
              
               OnPropertyChanged("Students");

           }));
        }
    }
}