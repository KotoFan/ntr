//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EresData2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Students
    {
        public Students()
        {
            this.Registrations = new HashSet<Registrations>();
        }
    
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GroupID { get; set; }
        public string IndexNo { get; set; }
        public byte[] TimeStamp { get; set; }
    
        public virtual Groups Groups { get; set; }
        public virtual ICollection<Registrations> Registrations { get; set; }
    }
}
