using System;
using System.Collections.Generic;
using System.Linq;
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
        }
        Data data = new Data();

        FileWriter writer = new FileWriter();
        FileReader reader = new FileReader();

        Dictionary<string, bool> resources = Data.Resources;
        List <string> students = Data.LowerCaseStudents();

        public void CheckOut ()
        {
            Console.Clear();

            List<string> COList = new List<string>();

            while (true)
            {
                Console.WriteLine("Enter your name: ");
                string name = Console.ReadLine().ToLower(); //make sure this is actually case insensitive

                if (students.Contains(name))
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

                if (resources.Keys.Contains(title))
                {
                    COList.Add(title);
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

        }
    }
}
