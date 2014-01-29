using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentList.Model
{
    class Storage
    {
        public List<Student> getStudents()
        {
            using (var db = new StorageContext())
                return db.Students.ToList();
        }
        public List<Group> getGroups()
        {
            using (var db = new StorageContext())
                return db.Groups.ToList();
        }
        public List<Student> getGroupStudents(Group selectedGroup)
        {
            using (var db = new StorageContext())
                return db.Students.Where(student => student.Group.GroupId == selectedGroup.GroupId).ToList();
        }

        public void createStudent(string firstName, string lastName, int groupId)
        {

            using (var db = new StorageContext())
            {

                var group = db.Groups.Find(groupId);

                var student = new Student { Imie = firstName, Nazwisko = lastName, IndexNo = (new Random().Next(1, 10000)), Group = group };

                db.Students.Add(student);

                db.SaveChanges();

            }
        }

        public void updateStudent(Student student, string imie, string nazwisko, int groupId)
        {
            try
            {
                using (var db = new StorageContext())
                {
                    var original = db.Students.Find(student.StudentId);
                    if (original != null)
                    {
                        original.Group = db.Groups.Find(groupId);
                        original.Imie = imie;
                        original.Nazwisko = nazwisko;
                        try
                        {
                            db.SaveChanges();
                        }
                        catch (DbEntityValidationException dbEx)
                        {
                            foreach (var validationErrors in dbEx.EntityValidationErrors)
                            {
                                foreach (var validationError in validationErrors.ValidationErrors)
                                {
                                    Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());

            }
        }

        public void deleteStudent(Student student)
        {
            try
            {
                using (var db = new StorageContext())
                {
                    var original = db.Students.Find(student.StudentId);
                    if (original != null)
                    {
                        db.Students.Remove(original);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
        }

    }
}
