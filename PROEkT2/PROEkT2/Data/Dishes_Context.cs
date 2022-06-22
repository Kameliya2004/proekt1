using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROEkT2.Data
{
    public class Dishes_Context : DbContext
    {
        public Dishes_Context()
       : base("name=Dishes_Context")
        {

        }
        public DbSet<Dishes> Dishes { get; set; }
        public DbSet<Dishes_Type> Dishes_Types { get; set; }
    }
    
}
