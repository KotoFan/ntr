//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EresData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Registrations
    {
        public Registrations()
        {
            this.GradeValues = new HashSet<GradeValues>();
        }
    
        public int RegistrationID { get; set; }
        public int StudentID { get; set; }
        public int RealisationID { get; set; }
        public byte[] TimeStamp { get; set; }
    
        public virtual ICollection<GradeValues> GradeValues { get; set; }
        public virtual Realisations Realisations { get; set; }
        public virtual Students Students { get; set; }
    }
}
