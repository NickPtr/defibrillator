using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }

    
}
