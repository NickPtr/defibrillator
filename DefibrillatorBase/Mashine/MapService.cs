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
        ReportContext rep = new ReportContext ();

        public List<Defibrillator> GetAll()
        {
            return db.DefibrillatorTable.ToList<Defibrillator>();
        }

        public void AddNew(Defibrillator def)
        {
            db.DefibrillatorTable.Add(def);
            db.SaveChanges();
        }

        public bool Update(Defibrillator defibrillator)
        {
            Defibrillator def = db.DefibrillatorTable.Where(d => d.Posx == defibrillator.Posx && d.Posy == defibrillator.Posy).First();
            def.Name = defibrillator.Name;
            def.Description = defibrillator.Description;
            db.SaveChanges();
            return true;
        }

        public List<Report> GetReports ()
        {
            return rep.ReportTable.ToList<Report>();
        }

        public void SendReport(Report report)
        {
           using(ReportContext db = new ReportContext())
           {
               db.ReportTable.Add(report);
               db.SaveChanges();
           }
        }
    }
}
