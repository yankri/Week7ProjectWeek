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

            while (true)
            {
                Console.WriteLine("Enter your name: ");
                name = Console.ReadLine();

                if (data.LCStudents.Contains(name.ToLower()))
                {
                    break;
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
                    string filename = name + ".txt";
                    string toDelete = null;
                    string line = null;

                    StreamReader reader = new StreamReader(filename);
                    using (reader)
                    {
                        while (!reader.EndOfStream)
                        {
                            line = reader.ReadLine();

                            if (resources.ContainsKey(line))
                            {
                                resources[title] = true;
                                toDelete = title;
                                break;
                            }
                        }
                    }
                    RemoveReturnedItemFromStudentFile(filename, toDelete);
                    break;
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

        public void RemoveReturnedItemFromStudentFile (string filename, string toDelete)
        {
            var oldLines = File.ReadAllLines(filename);
            var newLines = oldLines.Where(check => check.IndexOf(toDelete, StringComparison.OrdinalIgnoreCase) < 0);
            File.WriteAllLines(filename, newLines);
        }


    }
}
