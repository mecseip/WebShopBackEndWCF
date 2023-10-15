using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HOST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("http://localhost:3000");
            BasicHttpBinding basicHttpBinding = new BasicHttpBinding();
            WebHttpBinding webHttpBinding = new WebHttpBinding();
            using (ServiceHost host = new ServiceHost(
                typeof(SERVER.Service1), uri))
            {
                webHttpBinding.CrossDomainScriptAccessEnabled = true;
                ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(SERVER.IService1), webHttpBinding, "");
                endpoint.EndpointBehaviors.Add(new WebHttpBehavior());
                ServiceEndpoint endpoint1 = host.AddServiceEndpoint(typeof(SERVER.IService1), basicHttpBinding, "soap");
                host.Authorization.ServiceAuthorizationManager = new MyServiceAuthorizationManager();
                host.Open();
                Console.WriteLine("A szerver elindult. {0} ", DateTime.Now);
                Console.ReadKey();
                host.Close();

            }
        }
    }
}