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
        EmployeRepository employeRepository = new EmployeRepository();

        string name, Surname, username, password;
        int salary, InputRole, roleId;
        Gender gender;
        bool isvalidGender;
        private string Input(string promt, Func<string, bool> func)
        {
            string inputfromConsole;
            do
            {
                MyConsole.Write($"{promt}");
                inputfromConsole = Console.ReadLine();
            } while (func(inputfromConsole));

            return inputfromConsole;
        }
        public void Create()
        {
            Console.Clear();

            RoleRepository roleRepository = new RoleRepository();
            List<RoleType> roles = roleRepository.GetAll();

            name = Input("Ad daxil edin: ", s => string.IsNullOrEmpty(s));

            //do
            //{
            //    MyConsole.Write("Ad Daxil edin: ");
            //    name = Console.ReadLine();
            //} while (string.IsNullOrEmpty(name) || name.Length < 3);
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
                for (int i = 0; i < roles.Count; i++)
                {
                    MyConsole.WriteLine($"{i + 1}-{roles[i].RoleName}");
                }

                int.TryParse(Console.ReadLine(), out InputRole);

                roleId = roles[InputRole - 1].Id;
            } while (InputRole > roles.Count);

            Employe employe = new Employe()
            {
                CreateAt = DateTime.Now,
                Gender = gender,
                Name = name,
                Password = password,
                Salary = salary,
                Surname = Surname,
                Username = username,
                RoleTypeID = roleId
            };


            employeRepository.Create(employe);
            MyConsole.WriteFormat("Ishci ugurla elave edildi", ConsoleColor.Green);
            Console.Clear();
        }

        public void Delete()
        {
            bool isExist;
            int id;
            List<Employe> employes = employeRepository.GetAll();
            Console.WriteLine("Hansi Idli Employeni silmek isteyirsen?");
            foreach (var employe in employes)
            {
                Console.WriteLine($"employe Id:{employe.Id},EmployeName: {employe.Name}");
            }

            do
            {
                int.TryParse(Console.ReadLine(), out id);
                //id=1;
                isExist = employeRepository.Any(e => e.Id == id);
            } while (!isExist);

            employeRepository.Delete(employeRepository.GetbyId(id));
            MyConsole.WriteLine("Ugurla silindi", ConsoleColor.Green);

        }

        public void Update()
        {
            Employe employe;

            do
            {
                MyConsole.WriteLine("Update etmek istediyiniz shexsin idsini daxil edin : ");
                int.TryParse(Console.ReadLine(), out int id);
                employe = employeRepository.GetbyId(id);
            } while (employe == null);

            MyConsole.WriteLine("Sen Employenin hansi propertysini deyismek isteyirsen? ", ConsoleColor.Gray);

            MyConsole.WriteLine("1.Name\n 2.Surname\n 3.Salary\n 4.Username\n 5.Password\n 6.Gender\n 7.Role\n ");
            string choose = Console.ReadLine();
            switch (choose)
            {

                case "1":
                    MyConsole.WriteLine("Yeni adi daxil et: ");
                    string newName = Console.ReadLine();
                    employe.Name = newName;
                    break;
                case "2":
                    MyConsole.WriteLine("Yeni Soyadi daxil et: ");
                    string newSurName = Console.ReadLine();
                    employe.Surname = newSurName;
                    break;
                case "3":
                    MyConsole.WriteLine("Yeni Soyadi daxil et: ");
                    int.TryParse(Console.ReadLine(), out int newSalary);
                    employe.Salary = newSalary;
                    break;
                case "4":
                    MyConsole.WriteLine("Yeni username daxil et: ");
                    string newUsername = Console.ReadLine();
                    employe.Username = newUsername;
                    break;
                case "5":
                    MyConsole.WriteLine("Yeni Password daxil et: ");
                    string Password = Console.ReadLine();
                    employe.Password = Password;
                    break;
                default:
                    break;

            }
            employeRepository.Update(employe);
        }
    }
}
