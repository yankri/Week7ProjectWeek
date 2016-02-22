using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Week7Project
{
    class ItemCheckOut //This class handles checking out items
    {
        public Dictionary<string, bool> Resources { get; set; }
        public Data data { get; set; }

        public ItemCheckOut (Data data)
        {
            reader = new FileReader(data);
            writer = new FileWriter(data);
            this.data = data;
            Resources = resources;
            resources = data.Resources; //if the assignment refers to something else (another class) it has to be done in the constructor
            studentIDs = data.StudentIDs;
        }

        FileWriter writer;
        FileReader reader;

        Dictionary<string, bool> resources;
        Dictionary<string, string> studentIDs;

        public void CheckOut ()
        {
            Dictionary<string, List<string>> studentCheckOuts = data.StudentCheckOuts;
            Console.Clear();

            string name = "";
            string title = "";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("All Students: ");
                reader.CheckOutStudentList();
                Console.WriteLine("\nEnter a name or \"quit\" to return to the main menu. ");
                name = Console.ReadLine(); 

                bool quitter = data.MenuQuitter(name);
                if (quitter == true)
                {
                    return;
                }

                if (DoThingers.CIContains(studentCheckOuts, name)) //my case insensitive contains method
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid name.");
                    System.Threading.Thread.Sleep(1500);
                    continue;
                }
            }

            while(true)
            {
                Console.Clear();
                Console.WriteLine("Available Resources: ");
                reader.CheckOutPrintAvailableResources();
                Console.WriteLine("\nEnter the name of the resource you want to check out: ");
                title = Console.ReadLine();

                bool quitter = data.MenuQuitter(title);
                if (quitter == true)
                {
                    return;
                }

                if (DoThingers.CIContains(resources, title))
                {
                    AddToList(studentCheckOuts, name, title);

                    bool checker;
                    resources.TryGetValue(title, out checker);

                    if (checker == true)
                    {
                        UpdateCheckOutDictionaryAvailability(resources, title); //updates resources dictionary
                        writer.CheckOutResource(studentCheckOuts, name); //writes the student files
                        writer.WriteResourceFiles(resources); //writes the resource files 
                    }
                    else
                    {
                        Console.WriteLine("That resource is already checked out or does not exist. Please select another.");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("That resource does not exist.");
                }

                string input = "";

                while (input != "yes" || input != "no" || input != "y" || input != "n")
                {
                    Console.WriteLine("Do you want to check out another resource? Y or N");
                    input = Console.ReadLine().ToLower();

                    if (input != "yes" || input != "no" || input != "y" || input != "n")
                    {
                        break;
                    }
                }

                if (input == "yes" || input == "y")
                {
                    continue;
                }

                if (input == "no" || input == "n")
                {
                    break;
                }
            }
        }

        public void UpdateCheckOutDictionaryAvailability (Dictionary<string, bool> resources, string title) 
        {
            if (DoThingers.CIContains(resources, title) == true) //makes sure its in the dictionary as true first, then changes the value to false
            {
                resources[title] = false;
            }
        }

        public void AddToList (Dictionary<string, List<string>> studentCheckOuts, string name, string title) //used to add to the lists in the studentCheckOuts dictionary that is <string, List<string>>
        {
            List<string> student = studentCheckOuts[name];
            student.Add(title);
        }
    }
}
