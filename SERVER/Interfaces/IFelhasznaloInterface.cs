using Google.Protobuf.WellKnownTypes;
using SERVER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Services;

namespace SERVER.IServices
{
    [ServiceContract]
    public interface IFelhasznaloInterface
    {
        [OperationContract]

        List<Felhasznalo> FelhasznaloLista_CS(string where); //SOAP C# GET SELECT CRUD-Read

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/FelhasznaloLista/{where}")]
        List<Felhasznalo> FelhasznaloLista_WEB(string where); //HTTP(S) C# GET SELECT CRUD-Read

        [OperationContract]

        string FelhasznaloHozzaAd_CS(Felhasznalo felhasznalo); //SOAP C# POST INSERT CRUD-Create

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/FelhasznaloHozzaAd")]
        string FelhasznaloHozzaAd_WEB(Felhasznalo felhasznalo); //HTTP(S) POST INSERT CRUD-Create

        [OperationContract]

        string FelhasznaloModosit_CS(Felhasznalo felhasznalo); //SOAP C# PUT UPDATE CRUD-Update

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/FelhasznaloModosit")]
        string FelhasznaloModosit_WEB(Felhasznalo felhasznalo); //HTTP(S) PUT UPDATE CRUD-Update

        [OperationContract]

        string FelhasznaloTorol_CS(int? id); //SOAP C# DELETE DELETE CRUD-Delete

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/FelhasznaloTorol?id={id}")]
        string FelhasznaloTorol_WEB(int id); //HTTP(S) DELETE DELETE CRUD-Delete
    }
}
