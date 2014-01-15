
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using EresData.Wrappers;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace EresData
{
    public class Model
    {
        public Model()
        {

        }

        #region Students

        public List<Students> getStudents()
        {
            using (var db = new EresEntities())
            {
                return db.Students.ToList();
            }
        }

        public List<Students> getGroupStudents(Groups g)
        {
            using (var db = new EresEntities())
            {
                return db.Students.Where(s => s.GroupID == g.GroupID).ToList();
            }
        }

        public void addStudent(string imie, string nazwisko, Groups g)
        {
            using (var db = new EresEntities())
            {
                Students s = new Students();
                s.FirstName = imie;
                s.LastName = nazwisko;
                s.GroupID = db.Groups.Where(grp => grp.GroupID == g.GroupID).Single().GroupID;
                s.IndexNo = (Int32.Parse(db.Students.OrderByDescending(stud => stud.IndexNo).First().IndexNo) + 1).ToString();
                s.TimeStamp = BitConverter.GetBytes(DateTime.Now.ToBinary());

                try
                {
                    db.Students.Add(s);
                    db.SaveChanges();
                }
                catch (OptimisticConcurrencyException t)
                {
                    Console.WriteLine(t);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void delStudent(Students s)
        {
            using (var db = new EresEntities())
            {
                try
                {
                    db.Students.Attach(s);
                    db.Students.Remove(s);
                    db.SaveChanges();
                }
                catch (OptimisticConcurrencyException t)
                {
                    Console.WriteLine(t);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public bool updateStudent(string imie, string nazwisko, Students s)
        {
            using (var db = new EresEntities())
            {
                try
                {
                    Students tmp = db.Students.Find(s.StudentID);

                    if (tmp == null)
                        throw new Exception("Deleted");
                    if (!tmp.TimeStamp.SequenceEqual(s.TimeStamp))
                        return false;

                    tmp.FirstName = imie;
                    tmp.LastName = nazwisko;
                    db.Entry(tmp).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    if (e.Message == "Deleted")
                        throw;
                }
                return true;
            }
        }

        public Students refreshStudent(Students s)
        {
            using (var db = new EresEntities())
            {
                try
                {
                    return db.Students.Find(s.StudentID);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }
        }

        #endregion

        #region Grupy

        public List<Groups> getGroups()
        {
            using (var db = new EresEntities())
            {
                return db.Groups.ToList();
            }
        }
        public void addGroup(string nazwa)
        {
            using (var db = new EresEntities())
            {
                Groups g = new Groups();
                g.Name = nazwa;

                try
                {
                    db.Groups.Add(g);
                    db.SaveChanges();
                }
                catch (OptimisticConcurrencyException t)
                {
                    Console.WriteLine(t);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void delGroup(Groups g)
        {
            using (var db = new EresEntities())
            {
                try
                {
                    db.Groups.Attach(g);
                    db.Groups.Remove(g);
                    db.SaveChanges();
                }
                catch (OptimisticConcurrencyException t)
                {
                    Console.WriteLine(t);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void updateGroup(string nazwa, Groups g)
        {
            using (var db = new EresEntities())
            {
                try
                {
                    db.Groups.Attach(g);
                    //Groups tmp = db.Groups.Find(g.GroupID);
                    g.Name = nazwa;
                    db.Entry(g).State = System.Data.Entity.EntityState.Modified;

                    List<Students> test = g.Students.ToList();
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine(ex);
                }
                catch (OptimisticConcurrencyException t)
                {
                    Console.WriteLine(t);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        #endregion

        #region Przedmioty

        public List<Subjects> getSubjects()
        {
            using (var db = new EresEntities())
            {
                return db.Subjects.ToList();
            }
        }

        public void addSubject(string nazwa)
        {
            using (var db = new EresEntities())
            {
                Subjects g = new Subjects();
                g.Name = nazwa;
                g.Conspect = "";
                g.TimeStamp = BitConverter.GetBytes(DateTime.Now.ToBinary());
                try
                {
                    db.Subjects.Add(g);
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
                catch (OptimisticConcurrencyException t)
                {
                    Console.WriteLine(t);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }
            }
        }

        public void delSubject(Subjects g)
        {
            using (var db = new EresEntities())
            {
                try
                {

                    db.Subjects.Attach(g);
                    db.Subjects.Remove(g);
                    db.SaveChanges();
                }
                catch (OptimisticConcurrencyException t)
                {
                    Console.WriteLine(t);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void updateSubject(string nazwa, Subjects g)
        {
            using (var db = new EresEntities())
            {
                try
                {
                    db.Subjects.Attach(g);

                    g.Name = nazwa;
                    db.Entry(g).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine(ex);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        #endregion

        #region Semestry

        public List<Semesters> getSemesters()
        {
            using (var db = new EresEntities())
            {
                return db.Semesters.ToList();
            }
        }
        public Semesters getSemester(int SemesterID)
        {
            using (var db = new EresEntities())
            {
                return db.Semesters.Find(SemesterID);
            }
        }

        public void addSemester(string name)
        {
            using (var db = new EresEntities())
            {
                Semesters g = new Semesters();
                g.Name = name;


                g.TimeStamp = BitConverter.GetBytes(DateTime.Now.ToBinary());
                try
                {
                    db.Semesters.Add(g);
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
                catch (OptimisticConcurrencyException t)
                {
                    Console.WriteLine(t);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void delSemester(Semesters g)
        {
            using (var db = new EresEntities())
            {
                try
                {

                    db.Semesters.Attach(g);
                    db.Semesters.Remove(g);
                    db.SaveChanges();
                }
                catch (OptimisticConcurrencyException t)
                {
                    Console.WriteLine(t);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void updateSemesters(string name, Semesters g)
        {
            using (var db = new EresEntities())
            {
                try
                {
                    db.Semesters.Attach(g);

                    g.Name = name;

                    db.Entry(g).State = System.Data.Entity.EntityState.Modified;

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
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine(ex);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        #endregion

        #region Realizacje

        //public List<RealisationWrapper> getRealisations()
        //{
        //    using (var db = new EresEntities())
        //    {
        //        var ob = (from c in db.Realisations
        //                      join s in db.Semesters on c.SemesterID equals s.SemesterID
        //                      select new {s.Name, c.RealisationID, c.SemesterID, c.SubjectID}).OrderBy(x => x.Name);

        //        List<RealisationWrapper> result = new List<RealisationWrapper>();

        //        foreach (var x in ob)
        //        {
        //            result.Add(new RealisationWrapper() { Name = x.Name, RealisationID = x.RealisationID, SemesterID = x.SemesterID, SubjectID = x.SubjectID });
        //        }
        //        return result ;
        //    }
        //} return db.Registrations.Include("Student").Include("Realisation").Include("Realisation.Subject").Include("Realisation.Semester").ToList();
        public List<Realisations> getRealisations()
        {
            using (var db = new EresEntities())
            {
                return db.Realisations.Include("Semesters").Include("Subjects").OrderBy(x => x.Semesters.Name).ToList();
            }

        }


        public void addRealisation(int SemesterID, int SubjectID)
        {
            using (var db = new EresEntities())
            {
                Realisations g = new Realisations();
                g.SemesterID = SemesterID;
                g.SubjectID = SubjectID;

                g.TimeStamp = BitConverter.GetBytes(DateTime.Now.ToBinary());
                try
                {
                    db.Realisations.Add(g);
                    db.SaveChanges();
                }

                catch (OptimisticConcurrencyException t)
                {
                    Console.WriteLine(t);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void delRealisation(Realisations g)
        {
            using (var db = new EresEntities())
            {
                try
                {

                    db.Realisations.Attach(g);
                    db.Realisations.Remove(g);
                    db.SaveChanges();
                }
                catch (OptimisticConcurrencyException t)
                {
                    Console.WriteLine(t);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void updateRealisation(int SemesterID, int SubjectID, Realisations g)
        {
            using (var db = new EresEntities())
            {
                try
                {
                    db.Realisations.Attach(g);

                    g.SemesterID = SemesterID;
                    g.SubjectID = SubjectID;
                    db.Entry(g).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine(ex);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        #endregion

        #region Realizacje-oceny

        public List<Grades> getGrades()
        {

            using (var db = new EresEntities())
            {
                return db.Grades.Include("Realisations").OrderBy(x => x.Realisations.Semesters.Name).ThenBy(n => n.Realisations.Subjects.Name).ThenBy(n => n.Name).ToList();
            }
        }
        public List<Grades> getRealisationGrades(int RealisationID)
        {

            using (var db = new EresEntities())
            {
                return db.Grades.Include("Realisations").Where(x => x.RealisationID == RealisationID).OrderBy(x => x.Realisations.Semesters.Name).ThenBy(n => n.Realisations.Subjects.Name).ThenBy(n => n.Name).ToList();
            }
        }

        public void addGrade(string nazwa, string MaxValue, Realisations r)
        {
            using (var db = new EresEntities())
            {
                Grades g = new Grades();
                g.Name = nazwa;
                g.MaxValue = MaxValue;
                g.RealisationID = r.RealisationID;
                g.TimeStamp = BitConverter.GetBytes(DateTime.Now.ToBinary());
                try
                {
                    db.Grades.Add(g);
                    db.SaveChanges();
                }
                catch (OptimisticConcurrencyException t)
                {
                    Console.WriteLine(t);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }
            }
        }

        public void delGrade(Grades g)
        {
            using (var db = new EresEntities())
            {
                try
                {

                    db.Grades.Attach(g);
                    db.Grades.Remove(g);
                    db.SaveChanges();
                }
                catch (OptimisticConcurrencyException t)
                {
                    Console.WriteLine(t);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void updateGrade(string nazwa, string wartosc, Realisations r, Grades g)
        {
            using (var db = new EresEntities())
            {
                try
                {
                    db.Grades.Attach(g);

                    g.Name = nazwa;
                    g.MaxValue = wartosc;
                    g.RealisationID = r.RealisationID;
                    db.Entry(g).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine(ex);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        #endregion
    }
}
