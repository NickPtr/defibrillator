using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefibrillatorBase.Model
{
    public class Def
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Posx { get; set; }
        public float Posy { get; set; }
        public string PhotoLink { get; set; }
    }
}