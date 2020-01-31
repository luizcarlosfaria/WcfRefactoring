using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfRefactoring.NetFrameworkClient2
{
    public static class Factory
    {
        private static ProxyGenerator proxyGenerator = new ProxyGenerator();

        public static T Create<T>() where T: class
        {
            T proxy = proxyGenerator.CreateInterfaceProxyWithoutTarget<T>(new HttpDotNetCoreInterceptor());
            return proxy;
        }
    }
}
