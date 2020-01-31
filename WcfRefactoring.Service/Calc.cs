using System;

namespace WcfRefactoring
{
    public class Calc : ICalc
    {
        public int Sum(int part1, int part2) 
        {
            var returnValue = part1 + part2;

            Console.WriteLine($"{part1} + {part2} = {returnValue}");

            return returnValue;
        }
    }
}
