using Google.Protobuf.WellKnownTypes;
using SERVER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Services;

namespace SERVER.Interfaces
{
    [ServiceContract]
    public interface IJogosultsagokInterface
    {
        [OperationContract]
        List<Jogosultsagok> JogosultsagokLista_CS(string where); //SOAP C# GET SELECT CRUD-Read

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/JogosultsagokLista/{where}")]
        List<Jogosultsagok> JogosultsagokLista_WEB(string where); //HTTP(S) C# GET SELECT CRUD-Read

        string JogosultsagokHozzaAd_CS(Jogosultsagok jogosultsag); //SOAP C# POST INSERT CRUD-Create

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/JogosultsagokHozzaAd")]
        string JogosultsagokHozzaAd_WEB(Jogosultsagok jogosultsag); //HTTP(S) POST INSERT CRUD-Create

        [OperationContract]

        string JogosultsagokModosit_CS(Jogosultsagok jogosultsag); //SOAP C# PUT UPDATE CRUD-Update

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/JogosultsagokModosit")]
        string JogosultsagokModosit_WEB(Jogosultsagok jogosultsag); //HTTP(S) PUT UPDATE CRUD-Update

        [OperationContract]

        string JogosultsagokTorol_CS(int? id); //SOAP C# DELETE DELETE CRUD-Delete

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/JogosultsagTorol?id={id}")]
        string JogosultsagokTorol_WEB(int id); //HTTP(S) DELETE DELETE CRUD-Delete
    }
}
