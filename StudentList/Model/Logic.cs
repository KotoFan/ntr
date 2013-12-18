using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentList.ViewModel;

namespace StudentList.Model
{
    class Logic
    {
        private Storage storage;
        
        public Logic(Storage storage)
        {
            this.storage = storage;
            

        }
        public void Process(string value, string imie, string nazwisko, Group grupa, Student student, int group)
        {
            switch (value)
            {
                case "add":

                    storage.createStudent(imie, nazwisko, grupa.GroupId);
                    break;

                case "delete":
                    storage.deleteStudent(student);
                    break;

                case "update":
                    storage.updateStudent(student, imie, nazwisko, group);
                    break;


            }
           

        }
    }


}
