using SERVER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SERVER
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        //Felhasznalok
        #region Felhasznalok
        public List<Felhasznalo> FelhasznaloLista_CS(string where)
        {
            Controllers.FelhasznalokController felhasznalokController=new Controllers.FelhasznalokController();
            List<Record> records = felhasznalokController.Select(where);
            List<Felhasznalo> felhasznalok = new List<Felhasznalo>();
            foreach (Record record in records)
            {
                felhasznalok.Add(record as Felhasznalo);
            }
            return felhasznalok;
        }

        public List<Felhasznalo> FelhasznaloLista_WEB(string where)
        {
            return FelhasznaloLista_CS(where);
        }

        public string FelhasznaloHozzaAd_CS(Felhasznalo felhasznalo)
        {
            Controllers.FelhasznalokController felhasznalokController = new Controllers.FelhasznalokController();
            return felhasznalokController.Insert(felhasznalo);
        }

        public string FelhasznaloHozzaAd_WEB(Felhasznalo felhasznalo)
        {
            return FelhasznaloHozzaAd_CS(felhasznalo);
        }

        public string FelhasznaloModosit_CS(Felhasznalo felhasznalo)
        {
            Controllers.FelhasznalokController felhasznalokController = new Controllers.FelhasznalokController();
            return felhasznalokController.Update(felhasznalo);
        }

        public string FelhasznaloModosit_WEB(Felhasznalo felhasznalo)
        {
            return FelhasznaloModosit_CS(felhasznalo);
        }

        public string FelhasznaloTorol_CS(int? id)
        {
            Controllers.FelhasznalokController felhasznalokController = new Controllers.FelhasznalokController();
            return felhasznalokController.Delete(id);
        }

        public string FelhasznaloTorol_WEB(int id)
        {
            return FelhasznaloTorol_CS(id);
        }
#endregion

        //Jogosultsagok
        #region Jogosultsagok
        public List<Jogosultsagok> JogosultsagokLista_CS(string where)
        {
            Controllers.JogosultsagokController jogosultsagokController = new Controllers.JogosultsagokController();
            List<Record> records = jogosultsagokController.Select(where);
            List<Jogosultsagok> jogosultsag = new List<Jogosultsagok>();
            foreach (Record record in records)
            {
                jogosultsag.Add(record as Jogosultsagok);
            }
            return jogosultsag;
        }

        public List<Jogosultsagok> JogosultsagokLista_WEB(string where)
        {
            return JogosultsagokLista_CS(where);
        }

        public string JogosultsagokHozzaAd_CS(Jogosultsagok jogosultsag)
        {
            Controllers.JogosultsagokController jogosultsagokController = new Controllers.JogosultsagokController();
            return jogosultsagokController.Insert(jogosultsag);
        }

        public string JogosultsagokHozzaAd_WEB(Jogosultsagok jogosultsag)
        {
            return JogosultsagokHozzaAd_CS(jogosultsag);
        }

        public string JogosultsagokModosit_CS(Jogosultsagok jogosultsag)
        {
            Controllers.JogosultsagokController jogosultsagController = new Controllers.JogosultsagokController();
            return jogosultsagController.Update(jogosultsag);
        }

        public string JogosultsagokModosit_WEB(Jogosultsagok jogosultsag)
        {
            return JogosultsagokModosit_CS(jogosultsag);
        }

        public string JogosultsagokTorol_CS(int? id)
        {
            Controllers.JogosultsagokController jogosultsagController = new Controllers.JogosultsagokController();
            return jogosultsagController.Delete(id);
        }

        public string JogosultsagokTorol_WEB(int id)
        {
            return JogosultsagokTorol_CS(id);
        }
        #endregion

        //Login
        #region Login

        public string GetSalt_CS(string Fnev)
        {
            Controllers.LoginController loginController = new Controllers.LoginController();
            return loginController.Salt(Fnev);
        }

        public string GetSalt_WEB(string Fnev)
        {
            return GetSalt_CS(Fnev);
        }

        public string Login_CS(Datazs data)
        {
            Controllers.LoginController LoginController = new Controllers.LoginController();
            return LoginController.Login(data);
        }

        public string Login_WEB(Datazs data)
        {
            return Login_CS(data);
        }
        #endregion
    }
}
