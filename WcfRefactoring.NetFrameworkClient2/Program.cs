using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfRefactoring.NetFrameworkClient2
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = Factory.Create<ICalc>();
            
            Console.WriteLine(calc.Sum(45, 5));

        }
    }
}
