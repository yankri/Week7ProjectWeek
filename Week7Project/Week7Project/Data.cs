using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7Project
{
    class Data
    {
        public Dictionary<string, bool> Resources { get; set; }
        public List<string> StudentList { get; set; }
        public Dictionary<string, string> StudentIDs { get; set; }
        public List<string> LCStudents { get; set; }
        public List<string> COList { get; set; }
        public List<string> LCResources { get; set; }

        public Data()
        {
            Resources = MakeDictionary();
            StudentIDs = studentIDs;
            StudentList = studentIDs.Keys.ToList();
            LCStudents = LowerCaseStudents();
            COList = coList;
            LCResources = MakeLCResourcesList(Resources);
        }

        public Dictionary<string, string> studentIDs = new Dictionary<string, string>()
        {
            { "krista scholdberg", "111"},
            {"ashley stewart", "112" },
            { "cadale thomas", "113"},
            { "jennifer evans", "114"},
            { "richard raponi", "115"},
            { "mary winkelman","116" },
            { "imari childress","117" },
            { "jacob lockyer","118" },
            { "quinn bennet","119"},
            { "margaret landefield","120" },
            { "kim vargas", "121" },
            { "cameron robinson", "122"},
            { "sirahn butler", "123"},
            { "lawrence hudson","124" }
        };

        List<string> coList = new List<string>();

        public List<string> LowerCaseStudents()
        {
            List<string> students = new List<string> { "Krista Scholdberg", "Ashley Stewart", "Cadale Thomas", "Lawrence Hudson", "Jennifer Evans", "Kimberly Vargas", "Jacob Lockyer", "Richard Raponi", "Imari Childress", "Mary Winkelman", "Cameron Robinson", "Margaret Landefield", "Quinn Bennett" };
            List<string> LCstudents = new List<string>();

            for (int i = 0; i < students.Count; i++)
            {
                students[i] = students[i].ToLower();
                LCstudents.Add(students[i]);
            }

            return LCstudents;
        }

        public Dictionary<string, bool> MakeDictionary ()
        {
            FileReader reader = new FileReader();

            Dictionary<string, bool> resources = reader.PopulateAvailableResourcesInDictionary();

            reader.PopulateCheckedOutResourcesInDictionary(resources);

            return resources;
        }

        public List<string> MakeLCResourcesList (Dictionary<string, bool> resources)
        {
            List<string> lcresources = new List<string>();
            string key;
            foreach (KeyValuePair <string, bool> pair in resources)
            {
                key = pair.Key.ToLower();
                lcresources.Add(key);
            }

            return lcresources;
        }
    }
}
