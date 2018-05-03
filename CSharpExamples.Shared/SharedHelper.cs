using System;

namespace CSharpExamples.Shared
{
    public static class SharedHelper
    {
        public static int BinarySearch(this int[] arr, int value)
        {
            var start = 0;
            var end = arr.Length - 1;

            while (start <= end)
            {
                var mid = (start + end) / 2;
                var found = arr[mid];

                if (found == value) { return mid; }
                if (found < value) { start = mid + 1; }
                else { end = mid - 1; }
            }

            return -1;
        }
    }
}
