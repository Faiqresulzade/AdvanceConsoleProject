using Core;
using Core.Helpers;
using ServicesLayer.Services.Abstract;
using System;

namespace ServicesLayer.Services.Concret
{
    public class EmployeService : IEmployeService
    {
        string name;
        public void Create()
        {
            Console.Clear();
            Employe employe = new Employe();
            do
            {
                MyConsole.Write("Ad Daxil edin: ");
                name = Console.ReadLine();
            } while (string.IsNullOrEmpty(name));


        }

        public void Delete()
        {

        }

        public void Update()
        {

        }
    }
}
