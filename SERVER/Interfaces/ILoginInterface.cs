using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using SERVER.Models;

namespace SERVER.Interfaces
{
    [ServiceContract]
    public interface ILoginInterface
    {
        [OperationContract]

        string GetSalt_CS(string Fnev);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/GetSalt")]

        string GetSalt_WEB(string Fnev);

        [OperationContract]

        string Login_CS(Datazs data);
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/Login")]

        string Login_WEB(Datazs data);
    }
}
