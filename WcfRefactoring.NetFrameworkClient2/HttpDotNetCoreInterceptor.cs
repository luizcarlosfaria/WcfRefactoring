using Castle.DynamicProxy;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;

namespace WcfRefactoring.NetFrameworkClient2
{
    public class HttpDotNetCoreInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var client = new RestClient(GetEndpointUrl());

            var request = new RestRequest(GetPath(invocation), DataFormat.Json);

            int i = 0;
            foreach (var parameter in invocation.Method.GetParameters())
            {
                request.AddParameter(parameter.Name, invocation.GetArgumentValue(i++));
            }

            var response = client.Post(request);

            if (invocation.Method.ReturnType != typeof(void))
            {
                invocation.ReturnValue = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content, invocation.Method.ReturnType);
            }
        }

        private static string GetPath(IInvocation invocation)
        {
            Type proxyType = invocation.Method.DeclaringType;
            if (proxyType.IsInterface && proxyType.Name.StartsWith("I"))
            {
                return proxyType.Name.Substring(1).ToLower();
            }
            return proxyType.Name.ToLower();
        }

        private static string GetEndpointUrl()
        {
            return ConfigurationManager.AppSettings["dotnet-core-endpoint"] ?? throw new InvalidOperationException("The configuration dotnet-core-endpoint is not set on App.Config/Web.Config.");
        }
    }
}