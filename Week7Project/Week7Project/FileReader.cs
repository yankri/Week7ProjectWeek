using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7Project
{
    class FileReader
    {
        public List<string> ReadStudentFile() //reads students from file and adds them to a list
        {
            List <string> students = new List<string>();

            StreamReader reader = new StreamReader("StudentList.txt");

            using (reader)
            {
                string line = reader.ReadLine();
                students.Add(line);

                while (line != null)
                {
                    line = reader.ReadLine();
                    students.Add(line);
                }
            }

            return students;
        }

        public void ReadResourcesFile(List<string> resources)
        {
            resources = new List<string>();

            StreamReader reader = new StreamReader("ResourceList.txt");

            using (reader)
            {
                string line = "";
                while (line != null)
                {
                    line = reader.ReadLine();
                    resources.Add(line);
                }
            }
        }

        public void ViewStudentAccount()
        {
            Data data = new Data();
            string name;

            while (true)
            {
                Console.WriteLine("Enter a name: ");
                name = Console.ReadLine();

                string checkName = name.ToLower();
                if (!data.StudentIDs.Keys.Contains(checkName))
                {
                    Console.WriteLine("Error: That name does not exist.");
                    continue;
                }

                string fileName = name + ".txt";

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
                    Console.WriteLine("\nPress any key to continue");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nERROR: That user does not have any books checked out.");
                    Console.WriteLine("\nPress any key to continue");
                    Console.ReadKey();
                    break;
                }
            }
        }
        

        public void ViewStudentList ()
        {
            Console.Clear();
            FileReader reader = new FileReader();

            List<string> students = reader.ReadStudentFile();
            students.Sort();

            foreach (string person in students)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine("\n\nPress any key to continue");
            Console.ReadKey();
        }

        public Dictionary<string, bool> PopulateAvailableResourcesInDictionary()
        {
            Dictionary<string, bool> resources = new Dictionary<string, bool>(StringComparer.InvariantCultureIgnoreCase);

            StreamReader reader = new StreamReader("AvailableResources.txt");

                string line = reader.ReadLine();

                if (line == null || line == "none")
                {
                    reader.Close();
                }
                else
                {
                    resources.Add(line, true);

                    while (!reader.EndOfStream) //ends when the stream is at the end
                    {
                        line = reader.ReadLine();
                        resources.Add(line, true);
                    }
                    reader.Close();
                }
            
            return resources;
        }

        public void PopulateCheckedOutResourcesInDictionary (Dictionary<string, bool> resources)
        {
            StreamReader reader = new StreamReader("CheckedOutResources.txt");

            using (reader)
            {
                string line = reader.ReadLine();

                if (line == null || line == "none")
                {
                    reader.Close();
                }
                else
                {
                    resources.Add(line, false);
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        resources.Add(line, false);
                    }
                }
            } 
        }

        public void AvailableResources()
        {
            List<string> availableResources = new List<string>();

            StreamReader reader = new StreamReader("AvailableResources.txt");

            using (reader)
            {
                string line = reader.ReadLine();

                if (line == null)
                {
                    reader.Close();
                }
                else
                {
                    availableResources.Add(line);
                }

                while (line != null)
                {
                    line = reader.ReadLine();
                    availableResources.Add(line);
                }
            }

            availableResources.Sort();

            Console.Clear();

            foreach (string title in availableResources)
            {
                Console.WriteLine(title);
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }


    }
}
