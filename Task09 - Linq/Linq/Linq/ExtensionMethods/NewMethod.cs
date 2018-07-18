using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linq;

namespace Linq.ExtensionMethods
{
    public static class NewMethod
    {
        public static int GetNumOfAdultPersons(this List<Person> L)
        {
            int result = 0;
            foreach (var person in L)
                if (person.Age >= 18)
                    result++;
            return result;
        }
    }
}
