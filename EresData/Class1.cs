
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EresData
{
    public class Model
    {
        public Model()
        {
            
        }

        public List<Students>  getStudents()
        {

         

            var db = new EresEntities();
            return db.Students.ToList();
         
        }

    }
}
