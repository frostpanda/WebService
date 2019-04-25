using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using ServiceG2A.MZ;
using ServiceG2A.PK;

namespace ServiceG2A
{
    /// <summary>
    /// Summary description for Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/", Name = "G2A.com", Description = "G2A.com service")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //[System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Methods : WebService
    {
        WebServicePKSoapClient WebServicePK = new WebServicePKSoapClient();
        WebServiceMZSoapClient WebServiceMZ = new WebServiceMZSoapClient();

        [WebMethod]
        public bool Login(string login, string password)
        {
            if (WebServicePK.Login(login, password) || WebServiceMZ.Login(login, password))
            {
                return true;
            }
            else
                return false;
        }

        [WebMethod]
        public List<PK.GryPK> GamesPK()
        {
            List<PK.GryPK> gamesPK = new List<PK.GryPK>();
            gamesPK = WebServicePK.GetGames();
            return gamesPK;
        }

        [WebMethod]
        public List<MZ.GryMZ> GamesMZ()
        {
            List<MZ.GryMZ> gamesMZ = new List<MZ.GryMZ>();
            gamesMZ = WebServiceMZ.GetGames();
            return gamesMZ;
        }

        [WebMethod]
        public string AddGame(string place, string name, string description, float price)
        {
            switch(place)
            {
                case "Podkarpackie":
                    return WebServicePK.AddGame(name, description, price);
                case "Mazowieckie":
                    return WebServiceMZ.AddGame(name, description, price);
                default:
                    return "";
            }
        }

        [WebMethod]
        public string DelGame(string place, Int16 id)
        {
            switch(place)
            {
                case "Podkarpackie":
                    return WebServicePK.DelGame(id);
                case "Mazowieckie":
                    return WebServiceMZ.DelGame(id);
                default:
                    return "";
            }
        }

        [WebMethod]
        public List<MZ.UzytkownicyMZ> UsersMZ()
        {
            List<MZ.UzytkownicyMZ> usersMZ = new List<MZ.UzytkownicyMZ>();
            usersMZ = WebServiceMZ.GetUsers();
            return usersMZ;
        }

        [WebMethod]
        public List<PK.UzytkownicyPK> UsersPK()
        {
            List<PK.UzytkownicyPK> usersPK = new List<PK.UzytkownicyPK>();
            usersPK = WebServicePK.GetUsers();
            return usersPK;
        }

        [WebMethod]
        public int NewUser(string place, byte AccType, string Login, string Password, string Email, string Name, string Surname, string Street, string City, string ZipCode, string HouseNumber, string BlockNumber, string FlatNumber)
        {
            switch(place)
            {
                case "Podkarpackie":
                    return WebServicePK.NewUser(AccType, Login, Password, Email, Name, Surname, Street, City, ZipCode, HouseNumber, BlockNumber, FlatNumber);
                case "Mazowieckie":
                    return WebServiceMZ.NewUser(AccType, Login, Password, Email, Name, Surname, Street, City, ZipCode, HouseNumber, BlockNumber, FlatNumber);
                default:
                    return 0;
            }
        }

        [WebMethod]
        public string DelUser(string place, Int16 id)
        {
            switch (place)
            {
                case "Podkarpackie":
                    return WebServicePK.DelUser(id);
                case "Mazowieckie":
                    return WebServiceMZ.DelUser(id);
                default:
                    return "";
            }
        }
    }
}
