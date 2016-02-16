using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7Project
{
    class MainMenu
    {
        

        public void PrintMenu()
        {
            Console.Title = "Welcome to Bootcamp Resources Checkout System!";

            string[] mainMenu = { "1 - View Students", "2 - View Available Resources", "3 - View Student Accounts", "4 - Checkout Item", "5 - Return Item", "6 - Exit", "7 - Start Over", "8 - Admin Menu\n" };
            Console.WriteLine("\n\n" + Console.Title + "\n\n");

            Console.WriteLine("Enter a number to select a menu option: \n");
            foreach (string word in mainMenu)
            {
                Console.WriteLine(word);
            }
        }

        public void Menu ()
        {
            while (true)
            {
                PrintMenu();
                FileReader reader = new FileReader();

                int choice;
                string menuChoice = Console.ReadLine();
                Console.WriteLine();
                bool result = int.TryParse(menuChoice, out choice);

                switch (choice)
                {
                    case 1:
                        reader.ViewStudentList();
                        break;
                    case 2:
                        reader.AvailableResources();
                        break;
                    case 3:
                        reader.ViewStudentAccount();
                        break;
                }



            }


        }
}