using Core;
using Core.Constants;
using Core.Helpers;
using Core.Models;
using DataAccess.Repositories.Concret;
using ServicesLayer.Services.Abstract;
using System;
using System.Collections.Generic;

namespace ServicesLayer.Services.Concret
{
    public class EmployeService : IEmployeService
    {
        string name;
        string Surname;
        int salary;
        string username;
        string password;
        Gender gender;
        int InputRole;
        int roleId;
        bool isvalidGender;
        int i;
        public void Create()
        {
            Console.Clear();
            RoleRepository roleRepository = new RoleRepository();
            List<RoleType> roles = roleRepository.GetAll();

            do
            {
                MyConsole.Write("Ad Daxil edin: ");
                name = Console.ReadLine();
            } while (string.IsNullOrEmpty(name) || name.Length < 3);
            do
            {
                MyConsole.Write("Surname Daxil edin: ");
                Surname = Console.ReadLine();
            } while (string.IsNullOrEmpty(Surname) || Surname.Length < 5);
            do
            {
                MyConsole.Write("Maashi daxil edin : ");
                int.TryParse(Console.ReadLine(), out salary);
            } while (salary < 100 || salary > 3000);
            do
            {
                MyConsole.Write("Username daxil edin : ");
                username = Console.ReadLine();
            } while (string.IsNullOrEmpty(username));
            do
            {
                MyConsole.Write("Passwor daxil edin : ");
                password = Console.ReadLine();
            } while (password.Length < 6);
            do
            {
                MyConsole.Write("Cinsi daxil edin : ");
                MyConsole.WriteLine("1-Kişi\n 2-Qadın");
                string genderChoose = Console.ReadLine();
                if (genderChoose == "1")
                {
                    gender = Gender.Kişi;
                    isvalidGender = false;
                }
                else if (genderChoose == "2")
                {
                    gender = Gender.Qadın;
                    isvalidGender = false;
                }
                else
                {
                    MyConsole.WriteLine("Duzgun daxil edin", ConsoleColor.Red);
                    isvalidGender = true;
                }

            } while (isvalidGender);
            do
            {
               roles = roleRepository.GetAll();

                MyConsole.WriteLine("Role daxil edin");
                for (i = 0; i < roles.Count; i++)
                {
                    MyConsole.WriteLine($"{i + 1}-{roles[i].RoleName}");
                }

                int.TryParse(Console.ReadLine(),out InputRole);

                roleId = roles[InputRole - 1].Id;
            } while (InputRole>roles.Count);

            Employe employe = new Employe()
            {
                CreateAt = DateTime.Now,
                Gender = gender,
                Name = name,
                Password = password,
                Salary = salary,
                Surname = Surname,
                Username = username,
                RoleTypeID=roleId
            };

            EmployeRepository employeRepository= new EmployeRepository();
            employeRepository.Create(employe);
        }

        public void Delete()
        {

        }

        public void Update()
        {

        }
    }
}
