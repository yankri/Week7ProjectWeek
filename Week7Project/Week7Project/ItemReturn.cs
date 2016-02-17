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
                name = Console.ReadLine().ToLower();

                if (data.LCStudents.Contains(name))
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

                    StreamReader reader = new StreamReader(filename);
                    using (reader)
                    {
                        string line = "";
                        while (line != null)
                        {
                            line = reader.ReadLine();

                            if (resources.ContainsKey(line))
                            {
                                resources[line] = true;
                            }
                        }
                    }
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


    }
}
