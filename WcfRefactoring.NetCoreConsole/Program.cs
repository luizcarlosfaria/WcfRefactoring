using System;

namespace WcfRefactoring.NetCoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ICalc calc = new Calc();
            var x = calc.Sum(1, 34);
            Console.WriteLine(x);
        }
    }
}
