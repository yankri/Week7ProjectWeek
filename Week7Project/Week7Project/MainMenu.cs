using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7Project
{
    class MainMenu //This class deals with the main menu
    {
        public void PrintMenu() //prints the main menu
        {
            Console.Title = "Bootcamp Resources Checkout System";
            StringBuilder menu = new StringBuilder();

            string[] mainMenu = { "1 - View Students", "2 - View Available Resources", "3 - View All Checked Out Resources", "4 - View Student Accounts", "5 - Checkout Item", "6 - Return Item", "7 - Exit\n" };
            Console.WriteLine("\nWelcome to Bootcamp Resources Checkout System!\n\n");
            Console.WriteLine("Enter a number to select a menu option: \n");

            foreach (string word in mainMenu)
            {
                menu.AppendLine(word);
            }
            Console.WriteLine(menu);
        }

        public void Menu() //initializes all the classes and handles menu option input
        {
            bool close = false;

            while (close == false)
            {
                Console.Clear();
                PrintMenu();
                Data data = new Data();
                FileReader reader = new FileReader(data);
                FileWriter writer  = new FileWriter(data);
                ItemCheckOut checkout = new ItemCheckOut(data); 
                ItemReturn returnItem = new ItemReturn(data);
                Dictionary<string, bool> resources = data.Resources;
                Dictionary<string, List<string>> studentCheckOuts = data.StudentCheckOuts;
                AdminMenu admin = new AdminMenu(data);

                int choice;
                string menuChoice = Console.ReadLine();
                Console.WriteLine();

                bool quitter = data.MenuQuitter(menuChoice);
                if (quitter == true)
                {
                    return;
                }

                bool result = int.TryParse(menuChoice, out choice);

                switch (choice)
                {
                    case 1:
                        reader.ViewStudentList();
                        break;
                    case 2:
                        reader.PrintAvailableResources();
                        break;
                    case 3:
                        reader.PrintCheckedOutResources();
                        break;
                    case 4:
                        reader.ViewStudentAccount();
                        break;
                    case 5:
                        checkout.CheckOut();
                        break;
                    case 6:
                        returnItem.ReturnItem();
                        break;
                    case 7:
                        ClosingImage();
                        close = true;
                        break;
                        /*
                    case 8:
                        admin.RunAdminMenu();
                        break; */
                    default:
                        continue;
                }
            }
        }

        public void ClosingImage () //Prints a closing image on exit
        {
            Console.Clear();
            StreamReader reader = new StreamReader("ClosingImage.txt");
            using (reader)
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Console.WriteLine(line);
                }
            }

            Console.WriteLine("\nSuch quitting. Very check out. Wow.\n\n");
        }
    }
}