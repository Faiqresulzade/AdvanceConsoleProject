﻿using Core.Helpers;
using ServicesLayer.Services.Abstract;
using System;

namespace ServicesLayer.Services.Concret
{
    class AdminPanelMenu : IAdminPanelMenu
    {
        public void AdminDashboard()
        {
          
            EmployeService employeService = new EmployeService();
            DrugService drugService = new DrugService();
        Admin:
            Console.Clear();

            MyConsole.WriteLine("1.ishchi elave et", ConsoleColor.DarkMagenta);
            MyConsole.WriteLine("2.ishchi sil", ConsoleColor.DarkMagenta);
            MyConsole.WriteLine("3.Ishcini yenile", ConsoleColor.DarkMagenta);
            MyConsole.WriteLine("4.Derman elave et", ConsoleColor.DarkMagenta);
            MyConsole.WriteLine("5.Derman sil", ConsoleColor.DarkMagenta);
            MyConsole.WriteLine("6.Dermani editle", ConsoleColor.DarkMagenta);
            MyConsole.WriteLine("7.Exit", ConsoleColor.DarkMagenta);

            string adminPanelChoose = Console.ReadLine();

            switch (adminPanelChoose)
            {
                case "1":
                    employeService.Create();
                    goto Admin;
                case "2":
                    employeService.Delete();
                    goto Admin;
                case "3":
                    employeService.Update();
                    goto Admin;
                case "4":
                    drugService.Create();
                    goto Admin;
                case "5":
                    drugService.Delete();
                    goto Admin;
                case "6":
                    drugService.Update();
                    goto Admin;
                case "7":
                    break;

                default:
                    MyConsole.WriteLine("Duzgun daxil edin!!", ConsoleColor.Red);
                    break;
            }
        }
    }
}
