using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EresData.Wrappers
{
    public class RealisationWrapper
    {

        public string Name { get; set; }
        public int RealisationID { get; set; }
        public int SubjectID { get; set; }
        public int SemesterID { get; set; }

        public override string ToString()
        {
            using (var db = new EresEntities())
            {

                Subjects tmp = db.Subjects.Find(SubjectID);
                return db.Semesters.Find(SemesterID) + " " +db.Subjects.Find(SubjectID);
            }

        }
        
    }
}
