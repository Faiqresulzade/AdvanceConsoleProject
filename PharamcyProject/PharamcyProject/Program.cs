using Core;
using Core.Constants;
using DataAccess.Repositories.Concret;
using ServicesLayer.Services.Concret;
using System;
using System.Collections.Generic;

namespace PharamcyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            StartApp();
        }

        private static void StartApp()
        {
            EmployeRepository employeRepository = new EmployeRepository();

            List<Employe> employes = employeRepository.GetAll();

            if (employes.Count == 0)
            {
                employeRepository.Create(new Employe
                {
                    Name = "Faiq",
                    Surname = "Resulzade",
                    Gender = Gender.Kişi,
                    Salary = 10000,
                    Username = "superadmin",
                    Password = "admin123!",
                    RoleTypeID = 1,
                    CreateAt=DateTime.Now,
                });
            }

            AccountService accountService = new AccountService();
            accountService.Login();

        }
    }
}
