using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;

using ERES.Net.Model.Database;
using ERES.Net.Model;
using EresData;

namespace ERES.Net.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
       
        public ICommand ButtonCommand { get; set; }

        private Storage storage;
        private EresData.Model model;
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

        public List<EresData.Students> Students
        {
            get
            {
                //if (_studentList == null)
                //{
                //    _studentList = storage.getStudents();
                //}

                //Student st = new Student() { Group = new Group() {  GroupId = 1, Name="PIerwsza", Students= null}, ID = "1", Imie = "Asdf", Nazwisko = "asd" };
                //List<Model.Student> a = new List<Student>();
                //a.Add(st);

                return model.getStudents();
            }
            set
            {
             
                OnPropertyChanged("Students");

            }
        }

        public MainWindowViewModel()
        {
            model = new EresData.Model();
            
            ButtonCommand = new RelayCommand(
           new Action<object>(delegate(object obj)
           {
              
               OnPropertyChanged("Students");

           }));
        }
    }
}