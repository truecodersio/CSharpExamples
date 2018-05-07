using System;
using CSharpExamples.Shared;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;

namespace CSharpExamples
{
    class Testing
    {
        public string Value { get; set; }

		public override string ToString()
		{
            return $"You're a terrible person";
		}
	}

    class Program
    {
        static void Main(string[] args)
        {
            var value = new[] { 1, 2, 3, 4, 5 };

            var index = value.BinarySearch(4);
        }
    }
}
