using System;
using System.Collections.Generic;

namespace Trial
{
    class Program
    {
        static void Main(string[] args)
        {

            IEnumerable<int> nums = new int[] { 1, 2, 3 };

           nums = new List<int>(nums);

            Console.WriteLine(string.Join(" ",nums));   
        }
    }
}
