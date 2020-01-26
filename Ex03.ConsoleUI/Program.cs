using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUI;

namespace ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            UserMenu userMenu = new UserMenu();
            userMenu.ServeUser();
        }
    }
}
