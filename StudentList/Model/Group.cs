using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentList.Model
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public virtual List <Student> Students { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

}
