
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;


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
                catch (OptimisticConcurrencyException t)
                {
                    Console.WriteLine(t);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                return true;
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
        #endregion
    }
}
