using System.Collections.Generic;
using System.Linq;

namespace CSharpExamples
{
    public static class StringHelper
    {
        public static bool IsValidEmail(this string email)
        {
            // start with empty value
            // return false;

            // then build tests and watch fail

            // then build code to pass your tests
            return email.Contains("@");
        }
    }
}
