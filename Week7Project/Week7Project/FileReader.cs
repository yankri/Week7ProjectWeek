using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7Project
{
    class FileReader //This class contains all of the things related to reading files.
    {
        private Data data { get; set; }

        public FileReader(Data data)
        {
            this.data = data;
        }

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

        public void ViewStudentAccount() //reads from a student's file and prints what they have checked out 
        {
            string name;
            Console.Clear();
            while (true)
            {
                CheckOutStudentList();
                Console.WriteLine("\nEnter a name to view the account or \"quit\" to exit to the main menu.");
                name = Console.ReadLine();

                bool quitter = data.MenuQuitter(name);
                if (quitter == true)
                {
                    return;
                }

                string checkName = name.ToLower();
                if (!data.StudentCheckOuts.Keys.Contains(checkName))
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

            List<string> students = this.ReadStudentFile();
            students.Sort();

            StringBuilder studentList = new StringBuilder();

            foreach (string person in students)
            {
                studentList.AppendLine(person);
            }

            Console.WriteLine(studentList.ToString());
            Console.WriteLine("\n\nPress any key to continue");
            Console.ReadKey();
        }

        public Dictionary<string, bool> PopulateAvailableResourcesInDictionary() //used to get the available resources from the text file
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

        public void PopulateCheckedOutResourcesInDictionary (Dictionary<string, bool> resources) //gets checked out resources from the file
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

        public void PrintAvailableResources() //does what it says
        {
            List<string> availableResources = new List<string>();

            StreamReader reader = new StreamReader("AvailableResources.txt");

            using (reader)
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (line != null)
                    {
                        availableResources.Add(line);
                    }
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

        public void PrintCheckedOutResources() //does what it says
        {
            List<string> checkedOutResources = new List<string>();

            StreamReader reader = new StreamReader("CheckedOutResources.txt");

            using (reader)
            {
                string line = reader.ReadLine();

                if (line == null)
                {
                    reader.Close();
                }
                else
                {
                    checkedOutResources.Add(line);
                }

                while (line != null)
                {
                    line = reader.ReadLine();
                    checkedOutResources.Add(line);
                }
            }

            checkedOutResources.Sort();

            Console.Clear();

            foreach (string title in checkedOutResources)
            {
                Console.WriteLine(title);
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        public void CheckOutPrintAvailableResources() //prints available resources in the checkout menu
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

            foreach (string title in availableResources)
            {
                Console.WriteLine(title);
            }
        }

        public void CheckOutStudentList() //prints the student list in the check out menu
        {
            List<string> students = this.ReadStudentFile();
            students.Sort();

            foreach (string person in students)
            {
                Console.WriteLine(person);
            }
        }

        public void PopulateStudentCODictionary(Dictionary<string, List<string>> studentCheckOuts) 
        {  //reads all of the student files and adds their checkouts to a list in their respective dictionary. gets names for the values from the master student list
            List<string> students = new List<string>();

            StreamReader reader = new StreamReader("StudentList.txt");
            using (reader)
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    students.Add(line);
                }
            }

            for (int i = 0; i < students.Count; i++)
            {
                string fileName = students[i] + ".txt";

                StreamReader reading = new StreamReader(fileName);
                bool checker = false;

                studentCheckOuts.Add(students[i], new List<string>());

                using (reading)
                {
                    while (!reading.EndOfStream)
                    {
                        string line = reading.ReadLine();

                        if (line == "Checked Out Resources: ")
                        {
                            checker = true;
                            continue;
                        }

                        if (checker == true)
                        {
                            if (line != null)
                            {
                                studentCheckOuts[students[i]].Add(line);
                            }
                        }
                    }
                }
            }

        }

    }
}
