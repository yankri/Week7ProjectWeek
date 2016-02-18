using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7Project
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Data data = new Data();

           foreach(var pair in data.Resources)
            {
                Console.WriteLine(pair.ToString());
            }
            */
           MainMenu menu = new MainMenu();
           menu.Menu();
           


            
            //at start up, needs to make files for all the students or check if they have a file and if not say they have nothign checked out
            //stringbuilder....
            //rubric check.  use the rubric and score myself for the submission form
            //add escapes from inner menus
            //add list of checked out items for the user when returning an item
            //make sure someone cant return something they dont have
            //fix if there's nothing to return so it doesnt break
            //ask if you'd like to return another (bonus: only if there's another to return)
        }
    }
}