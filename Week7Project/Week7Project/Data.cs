﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7Project
{
    class Data
    {
        public Dictionary<string,bool> Resources { get; set; }
        public List<string> StudentList { get; set; }
        public Dictionary<string, string> StudentIDs { get; set; }

        public Data()
        {
            Resources = resources;
            StudentIDs = studentIDs;
            StudentList = students;
        }

        Dictionary<string, string> studentIDs = new Dictionary<string, string>()
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
            {"121", "Kim vargas" },
            {"122", "Cameron Robinson" },
            {"123", "Sirahn Butler" },
            {"124", "Lawrence Hudson" }
        };

        Dictionary<string, bool> resources = MakeDictionary();

        List<string> students = new List<string> { "Krista Scholdberg", "Ashley Stewart", "Cadale Thomas", "Lawrence Hudson", "Jennifer Evans", "Kimberly Vargas", "Jacob Lockyer", "Richard Raponi", "Imari Childress", "Mary Winkelman", "Cameron Robinson", "Margaret Landefield", "Quinn Bennett" };

        public static Dictionary<string, bool> MakeDictionary ()
        {
            Dictionary<string, bool> resources = new Dictionary<string, bool>();
            FileReader reader = new FileReader();

            resources = reader.PopulateAvailableResourcesInDictionary();
            reader.PopulateCheckedOutResourcesInDictionary(resources);

            return resources;
        }
    }
}
