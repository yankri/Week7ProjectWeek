using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7Project
{
    class ItemReturn
    {

        public ItemReturn ()
        {
            COList = data.COList;
            resources = data.Resources;
        }
        Data data = new Data();
        FileReader reader = new FileReader();
        FileWriter writer = new FileWriter();

        List<string> COList;

        Dictionary<string, bool> resources;

        public void ReturnItem ()
        {
            string name;
            string filename;

            while (true)
            {
                Console.WriteLine("Enter your name: ");
                name = Console.ReadLine();

                if (data.StudentIDs.Keys.Contains(name.ToLower()))
                {
                    filename = name + ".txt";
                        
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
                Console.WriteLine("Enter the name of the resource you wish to return: ");
                string title = Console.ReadLine();

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
                    Console.WriteLine("\nThat title does not exist. Please try again.\n");
                    continue;
                }
            }

            writer.WriteResourceFiles(resources);
            writer.StudentHeader(name);
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

        public void ShowCheckedOutResources(string fileName)
        {
            if (File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName); //figure out how to check if a filename exists
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
