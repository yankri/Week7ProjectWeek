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
        
        public List<string> resources = new List<string>();

        public Dictionary<string, string> StudentIDs = new Dictionary<string, string>()
        {
            {"111", "Krista Scholdberg" },
            {"112", "Ashley Stewart" },
            {"113", "Cadale Thomas" },
            {"114", "Jennifer Evans" },
            {"115", "Richard Raponi" },
            {"116", "Mary Winkelman" },
            {"117", "Imari Childress" },
            {"118", "Jacob Lockyer" },
            {"119", "Quinn Bennet" },
            {"120", "Margaret Landefield" },
            {"121", "Kim Vargas" },
            {"122", "Cameron Robinson" },
            {"123", "Sirahn Butler" },
            {"124", "Lawrence Hudson" }
        };

        Dictionary<string, List<string>> CheckOuts = new Dictionary<string, List<string>> (){ };


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

            StringBuilder header = new StringBuilder();

            header.Append("Student: " + studentName + "\nStudent ID: ");

            if (StudentIDs.TryGetValue(studentName, out studentID) == true)
            {
                header.Append(studentID);
            }
            
            return header.ToString();
        }

        public void WriteStudentFile(string name)
        {
            string filename = name + ".txt";
            FileWriter writing = new FileWriter();

            StreamWriter writer = new StreamWriter(filename);
            using (writer)
            {
                writer.WriteLine(writing.StudentHeader(name));


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

            Dictionary <string, bool> resources = Data.Resources;

            string fileName = COList[0] + ".txt";

            string header = writer.StudentHeader(COList[0]);

            StreamWriter writing = new StreamWriter(fileName);
            using (writing) 
            {
                writing.WriteLine(header);
                writing.WriteLine();
                writing.WriteLine("Checked Out Resources: ");
                writing.WriteLine(COList[1]);
                writing.WriteLine(COList[2]);
                writing.WriteLine(COList[3]);
            }

            for (int i = 0; i < COList.Count; i++)
            {
                if (resources.ContainsKey(COList[i]))
                {
                    resources[COList[i]] = false;
                }
            }
        }



    }
}
