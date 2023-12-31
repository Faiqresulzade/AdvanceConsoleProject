﻿using Core.Constants;
using Core.Models;

namespace Core
{
   public class Drug:BaseModel
    {
        public string Name { get; set; }
        public DrugType DrugType { get; set; }
        public int Count { get; set; }
        public int PurchasePrice { get; set; }
        public int SalePrice { get; set; }
    }
}
