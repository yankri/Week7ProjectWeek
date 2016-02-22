using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7Project
{
    class Data //This class is used to store all of the data used in the program
    {
        public Dictionary<string, bool> Resources { get; set; }
        public List<string> StudentList { get; set; }
        public Dictionary<string, string> StudentIDs { get; set; }
        private Dictionary<string, List<string>> studentCheckOuts = new Dictionary<string, List<string>>(StringComparer.InvariantCultureIgnoreCase);
        public Dictionary<string, List<string>> StudentCheckOuts
        {
            get
            {
                return studentCheckOuts;
            }
            set
            {
                studentCheckOuts = value;
            }
        }
        public string Password { get; set; }

        public Data()
        {
            reader = new FileReader(this);
            Resources = MakeDictionary();
            StudentIDs = studentIDs;
            reader.PopulateStudentCODictionary(StudentCheckOuts);
            StudentCheckOuts = studentCheckOuts;
            Password = password;
        }

        FileReader reader;

        public Dictionary<string, string> studentIDs = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
        {
            { "Krista Scholdberg", "111"},
            { "Ashley Stewart", "112" },
            { "Cadale Thomas", "113"},
            { "Jennifer Evans", "114"},
            { "Richard Raponi", "115"},
            { "Mary Winkelman","116" },
            { "Imari Childress","117" },
            { "Jacob Lockyer","118" },
            { "Quinn Bennett","119"},
            { "Margaret Landefield","120" },
            { "Kim Vargas", "121" },
            { "Cameron Robinson", "122"},
            { "Sirahn Butler", "123"},
            { "Lawrence Hudson","124" }
        };

        const string password = "admin123"; //admin menu password

        public Dictionary<string, bool> MakeDictionary () //makes a dictionary for the resources list and their availabilty
        {
            Dictionary<string, bool> resources = reader.PopulateAvailableResourcesInDictionary();

            reader.PopulateCheckedOutResourcesInDictionary(resources);

            return resources;
        }

        public bool MenuQuitter(string input) //used to quit from anywhere there is a console.readline
        {
            if (input.Equals("quit", StringComparison.InvariantCultureIgnoreCase))
            {
                return true; //returns true if you want to quit
            }
            else
            {
                return false;
            }
        }

        public string AddStudentID() //used in the admin menu to get a student ID for a new student. not working yet
        {
            int counter = 125;

            while (true)
            {
                if (!StudentIDs.Values.Contains(counter.ToString()))
                {
                    return counter.ToString();
                }
                else
                {
                    counter++;
                    continue;
                }
            }
        }




    }
}
