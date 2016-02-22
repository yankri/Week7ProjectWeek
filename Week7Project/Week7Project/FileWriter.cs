using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Week7Project
{
    class FileWriter //This class handles all of the things that write to files. 
    {
        private Data data { get; set; }

        public FileWriter(Data data)
        {
            this.data = data;
        }

        public string StudentHeader(string studentName) //creates the header for the student's check out file
        {
            string studentID;

            StringBuilder header = new StringBuilder();
            header.Append("Student: " + studentName);
            header.AppendLine();
            header.Append("Student ID: ");

            string name = studentName.ToLower();

            if (data.StudentIDs.TryGetValue(name, out studentID) == true)
            {
                studentID = data.StudentIDs[name]; 
                header.Append(studentID);
            }

            header.AppendLine();

            return header.ToString();
        }

        public void WriteNewStudentFile(string name) //makes a new file for a new student in admin menu
        {
            StringBuilder makeName = new StringBuilder();
            makeName.Append(name);
            makeName.Append(".txt");

            string filename = makeName.ToString();

            FileWriter writing = new FileWriter(data);

            StreamWriter writer = new StreamWriter(filename);
            using (writer)
            {
                writer.WriteLine(writing.StudentHeader(name));
            }
        }

        public void WriteResourceFiles (Dictionary<string, bool> resources)  //writes the resource files
        {
            StreamWriter allResources = new StreamWriter("ResourceList.txt");

            using (allResources)
            {
                foreach (KeyValuePair<string, bool> pair in resources)
                {
                    allResources.WriteLine(pair.Key);
                }
            }

            StreamWriter available = new StreamWriter("AvailableResources.txt");

            using (available)
            {
                foreach (KeyValuePair<string, bool> pair in resources)
                {
                    if (pair.Value == true)
                    {
                        available.WriteLine(pair.Key);
                    }
                }
            }

            StreamWriter checkedOut = new StreamWriter("CheckedOutResources.txt");

            using (checkedOut)
            {
                foreach (KeyValuePair<string, bool> pair in resources)
                {
                    if (pair.Value == false)
                    {
                        checkedOut.WriteLine(pair.Key);
                    }
                }
            }
        }

        public void CheckOutResource (Dictionary<string, List<string>> studentCheckOuts, string name)
        {   //writes the student's file when checking out and updates the resources dictionary bools
            FileWriter writer = new FileWriter(data);

            Dictionary <string, bool> resources = data.Resources;

            foreach (KeyValuePair<string, List<string>> pair in studentCheckOuts)
            {
                if (pair.Key.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    name = pair.Key;
                    break;
                }
            }

            List<string> studentList = studentCheckOuts[name];

            string fileName = name + ".txt";

            string header = writer.StudentHeader(name);

            StreamWriter writing = new StreamWriter(fileName);
            using (writing) 
            {
                writing.WriteLine(header);
                writing.WriteLine();
                writing.WriteLine("Checked Out Resources: ");

                for (int i = 0; i < studentList.Count; i++)
                {
                    writing.WriteLine(studentList[i]);
                }
            }

            for (int i = 0; i < studentList.Count; i++) //updates the resources dictionary
            {
                if (resources.ContainsKey(studentList[i]))
                {
                    resources[studentList[i]] = false; //false because its no longer available
                }
            }
        }

        public void ReWriteMasterResourcesFile ()
        {
            StreamWriter writer = new StreamWriter("ResourceList.txt");

            using (writer)
            {
                foreach (KeyValuePair<string, bool> pair in data.Resources)
                {
                    writer.WriteLine(pair.Key);
                }
            }
        }
        
        public void ReWriteMasterStudentFile(Dictionary<string, List<string>> studentCO)
        {
            StreamWriter writer = new StreamWriter("StudentList.txt");

            using (writer)
            {
                foreach (KeyValuePair<string, List<string>> pair in studentCO)
                {
                    writer.WriteLine(pair.Key);
                }
            }
        }
    }
}
