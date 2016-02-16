using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public string header(string studentName)
        {
            StringBuilder header = new StringBuilder();

            string studentID;

            header.Append("Student: " + studentName + "\nStudent ID: ");

            if (StudentIDs.TryGetValue(studentName, out studentID) == true)
            {
                header.Append(studentID);
            }
            
            return header.ToString();
        }

        public List<string> AddToList (string resource)
        {
            List<string> checkedOut = new List<string>();

            checkedOut.Add(resource);

            return checkedOut;
        }



    }
}
