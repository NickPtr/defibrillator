using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mashine
{
    public class MapService
    {

        DefibrillatorContext db = new DefibrillatorContext();

        public List<Defibrillator> GetAll()
        {
            return db.DefibrillatorTable.ToList<Defibrillator>();
        }
    }
}
