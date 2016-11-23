using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TypeExtensions
{
    public static class StringExtensions
    {
        public static bool IsExistsSubstring(this string line, string regexPattern)
        {
            Regex newReg = new Regex(regexPattern);
            MatchCollection matches = newReg.Matches(line);
            return matches.Count > 0;
        }
    }
}
