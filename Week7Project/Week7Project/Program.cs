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
           


            //resource list isn't case insensitive
            // add rewriting the resource files to update available and checked out books
            //item return
        }
    }
}