using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7Project
{
    class ItemReturn //This class handles returning an item.
    {
        private Data data { get; set; }

        public ItemReturn (Data data)
        {
            this.data = data;
            resources = data.Resources;
            reader = new FileReader(data);
            writer = new FileWriter(data);
        }

        FileReader reader;
        FileWriter writer;

        Dictionary<string, bool> resources;

        public void ReturnItem ()
        {
            string name;
            string filename;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Student names: ");
                reader.CheckOutStudentList();
                Console.WriteLine("\nEnter your name or \"quit\" to return to the main menu.");
                name = Console.ReadLine();

                bool quitter = data.MenuQuitter(name);
                if (quitter == true)
                {
                    return;
                }

                if (data.StudentCheckOuts.Keys.Contains(name.ToLower()))
                {
                    StringBuilder fileName = new StringBuilder();

                    fileName.Append(name);
                    fileName.Append(".txt");

                    filename = fileName.ToString();
                        
                    if (!File.Exists(filename))
                    {
                        Console.WriteLine("That user doesn't have anything checked out.");
                        Console.WriteLine("Press any key to return to the main menu.");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        ShowCheckedOutResources(filename);
                        break;
                    }
                }
                else
                {
                    continue;
                }
            }

            while (true)
            {
                Console.WriteLine("Enter the name of the resource you wish to return or \"quit\" to return to the main menu. ");
                string title = Console.ReadLine();

                bool quitter = data.MenuQuitter(title);
                if (quitter == true)
                {
                    return;
                }

                if (resources.ContainsKey(title))
                {
                    string toDelete = "";
                    string line;

                    using (StreamReader reader = new StreamReader(filename))
                    {
                        while (!reader.EndOfStream)
                        {
                            line = reader.ReadLine();

                            if (resources.ContainsKey(line))
                            {
                                toDelete = title;
                                reader.Close();
                                break;
                            }
                        }

                        bool success = RemoveReturnedItemFromStudentFile(filename, toDelete);
                        if (success == true)
                        {
                            resources[title] = true;
                            writer.WriteResourceFiles(resources);
                            writer.StudentHeader(name);
                            Console.WriteLine(title + " has been returned. Press any key to continue.");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("That user has not checked out that resource.");
                            Console.WriteLine("\nPress any key to return to the main menu.");
                            Console.ReadKey();
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nThat title does not exist. Please try again or enter \"quit\" to go back to the main menu.\n");
                    continue;
                }
            }
        }

        public bool RemoveReturnedItemFromStudentFile (string filename, string toDelete)
        {
            var oldLines = File.ReadAllLines(filename);
            var newLines = oldLines.Where(check => check.IndexOf(toDelete, StringComparison.OrdinalIgnoreCase) < 0);

            if (oldLines.Count() == newLines.Count() || newLines.Count() == 0)
            {
                return false; //means it didnt work and the resource wasnt in the file
            }
                File.WriteAllLines(filename, newLines);
                return true; // means it did work and the resource was in the file 
        }

        public void ShowCheckedOutResources(string fileName) //used to show what the student already has checked out by reading their file
        { //check if this is duplicated in ViewStudentAccount method 
            if (File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName); 
                Console.Clear();
                using (reader)
                {
                    string line = reader.ReadLine();
                    Console.WriteLine(line);

                    while (line != null)
                    {
                        line = reader.ReadLine();
                        Console.WriteLine(line);
                    }
                }
            }
        }
    }
}
