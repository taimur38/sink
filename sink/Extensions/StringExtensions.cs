using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sink
{
    public static class StringExtensions
    {
        public static string Template(this string s, params object[] args)
        {
            return string.Format(s, args);
        }

        public static Type GetType(this string s, string base_assembly = "")
        {
            return Type.GetType(base_assembly + s);
        }

    }
}
