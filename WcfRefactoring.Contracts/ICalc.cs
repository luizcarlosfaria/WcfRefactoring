using System;
using System.ServiceModel;

namespace WcfRefactoring
{
    [ServiceContract]
    public interface ICalc
    {
        [OperationContract]
        int Sum(int part1, int part2);
    }
}
