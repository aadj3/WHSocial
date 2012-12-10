using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windesheim.Social.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string val)
        {
            return string.IsNullOrEmpty(val);
        }

        public static string FormatWith(this string val, params object[] args)
        {
            return string.Format(val, args);
        }
    }
}
