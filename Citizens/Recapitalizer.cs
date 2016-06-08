using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citizens
{
    static class Recapitalizer
    {
        public static string RecapitalizeName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return string.Empty;
            }
            string result = string.Empty;
            bool firstLetter = true;
            foreach (char letter in name)
            {
                if (firstLetter)
                {
                    result += letter.ToString().ToUpper();
                    firstLetter = false;
                }
                else
                {
                    result += letter.ToString().ToLower();
                }
            }
            return result;
        }
    }
}
