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
       

        public void UpdateResources ()
        {

        }

        static void Main(string[] args)
        {
            string name = "Krista Scholdberg";

            FileReader reader = new FileReader();
            reader.ViewStudentAccount(name);

            reader.ViewStudentList();


    }
    }
}
