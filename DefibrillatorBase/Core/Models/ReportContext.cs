using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ReportContext :DbContext
    {

        public ReportContext() : base("DefaultConnection")
        {

        }

        public DbSet<Report> ReportTable { get; set; }
    }
}
