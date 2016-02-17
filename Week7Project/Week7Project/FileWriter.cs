using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Week7Project
{
    class FileWriter
    {
        public string resourceHeader (int choice)
        {
            StringBuilder resHeader = new StringBuilder();

            switch (choice)
            {
                case 1: //all resources
                    resHeader.Append("All Resources");
                    break;
                case 2: //Available resources
                    resHeader.Append("Available Resources");
                    break;
                case 3:
                    resHeader.Append("Checked Out Resources");
                    break;
                default:
                    resHeader.Append("Resources");
                    break;
            }

            return resHeader.ToString();
        }

        public string StudentHeader(string studentName) //creates the header for the student's check out file
        {
            string studentID;
            Data data = new Data();

            StringBuilder header = new StringBuilder();

            header.Append("Student: " + studentName);
            header.AppendLine();
            header.Append("Student ID: ");

            string name = studentName.ToLower();

            if (data.StudentIDs.TryGetValue(name, out studentID) == true)
            {
                studentID = data.StudentIDs[name]; 
                Console.WriteLine(studentID);
                header.Append(studentID);
            }

            header.AppendLine();

            return header.ToString();
        }

        public void WriteStudentFile(string name, List<string> COList)
        {
            string filename = name + ".txt";
            FileWriter writing = new FileWriter();

            StreamWriter writer = new StreamWriter(filename);
            using (writer)
            {
                writer.WriteLine(writing.StudentHeader(name));

                for (int i = 1; i < COList.Count; i++)
                {
                    writer.WriteLine(COList[i]);
                }
            }
        }

        public List<string> AddToList (string resource)
        {
            List<string> checkedOut = new List<string>();

            checkedOut.Add(resource);

            return checkedOut;
        }

        public void WriteResourceFiles (Dictionary<string, bool> resources)
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

        public void CheckOutResource (List<string> COList) //make sure this will be case insensitive
        {
            FileWriter writer = new FileWriter();
            Data data = new Data();

            Dictionary <string, bool> resources = data.Resources;

            string fileName = COList[0] + ".txt";

            string header = writer.StudentHeader(COList[0]);

            StreamWriter writing = new StreamWriter(fileName);
            using (writing) 
            {
                writing.WriteLine(header);
                writing.WriteLine();
                writing.WriteLine("Checked Out Resources: ");

                for (int i = 1; i < COList.Count; i++)
                {
                    writing.WriteLine(COList[i]);
                }
            }

            for (int i = 0; i < COList.Count; i++) //updates the resources dictionary
            {
                if (resources.ContainsKey(COList[i]))
                {
                    resources[COList[i]] = false; //false because its no longer available
                }
            }
        }



    }
}
