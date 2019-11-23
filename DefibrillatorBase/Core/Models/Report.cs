using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
   public class Report
    {
        [Key]
        public int ID { get; set; }
        public string Posx { get; set; }
        public string Posy { get; set; }
        public string Type { get; set; }
        public string Comment { get; set; }
        public string Elses { get; set; }
    }
}
