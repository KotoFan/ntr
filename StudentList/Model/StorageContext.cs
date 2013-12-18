using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace StudentList.Model
{
    public class StorageContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }

        public StorageContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }


    }
}
