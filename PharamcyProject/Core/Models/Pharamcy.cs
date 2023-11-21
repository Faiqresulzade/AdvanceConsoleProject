using Core.Models;
using System.Collections.Generic;

namespace Core
{
   public class Pharamcy:BaseModel
    {
        public string Name { get; set; }
        public float MinSalary { get; set; } = 200;
        public float Budget { get; set; } = 100;
        public string Location { get; set; }

        public List<Employe> Employe;

        //public Pharamcy()
        //{
        //    Employe = new List<Employe>();
        //}
    }
}
