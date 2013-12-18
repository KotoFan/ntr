using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERES.Net.Model.Database;


namespace ERES.Net.Model
{
    public class Storage
    {
        private EresDataContext cont;


        public Storage()
        {
            cont  = new EresDataContext();

        }

        public List<Student> getAllStudents()
        {
            var ob = ( from s in cont.Students select s);

            try
            {
                if (ob.Count() != 0)
                    return ob.ToList<Student>();

            }
            catch (Exception)
            {
 
            }
            return new List<Student>();
        }



    }
}
