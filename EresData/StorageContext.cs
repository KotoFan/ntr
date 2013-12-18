using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EresData
{
    public class StorageContext : DbContext
    {
      //  public DbSet<Students> studenty { get; set; }
        public DbSet<Groups> G { get; set; }

        public StorageContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public IDbSet<Students> rududu
        {
            get { return Set<Students>(); }
        }

    }
}
