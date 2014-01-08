using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;


using EresData;
using System.ComponentModel;

namespace ERES.Net.ViewModel
{
    class MainWindowViewModel : ViewModelBase, IDataErrorInfo
    {

        public ICommand ButtonCommand { get; set; }
        public ICommand StudentsCommands { get; set; }
        public ICommand GroupCommands { get; set; }
        public ICommand SubjectCommands { get; set; }
        public ICommand RealisationCommands { get; set; }
        public ICommand SemesterCommands { get; set; }

        private bool synchroStudentCheck = true;

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



        private EresData.Model model;

        private String _imie;
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

        private String _nazwisko;
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



        #region Studenci
        private EresData.Students _selectedStudent;
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
                    synchroStudentCheck = true;
                }
                StudentListUpdateDeleteButtonActive = true;
                OnPropertyChanged("SelectedStudent");
            }
        }

        private EresData.Groups _studentSelectedGroup;
        public EresData.Groups StudentSelectedGroup
        {
            get
            {
                return _studentSelectedGroup;
            }

            set
            {
                //@TODO

                if (value == _studentSelectedGroup)
                    return;

                _studentSelectedGroup = value;


                // Aktywacja przycisku dodawania w zakładce Lista studentów
                StudentListAddButtonActive = true;


                OnPropertyChanged("StudentSelectedGroup");
                OnPropertyChanged("Students");
            }
        }

        #endregion

        #region Grupy
        private String _grupa;
        //Dla tb w zakldce grupy
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
        private EresData.Groups _selectedGroup;
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

                try
                {
                    if (_selectedGroup != null)
                        Grupa = _selectedGroup.Name;
                    else
                        GroupListUpdateDeleteButtonActive = false;
                }
                catch (Exception e)
                {

                }

                //aktywacja przycisków modyfikacji i usuwania w zakładce Grupy
                GroupListUpdateDeleteButtonActive = true;
                OnPropertyChanged("SelectedGroup");
                OnPropertyChanged("Students");
            }
        }
        #endregion

        #region Realizacje
        private EresData.Realisations _selectedRealisation;
        public EresData.Realisations SelectedRealisation
        {
            get
            {
                return _selectedRealisation;
            }

            set
            {
                if (value == _selectedRealisation)
                    return;

                _selectedRealisation = value;

                if (_selectedRealisation != null)
                {

                    RealisationSelectedSemester = Semesters.Where(x => x.SemesterID == _selectedRealisation.SemesterID).Single(); ;
                    RealisationSelectedSubject = Subjects.Where(x => x.SubjectID == _selectedRealisation.SubjectID).Single();
                }




                //aktywacja przycisków modyfikacji i usuwania w zakładce Grupy
                GroupListUpdateDeleteButtonActive = true;
                OnPropertyChanged("SelectedRealisation");


            }
        }

        private EresData.Semesters _realisationSelectedSemester;
        public EresData.Semesters RealisationSelectedSemester
        {
            get
            {
                return _realisationSelectedSemester;
            }

            set
            {
                //@TODO

                if (value == _realisationSelectedSemester)
                    return;

                _realisationSelectedSemester = value;

                OnPropertyChanged("SelectedSemester");


            }
        }

        private EresData.Subjects _realisationSelectedSubject;
        public EresData.Subjects RealisationSelectedSubject
        {
            get
            {
                return _realisationSelectedSubject;
            }

            set
            {
                //@TODO

                if (value == _realisationSelectedSubject)
                    return;

                _realisationSelectedSubject = value;

                OnPropertyChanged("RealisationSelectedSubject");


            }
        }
        #endregion

        #region Przedmioty
        private String _przedmiot;
        //Dla tb w zakldce grupy
        public String Przedmiot
        {
            get
            {
                return _przedmiot;
            }
            set
            {
                _przedmiot = value;
                OnPropertyChanged("Przedmiot");
            }
        }

        private EresData.Subjects _selectedSubject;
        public EresData.Subjects SelectedSubject
        {
            get
            {
                return _selectedSubject;
            }

            set
            {
                //@TODO

                if (value == _selectedSubject)
                    return;

                _selectedSubject = value;
                try
                {
                    if (_selectedSubject != null)
                        Przedmiot = _selectedSubject.Name;

                }
                catch (Exception e)
                {

                }
                OnPropertyChanged("SelectedSubject");


            }
        }

        #endregion

        #region Semestry

        private String _semestr;
        //Dla tb w zakldce grupy
        public String Semestr
        {
            get
            {
                return _semestr;
            }
            set
            {
                _semestr = value;
                OnPropertyChanged("Semestr");
            }
        }

        private EresData.Semesters _semestersSelectedSemester;
        public EresData.Semesters SemestersSelectedSemester
        {
            get
            {
                return _semestersSelectedSemester;
            }

            set
            {
                //@TODO

                if (value == _semestersSelectedSemester)
                    return;

                _semestersSelectedSemester = value;
                try
                {
                    if (_semestersSelectedSemester != null)
                        Semestr = _semestersSelectedSemester.Name;

                }
                catch (Exception e)
                {

                }
                OnPropertyChanged("SemestersSelectedSemester");


            }
        }
        #endregion

        #region Realizacje-oceny
        private String _ocena;
        //Dla tb w zakldce grupy
        public String Ocena
        {
            get
            {
                return _ocena;
            }
            set
            {
                _ocena = value;
                OnPropertyChanged("Ocena");
            }
        }
        private EresData.Realisations _gradeSelectedRealisation;
        public EresData.Realisations GradeSelectedRealisation
        {
            get
            {
                return _gradeSelectedRealisation;
            }

            set
            {
                if (value == _gradeSelectedRealisation)
                    return;

                _gradeSelectedRealisation = value;

                OnPropertyChanged("GradeSelectedRealisation");


            }
        }
        #endregion

        // Listy obiektów

        public List<EresData.Students> Students
        {
            get
            {
                if (StudentSelectedGroup == null)
                    return model.getStudents();
                else
                    return model.getGroupStudents(StudentSelectedGroup);
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

        private List<EresData.Subjects> _subjects;
        public List<EresData.Subjects> Subjects
        {
            get
            {
                if (_subjects == null)
                    _subjects = model.getSubjects();
                return _subjects;

            }
            set
            {
                _subjects = value;
                OnPropertyChanged("Subjects");

            }
        }

        private List<EresData.Semesters> _semesters;
        public List<EresData.Semesters> Semesters
        {
            get
            {
                if (_semesters == null)
                    _semesters = model.getSemesters();
                return _semesters;
            }
            set
            {

                _semesters = model.getSemesters();
                OnPropertyChanged("Semesters");

            }
        }

        private List<EresData.Realisations> _realisations;
        public List<EresData.Realisations> Realisations
        {
            get
            {
                if (_realisations == null)
                    _realisations = model.getRealisations();
                return _realisations;
            }
            set
            {
                _realisations = value;
                OnPropertyChanged("Realisations");

            }
        }


        private List<EresData.Grades> _grades;
        public List<EresData.Grades> Grades
        {
            get
            {
                if (_grades == null)
                    _grades = model.getGrades();
                return _grades;
            }
            set
            {
                _grades = value;
                OnPropertyChanged("Grades");

            }
        }



        public MainWindowViewModel()
        {
            model = new EresData.Model();
            Subjects = model.getSubjects();
            StudentsCommands = new RelayCommand(
           new Action<object>(delegate(object obj)
           {
               try
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
                               synchroStudentCheck = false;
                               SelectedStudent = model.refreshStudent(SelectedStudent);
                               StudentListUpdateDeleteButtonActive = false;

                           }
                           break;

                   }
               }
               catch (Exception e)
               {
                   Console.WriteLine(e);
                   synchroStudentCheck = false;
                   Imie = "";
                   Nazwisko = "";
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

            SubjectCommands = new RelayCommand(
           new Action<object>(delegate(object obj)
           {
               switch (obj as string)
               {
                   case "Add":
                       model.addSubject(Przedmiot);
                       break;
                   case "Delete":
                       model.delSubject(SelectedSubject);
                       break;
                   case "Update":
                       model.updateSubject(Przedmiot, SelectedSubject);
                       break;

               }
               Subjects = model.getSubjects();


           }));

            SubjectCommands = new RelayCommand(
new Action<object>(delegate(object obj)
{
    switch (obj as string)
    {
        case "Add":
            model.addSubject(Przedmiot);
            break;
        case "Delete":
            model.delSubject(SelectedSubject);
            break;
        case "Update":
            model.updateSubject(Przedmiot, SelectedSubject);
            break;

    }
    Subjects = model.getSubjects();


}));

            SemesterCommands = new RelayCommand(
new Action<object>(delegate(object obj)
{
    switch (obj as string)
    {
        case "Add":
            model.addSemester(Semestr);
            break;
        case "Delete":
            model.delSubject(SelectedSubject);
            break;
        case "Update":
            model.updateSubject(Przedmiot, SelectedSubject);
            break;

    }
    Semesters = model.getSemesters();


}));

            RealisationCommands = new RelayCommand(
           new Action<object>(delegate(object obj)
           {
               switch (obj as string)
               {
                   case "Add":
                       model.addRealisation(RealisationSelectedSemester.SemesterID, RealisationSelectedSubject.SubjectID);
                       break;
                   case "Delete":
                       if (SelectedRealisation != null)
                           model.delRealisation(SelectedRealisation);
                       else if (RealisationSelectedSubject != null && RealisationSelectedSemester != null)
                       {
                           List<Realisations> ob = Realisations.Where(x => x.SemesterID == RealisationSelectedSemester.SemesterID &&
                               x.SubjectID == RealisationSelectedSubject.SubjectID).ToList();
                           if (ob.Count() != 0)
                               model.delRealisation(ob.First());
                       }
                       break;
                   case "Update":
                       model.updateRealisation(RealisationSelectedSemester.SemesterID, RealisationSelectedSubject.SubjectID, SelectedRealisation);
                       break;

               }
               Realisations = model.getRealisations();


           }));

        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string item]
        {
            get
            {

                string result = string.Empty;

                switch (item)
                {

                    case "Imie":
                        if (Imie != null && !synchroStudentCheck)
                            result = "Zmiana poza programem.";
                        else if (string.IsNullOrEmpty(Imie))
                        {
                            result = "Pole nie może być puste";
                        }
                        break;
                    case "Nazwisko":
                        if (Nazwisko != null && !synchroStudentCheck)
                            result = "Zmiana poza programem.";
                        else if (string.IsNullOrEmpty(Nazwisko))
                        {
                            result = "Pole nie może być puste";
                        }
                        break;

                };

                return result;
            }
        }
    }
}