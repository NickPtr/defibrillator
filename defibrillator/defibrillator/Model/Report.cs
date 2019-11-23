using System;
using System.Collections.Generic;
using System.Text;

namespace defibrillator.Model
{
    class Report
    {
        public int ID { get; set; }
        public string Posx { get; set; }
        public string Posy { get; set; }
        public string Type { get; set; }
        public string Comment { get; set; }
        public string Elses { get; set; }
    }
}
