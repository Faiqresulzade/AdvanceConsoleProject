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
        Employe employe;
        RoleRepository roleRepository = new RoleRepository();
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

            List<RoleType> roles = roleRepository.GetAll();

            name = Input("Ad daxil edin: ", s => string.IsNullOrEmpty(s));
            Surname = Input("Surname Daxil edin: ",s=>string.IsNullOrEmpty(s)||s.Length<5);
            username = Input("Username daxil edin : ", s => string.IsNullOrEmpty(s) || s.Length < 5);

            do
            {
                MyConsole.Write("Maashi daxil edin : ");
                int.TryParse(Console.ReadLine(), out salary);
            } while (salary < 100 || salary > 3000);
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
            Console.Clear();
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
                isExist = employeRepository.Any(e => e.Id == id);
            } while (!isExist);

            employeRepository.Delete(employeRepository.GetbyId(id));
            MyConsole.WriteLine("Ugurla silindi", ConsoleColor.Green);

        }

        public void Update()
        {
            Console.Clear();
            Employe employe;

            do
            {
                MyConsole.WriteLine("Update etmek istediyiniz shexsin idsini daxil edin : ");
                int.TryParse(Console.ReadLine(), out int id);
                employe = employeRepository.GetbyId(id);
            } while (employe == null);
            Console.Clear();
        update:
            MyConsole.WriteLine("Sen Employenin hansi propertysini deyismek isteyirsen? ");

            MyConsole.WriteLine("1.Name\n 2.Surname\n 3.Salary\n 4.Username\n 5.Password\n 6.Gender\n 7.Role\n 8.Exit ");
            string choose = Console.ReadLine();
            switch (choose)
            {
                case "1":
                    employe.Name = InputUpdate("Yeni adi daxil et: ");
                    goto update;
                case "2":
                    employe.Surname = InputUpdate("Yeni Soyadi daxil et: ");
                    goto update;
                case "3":
                    employe.Salary = int.Parse(InputUpdate("Yeni maashi daxil edin:"));
                    goto update;
                case "4":
                    employe.Username = InputUpdate("Yeni UserName daxil et: ");
                    goto update;
                case "5":
                    MyConsole.WriteLine("Yeni Password daxil et: ");
                    string Password = Console.ReadLine();
                    employe.Password = Password;
                    goto update;
                case "6":
                    UpdateGender(employe);
                    goto update;
                case "7":
                    UpdateRole();
                    goto update;
                case "8":

                    break;
                default:
                    MyConsole.WriteLine("Duzgun daxil edin!!", ConsoleColor.Red);
                    goto update;
            }
            employeRepository.Update(employe);
        }

        private string InputUpdate(string promt, Func<int, bool> func = default)
        {
            int input;
            if (func != default)
            {
                do
                {
                    MyConsole.WriteLine($"{promt}");
                    int.TryParse(Console.ReadLine(), out input);
                } while (func(input));
                return input.ToString();
            }
            string newInput;
            do
            {
                MyConsole.WriteLine($"{promt}");
                newInput = Console.ReadLine();
            } while (string.IsNullOrEmpty(newInput));

            return newInput;
        }

        private void UpdateGender(Employe employe)
        {
            MyConsole.WriteLine($"Evvelki cins: {employe.Gender}\n 1.Kishi\n 2.Qadin");
            switch (Console.ReadLine())
            {
                case "1":
                    employe.Gender = Gender.Kişi;
                    break;
                case "2":
                    employe.Gender = Gender.Qadın;
                    break;
                default:
                    MyConsole.WriteLine("Duzgun daxil edin!!", ConsoleColor.Red);
                    UpdateGender(employe);
                    break;
            }

            MyConsole.WriteLine("Ugurla deyisildi", ConsoleColor.Green);
            Console.WriteLine(employe.Gender);
        }
        private void UpdateRole()
        {
            var roles = roleRepository.GetAll();
            do
            {
                MyConsole.WriteLine("Role daxil edin");
                for (int i = 0; i < roles.Count; i++)
                {
                    MyConsole.WriteLine($"{i + 1}-{roles[i].RoleName}");
                }

                int.TryParse(Console.ReadLine(), out InputRole);

                roleId = roles[InputRole - 1].Id;
            } while (InputRole > roles.Count);
        }

    }
}
