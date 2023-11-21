using Core.Constants;
using Core.Models;

namespace Core
{
   public class Drug:BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DrugType DrugType { get; set; }
        public int Count { get; set; }
        public int PurchasePrice { get; set; }
        public int SalePrice { get; set; }
        private static int _id;
        public Drug()
        {
            Id = ++_id;
        }
    }
}
