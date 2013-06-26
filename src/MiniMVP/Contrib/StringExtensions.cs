using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniMVP.Contrib
{
    internal static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrEmpty(str) ? true : str.Trim() == "";
        }
    }
}
