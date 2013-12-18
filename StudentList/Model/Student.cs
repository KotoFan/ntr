using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StudentList.Model
{
    public class Student
    {
        [Required]
        public Group Group { get; set; }

        [MaxLength(32)] 
        
        public virtual String Imie { get; set; }
        public virtual String Nazwisko { get; set; }
        public virtual int StudentId { get; set; }

        public virtual int IndexNo { get; set; }


        public override String ToString()
        {
           
            return Imie + " " + Nazwisko;

        }

    }
}
