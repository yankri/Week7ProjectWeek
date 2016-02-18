﻿using System;
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
            Console.Title = "Bootcamp Resources Checkout System";

            string[] mainMenu = { "1 - View Students", "2 - View Available Resources", "3 - View Student Accounts", "4 - Checkout Item", "5 - Return Item", "6 - Exit", "7 - Start Over", "8 - Admin Menu\n" };
            Console.WriteLine("\nWelcome to Bootcamp Resources Checkout System!\n\n");

            Console.WriteLine("Enter a number to select a menu option: \n");
            foreach (string word in mainMenu)
            {
                Console.WriteLine(word);
            }
        }

        public void Menu()
        {
            bool close = false;

            while (close == false)
            {
                Console.Clear();
                PrintMenu();
                FileReader reader = new FileReader();
                Data data = new Data();
                FileWriter writer  = new FileWriter();
                ItemCheckOut checkout = new ItemCheckOut(); 
                ItemReturn returnItem = new ItemReturn();

                Dictionary<string, bool> resources = data.Resources;

                List<string> COList = data.COList;
                List<string> LCstudents = data.LCStudents;

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
                    case 4:
                        checkout.CheckOut();
                        break;
                    case 5:
                        returnItem.ReturnItem();
                        break;
                    case 6:
                        ClosingImage();
                        Console.WriteLine("\nSuch quitting. Very check out. Wow.\n\n");
                        close = true;
                        break;
    
                }
            }
        }

        public void ClosingImage ()
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
        }
    }
}