using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    internal class UserDisplay
    {
        public void DisplayMessage(string msg)
        {
            Console.WriteLine(msg);
        }

        public void ReadLine()
        {
            Console.ReadLine();
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void displayMessageWithClear(string msg)
        {
            DisplayMessage(msg);
            Clear();
        }

        public void ClearAndDisplayMessage(string msg)
        {
            Clear();
            DisplayMessage(msg);
        }

        public void displayList<T>(List<T> list)
        {
            foreach (var item in list)
            {
                DisplayMessage(item.ToString());
            }
        }

        public void DisplayAccordingToSize<T>(List<T> list, string sizeZeroMessage, string aboveZeroMessage)
        {
            if (list.Count == 0)
            {
                DisplayMessage(sizeZeroMessage);
            }
            else
            {
                DisplayMessage(aboveZeroMessage);
                displayList(list);
            }
        }

        public void displayEmpty()
        {
            DisplayMessage(string.Empty);
        }

        public void PressAnyKeyToContinue()
        {
            displayEmpty();
            DisplayMessage("press any key to continue");
            ReadLine();
        }

        public void displayExceptionMessage(Exception exception)
        {
            ClearAndDisplayMessage(exception.Message);
            displayEmpty();
            DisplayMessage(Messages.k_PleaseTryAgainMessage);
        }

        public void GoodByePrinter()
        {
            DisplayMessage("Good bye! Please come again");
            DisplayMessage("Press any key to close the terminal");
            ReadLine();
        }
    }
}
