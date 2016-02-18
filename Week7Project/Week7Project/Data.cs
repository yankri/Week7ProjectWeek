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
        public List<string> COList { get; set; }

        public Data()
        {
            Resources = MakeDictionary();
            StudentIDs = studentIDs;
            COList = coList;
        }

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
            { "Quinn Bennet","119"},
            { "Margaret Landefield","120" },
            { "Kim Vargas", "121" },
            { "Cameron Robinson", "122"},
            { "Sirahn Butler", "123"},
            { "Lawrence Hudson","124" }
        };

        List<string> coList = new List<string>();

        public Dictionary<string, bool> MakeDictionary ()
        {
            FileReader reader = new FileReader();

            Dictionary<string, bool> resources = reader.PopulateAvailableResourcesInDictionary();

            reader.PopulateCheckedOutResourcesInDictionary(resources);

            return resources;
        }

       
    }
}
