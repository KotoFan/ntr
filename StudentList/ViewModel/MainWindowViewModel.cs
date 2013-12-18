using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentList.Model;
using System.Windows.Input;

namespace StudentList.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        private Logic m_logic;
        public ICommand ButtonCommand { get; set; }

        private Storage storage;
        private Group _selectedGroup;
        private Student _selectedStudent;
        private List<Model.Student> _studentList;
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
        public List<Model.Student> Students
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

                return storage.getGroupStudents(_selectedGroup);
            }
            set
            {
                _studentList = value;
                OnPropertyChanged("Students");

            }
        }
        public List<Model.Group> Groups
        {
            get
            {
                return storage.getGroups();

            }
        }
        public Group SelectedGroup
        {
            get
            {
                return _selectedGroup;
            }

            set
            {
                if (value == _selectedGroup)
                    return;

                _selectedGroup = value;

                Students = storage.getGroupStudents(_selectedGroup);
                OnPropertyChanged("SelectedGroup");

            }
        }

        public Student SelectedStudent
        {
            get
            {
                return _selectedStudent;
            }

            set
            {
                if (value == _selectedStudent)
                    return;

                _selectedStudent = value;
                if (_selectedStudent != null)
                {
                    Imie = _selectedStudent.Imie;
                    Nazwisko = _selectedStudent.Nazwisko;
                }
                OnPropertyChanged("SelectedStudent");
            }
        }
        public MainWindowViewModel()
        {
            storage = new Storage();


            m_logic = new Logic(storage);

            ButtonCommand = new RelayCommand(
           new Action<object>(delegate(object obj)
           {
               m_logic.Process(obj as string, _imie, _nazwisko, SelectedGroup, SelectedStudent, SelectedGroup.GroupId);
               OnPropertyChanged("Students");

           }));
        }
    }
}