using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Week7Project
{
    //This isn't quite finished yet. I just didn't have time to complete all menu options. 
    //Add/Delete student and add/delete resources works, but not reset. Assigning a student an ID isn't permanent yet either. 
    //Will update later to finish the admin menu.
    class AdminMenu
    {
        public Data data { get; set; }

        public AdminMenu(Data data)
        {
            this.data = data;
            reader = new FileReader(data);
            writer = new FileWriter(data);
        }

        FileReader reader;
        FileWriter writer;

        public void PrintAdminMenu()
        {
           List<string> menu = new List<string>() { "A - Add a student", "B - Delete a Student", "C - Add a Resource", "D - Delete a Resource", "E - Reset All Accounts", "F - Return to Main Menu"};

            foreach (string option in menu)
            {
                Console.WriteLine(option);
            }
        }

        public void RunAdminMenu()
        {
            int counter = 0;
            bool passwordEntered = false;

            while (true)
            {
                if (passwordEntered == false)
                {
                    Console.WriteLine("Please enter the admin password to continue: ");
                    string input = Console.ReadLine();

                    bool quitter = data.MenuQuitter(input);
                    if (quitter == true)
                    {
                        return;
                    }

                    if (counter == 2)
                    {
                        Console.WriteLine("You entered the password incorrectly too many times. Exiting to main menu.");
                        return;
                    }

                    if (!input.Equals(data.Password))
                    {
                        Console.WriteLine("INVALID PASSWORD");
                        counter++;
                        continue;
                    }
                    else
                    {
                        passwordEntered = true;
                    }
                }
                else
                {
                    PrintAdminMenu();

                    string choice = Console.ReadLine().ToUpper();

                    switch (choice)
                    {
                        case "A":
                            //add student
                            AddStudent();
                            break;
                        case "B":
                            DeleteStudent();
                            //delete student
                            break;
                        case "C":
                            AddResource(); 
                            //add resource
                            break;
                        case "D":
                            //delete resource
                            RemoveResource();
                            break;
                        case "E":
                            //reset files/accounts
                            break;
                        case "F":
                            Console.WriteLine("Returning to main menu. Press any key to continue.");
                            Console.ReadKey();
                            return;
                        default:
                            continue;
                    }
                }
            }
        }

        public void AddStudent() //update master student list too
        {
            Dictionary<string, List<string>> students = data.StudentCheckOuts;

            Console.WriteLine("Enter the student's name you want to add: ");
            string name = Console.ReadLine();

            if (students.Keys.Contains(name))
            {
                Console.WriteLine("That student is already in the system");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
            else
            {
                string ID = data.AddStudentID();
                data.StudentCheckOuts.Add(name, new List<string>());
                data.StudentIDs.Add(name, ID);
                writer.ReWriteMasterStudentFile(data.StudentCheckOuts);
                writer.WriteNewStudentFile(name);
                Console.WriteLine(name + " has been added to the system.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }

        public void DeleteStudent() //needs to rewrite master student list
        {
            Dictionary<string, List<string>> students = data.StudentCheckOuts;

            Console.WriteLine("Enter the student's name you want to remove: ");
            string name = Console.ReadLine();
            string filename = name + ".txt";

            if (!students.Keys.Contains(name))
            {
                Console.WriteLine("That student is not in the system");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
            else
            {
                data.StudentCheckOuts.Remove(name);
                writer.ReWriteMasterStudentFile(data.StudentCheckOuts);
                File.Delete(filename);
                Console.WriteLine(name + " has been removed.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }

        public void AddResource() 
        {
            Dictionary<string, bool> resources = data.Resources;

            Console.WriteLine("Enter the name of the resource you want to add: ");
            string title = Console.ReadLine();

            if (resources.Keys.Contains(title))
            {
                Console.WriteLine("That resource is already in the system.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
            else
            {
                data.Resources.Add(title, true);
                writer.WriteResourceFiles(data.Resources);
                writer.ReWriteMasterResourcesFile();
                Console.WriteLine(title + " has been added to the resources.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }

        public void RemoveResource()
        {
            Dictionary<string, bool> resources = data.Resources;

            Console.WriteLine("Enter the name of the resource you want to delete: ");
            string title = Console.ReadLine();

            if (!resources.Keys.Contains(title))
            {
                Console.WriteLine("That resource is not in the system.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
            else
            {
                data.Resources.Remove(title);
                writer.WriteResourceFiles(data.Resources);
                writer.ReWriteMasterResourcesFile();
                Console.WriteLine(title + " has been removed.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }


    }
    }

