using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;


using EresData;

namespace ERES.Net.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {

        public ICommand ButtonCommand { get; set; }
        public ICommand StudentsCommands { get; set; }
        public ICommand GroupCommands { get; set; }

        private bool _studentListAddButton = false;
        public bool StudentListAddButtonActive
        {
            get { return _studentListAddButton; }

            set
            {
                _studentListAddButton = value;
                OnPropertyChanged("StudentListAddButtonActive");
            }
        }

        private bool _studentListUpdateDeleteButton = false;
        public bool StudentListUpdateDeleteButtonActive
        {
            get { return !(_selectedStudent == null); }

            set
            {
                _studentListUpdateDeleteButton = value;
                OnPropertyChanged("StudentListUpdateDeleteButtonActive");
            }
        }

        private bool _groupListUpdateDeleteButton = false;
        public bool GroupListUpdateDeleteButtonActive
        {
            get { return !(_selectedGroup == null); }

            set
            {
                _groupListUpdateDeleteButton = value;
                OnPropertyChanged("GroupListUpdateDeleteButtonActive");
            }
        }

        private EresData.Students _selectedStudent;
        private EresData.Groups _selectedGroup;
        private EresData.Model model;
        private String _imie;
        private String _nazwisko;
        private String _grupa;

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
        public String Grupa
        {
            get
            {
                return _grupa;
            }
            set
            {
                _grupa = value;
                OnPropertyChanged("Grupa");
            }
        }


        public EresData.Students SelectedStudent
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
                    Imie = _selectedStudent.FirstName;
                    Nazwisko = _selectedStudent.LastName;
                }
                StudentListUpdateDeleteButtonActive = true;
                OnPropertyChanged("SelectedStudent");
            }
        }

        public EresData.Groups SelectedGroup
        {
            get
            {
                return _selectedGroup;
            }

            set
            {
                //@TODO

                if (value == _selectedGroup)
                    return;
                
                _selectedGroup = value;


                //if (_selectedStudent != null)
                //{
                //    Imie = _selectedStudent.FirstName;
                //    Nazwisko = _selectedStudent.LastName;
                //}
                try
                {
                    if(_selectedGroup != null)
                        Grupa = _selectedGroup.Name;
                    else
                        GroupListUpdateDeleteButtonActive = false;
                }
                catch (Exception e)
                {

                }
                // Aktywacja przycisku dodawania w zakładce Lista studentów
                StudentListAddButtonActive = true;

                //aktywacja przycisków modyfikacji i usuwania w zakładce Grupy
                GroupListUpdateDeleteButtonActive = true;
                OnPropertyChanged("SelectedGroup");
                OnPropertyChanged("Students");
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
                if (SelectedGroup == null)
                    return model.getStudents();
                else
                    return model.getGroupStudents(SelectedGroup);
            }
            set
            {

                OnPropertyChanged("Students");

            }
        }

        public List<EresData.Groups> Groups
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

                return model.getGroups();
            }
            set
            {

                OnPropertyChanged("Groups");

            }
        }


        public List<EresData.Subjects> Subjects
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

                return model.getSubjects();
            }
            set
            {

                OnPropertyChanged("Subjects");

            }
        }
        public MainWindowViewModel()
        {
            model = new EresData.Model();

            StudentsCommands = new RelayCommand(
           new Action<object>(delegate(object obj)
           {

               switch (obj as string)
               {
                   case "AddStudent":
                       model.addStudent(Imie, Nazwisko, SelectedGroup);
                       break;
                   case "DeleteStudent":
                       model.delStudent(SelectedStudent);
                       break;
                   case "UpdateStudent":
                       if (!model.updateStudent(Imie, Nazwisko, SelectedStudent))
                       {
                           OnPropertyChanged("Students");
                       }
                       break;

               }
            
               OnPropertyChanged("Students");

           }));

            GroupCommands = new RelayCommand(
        new Action<object>(delegate(object obj)
        {

            switch (obj as string)
            {
                case "AddGroup":
                    model.addGroup(Grupa);
                    break;
                case "DeleteGroup":
                    model.delGroup(SelectedGroup);
                    break;
                case "UpdateGroup":
                    model.updateGroup(Grupa, SelectedGroup);
                    break;

            }
            OnPropertyChanged("Groups");
           

        }));
            ButtonCommand = new RelayCommand(
           new Action<object>(delegate(object obj)
           {

               OnPropertyChanged("Students");

           }));
        }
    }
}