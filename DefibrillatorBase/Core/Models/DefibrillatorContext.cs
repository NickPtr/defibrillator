using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class DefibrillatorContext : DbContext
    {
        public DefibrillatorContext () : base("DefaultConnection")
        {

        }
       
        public DbSet<Defibrillator> DefibrillatorTable { get; set; }
    }
}
