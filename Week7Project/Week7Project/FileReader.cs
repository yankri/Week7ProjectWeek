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

        public void ViewStudentAccount(string name)
        {
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



    }
}
