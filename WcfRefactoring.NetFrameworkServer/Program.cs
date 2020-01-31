using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfRefactoring.NetFrameworkServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Type[] serviceTypes = new Type[] { typeof(Calc) };

            ServiceHost[] hosts = serviceTypes.Select(svcType =>
            {
                var serviceHost = new ServiceHost(svcType);
                serviceHost.Open();
                return serviceHost;
            }).ToArray();

            Console.WriteLine($"Aguardando conexões! (Pressione qualquer tecla para finalizar)");
            Console.ReadKey();
            Console.WriteLine($"Encerrando pipeline...");
            var reverseList = new List<ServiceHost>(hosts);
            reverseList.Reverse();
            reverseList.ForEach(it => it.Close());
            Console.WriteLine($"Pipeline finalizado");
            Console.WriteLine(string.Empty);
            Console.ReadKey();

        }
    }
}
