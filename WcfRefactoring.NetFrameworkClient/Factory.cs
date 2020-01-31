using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfRefactoring.NetFrameworkClient
{
    public static class Factory
    {
        public static T Create<T>()
        {
            var channelFactory = new ChannelFactory<T>("tcp");
            return channelFactory.CreateChannel();
        }
    }
}
