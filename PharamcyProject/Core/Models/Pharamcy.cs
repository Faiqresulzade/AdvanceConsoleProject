using Core.Models;

namespace Core
{
   public class Pharamcy:BaseModel
    {
        public string Name { get; set; }
        public float MinSalary { get; set; } = 200;
        public float Budget { get; set; } = 100;
        public string Location { get; set; }
        public int EmployeId { get; set; }
        public Employe Employe { get; set; }




    }
}
