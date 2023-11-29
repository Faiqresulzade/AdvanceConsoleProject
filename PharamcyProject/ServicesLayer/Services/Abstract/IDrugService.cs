using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesLayer.Services.Abstract
{
    interface IDrugService
    {
        void Create();
        void Update();//int id, vm model
        void Delete();//int id
    }

}
