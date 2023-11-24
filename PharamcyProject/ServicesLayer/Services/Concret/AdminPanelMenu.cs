using Core.Helpers;
using ServicesLayer.Services.Abstract;
using System;

namespace ServicesLayer.Services.Concret
{
    class AdminPanelMenu : IAdminPanelMenu
    {
        public void AdminDashboard()
        {
            Console.Clear();
            EmployeService employeService = new EmployeService();

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
                    break;
                case "2":
                    employeService.Delete();
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "6":
                    break;
                case "7":
                    break;

                default:
                    break;
            }
        }
    }
}
