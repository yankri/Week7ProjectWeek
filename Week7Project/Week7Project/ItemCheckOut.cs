using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Week7Project
{
    class ItemCheckOut
    {
        public Dictionary<string, bool> Resources { get; set; }

        public ItemCheckOut ()
        {
            Resources = resources;
            resources = data.Resources; //if the assignment refers to something else (another class) it has to be done in the constructor
            students = data.LCStudents;
        }

        Data data = new Data();
        FileWriter writer = new FileWriter();
        FileReader reader = new FileReader();

        Dictionary<string, bool> resources;
        List<string> students;

        public void CheckOut ()
        {
            Data data = new Data();
            Console.Clear();
            FileWriter writer =  new FileWriter();
            List<string> COList = data.COList;

            while (true)
            {
                Console.WriteLine("Enter your name: ");
                string name = Console.ReadLine(); //make sure this is actually case insensitive

                if (DoThingers.CIContains(students, name))
                {
                    COList.Add(name);
                    break;
                }
                else
                {
                    continue;
                }
            }

            while(true)
            { // update this so it's case insensitive
                Console.WriteLine("Enter the name of the resource you want to check out: ");
                string title = Console.ReadLine();

                if (DoThingers.CIContains(resources, title))
                {
                    COList.Add(title);

                    bool checker;
                    resources.TryGetValue(title, out checker);
                    bool poop = resources.TryGetValue(title, out checker);

                    if (checker == true)
                    {
                        UpdateCheckOutDictionaryAvailability(resources, title); 
                    }
                    else
                    {
                        Console.WriteLine("That resource is already checked out or does not exist. Please select another.");
                        continue;
                    }
                }

                Console.WriteLine("Do you want to check out another resource? Y or N");
                string input = Console.ReadLine().ToLower();

                if (input == "y")
                {
                    continue;
                }
                else
                {
                    break;
                }
            }

            writer.CheckOutResource(COList);
            writer.WriteResourceFiles(resources);
        }

        public void UpdateCheckOutDictionaryAvailability (Dictionary<string, bool> resources, string title) //START HERE  update this stupid thing to be case insensitive
        {
            if (DoThingers.CIContains(resources, title) == true)
            {
                resources[title] = false;
            }
        }
    }
}
