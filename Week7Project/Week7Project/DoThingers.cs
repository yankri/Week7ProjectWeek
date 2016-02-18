using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7Project
{
    static class DoThingers
    {
        public static bool CIContains (Dictionary<string, bool> resources, string title) //case insensitive contains method for dictionaries
        {
            foreach (KeyValuePair<string, bool> pair in resources)
            {
                if (pair.Key.Equals(title, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool CIContains(Dictionary<string, string> students, string name) //case insenstive contains method for lists

        {
            foreach (KeyValuePair<string, string> pair in students)
            {
                if (pair.Key.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
