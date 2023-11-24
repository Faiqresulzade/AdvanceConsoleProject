using Core;
using Core.Helpers;
using DataAccess.Repositories.Concret;
using ServicesLayer.Services.Abstract;
using System;
namespace ServicesLayer.Services.Concret
{
    public class AccountService : IAcountService
    {
        AccountRepository accountRepository = new AccountRepository();
        private bool incorrectlogin = true;

        public void Login()
        {
            string userName;
            string password;
            do
            {
                if (!incorrectlogin)
                {
                    MyConsole.Write("Parol Və ya username səhvdir",ConsoleColor.Red);
                }
                incorrectlogin = false;

                MyConsole.Write("Usernami daxil edin: ");
                userName = Console.ReadLine();
                MyConsole.Write("PassWord daxil edin: ");
                password = Console.ReadLine();
            }
            while (!accountRepository.Any(emp => emp.Password == password && emp.Username == userName));

            MyConsole.WriteFormat("Xoş Gəlmisiniz",ConsoleColor.Green);

            MainMenu mainMenu = new MainMenu();
            mainMenu.AdminChoose();
        }

        public void Register(Employe employe)
        {

        }

    }
}
