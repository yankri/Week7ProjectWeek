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
                string line = reader.ReadLine();
                resources.Add(line);

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

                if (data.LCStudents.Contains(name))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error: That name does not exist.");
                    continue;
                }
            }

            string fileName = name + ".txt";

            StreamReader reader = new StreamReader(fileName);

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

        public void ViewStudentList ()
        {
            FileReader reader = new FileReader();

            List<string> students = reader.ReadStudentFile();
            students.Sort();

            foreach (string person in students)
            {
                Console.WriteLine(person);
            }
        }

        public Dictionary<string, bool> PopulateAvailableResourcesInDictionary ()
        {
            Dictionary<string, bool> resources = new Dictionary<string, bool>();

            StreamReader reader = new StreamReader("AvailableResources.txt");

            using (reader)
            {
                string line = reader.ReadLine();
                resources.Add(line, true);

                while (line != null)
                {
                    line = reader.ReadLine();
                    resources.Add(line, true);
                }
            }

            return resources;
        }

        public void PopulateCheckedOutResourcesInDictionary (Dictionary<string, bool> resources)
        {
            StreamReader reader = new StreamReader("CheckedOutResources.txt");

            using (reader)
            {
                string line = reader.ReadLine();
                resources.Add(line, false);

                while (line != null)
                {
                    line = reader.ReadLine();
                    resources.Add(line, false);
                }
            }
        }

        public void AvailableResources()
        {
            StreamReader reader = new StreamReader("AvailableResources.txt");

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
