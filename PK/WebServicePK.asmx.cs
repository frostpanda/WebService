using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

namespace PK
{
    /// <summary>
    /// Summary description for WebServicePK
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServicePK : System.Web.Services.WebService
    {
        DatasetDataContext database = new DatasetDataContext();

        [WebMethod]
        public bool Login(string username, string password) //metoda odpowiadająca za logowanie
        {
            var query = from db in database.UzytkownicyPKs
                        where db.login == username && db.haslo == password && db.typ_konta == 1
                        select db;

            if (query.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public List<UzytkownicyPK> GetUsers() // metoda wyswietlajaca wszystkich uzytkownikow w bazie danych
        {
            var query = from db in database.UzytkownicyPKs
                        select db;

            List<UzytkownicyPK> list = new List<UzytkownicyPK>();
            foreach (var user in query.ToList())
            {
                list.Add(user);
            }
            return list;
        }

        [WebMethod]
        public int NewUser(byte AccType, string Login, string Password, string Email, string Name, string Surname, string Street, string City, string ZipCode, string HouseNumber, string BlockNumber, string FlatNumber)
        {
            int LoginUsed = 1;
            int EmailUsed = 2;
            int Success = 3;

            var query_login = from db in database.UzytkownicyPKs
                              where db.login == Login
                              select db;

            var query_email = from db in database.UzytkownicyPKs
                              where db.mail == Email
                              select db;

            UzytkownicyPK NewAcc = new UzytkownicyPK();

            NewAcc.login = Login;
            NewAcc.haslo = Password;
            NewAcc.mail = Email;
            NewAcc.imie = Name;
            NewAcc.nazwisko = Surname;
            NewAcc.miasto = City;
            NewAcc.k_pocztowy = ZipCode;
            NewAcc.ulica = Street;
            NewAcc.nr_domu = HouseNumber;
            NewAcc.nr_bloku = BlockNumber;
            NewAcc.nr_mieszkania = FlatNumber;
            NewAcc.typ_konta = AccType;

            switch (AccType)
            {
                case 1:
                    if (query_login.Any())
                    {
                        return LoginUsed;
                    }
                    else if (query_email.Any())
                    {
                        return EmailUsed;
                    }
                    else
                    {
                        database.UzytkownicyPKs.InsertOnSubmit(NewAcc);
                        try
                        {
                            database.SubmitChanges();
                            return Success;
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                    }

                default:
                    if (query_login.Any())
                    {
                        return LoginUsed;
                    }
                    else if (query_email.Any())
                    {
                        return EmailUsed;
                    }
                    else
                    {
                        database.UzytkownicyPKs.InsertOnSubmit(NewAcc);
                        try
                        {
                            database.SubmitChanges();
                            return Success;
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                    }
            }

        }

        [WebMethod]
        public string DelUser(Int16 ID) // metoda zwracajaca wszystkie gry znajdujace sie w tabeli gry
        {
            var query = from db in database.UzytkownicyPKs
                        where db.id == ID
                        select db;

            foreach (var user in query)
            {
                database.UzytkownicyPKs.DeleteOnSubmit(user);
            }

            try
            {
                database.SubmitChanges();
                return "Pomyślnie usunięto użytkownika";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public List<GryPK> GetGames() // metoda zwracajaca wszystkie gry znajdujace sie w tabeli gry
        {
            var query = from db in database.GryPKs
                        select db;

            List<GryPK> list = new List<GryPK>();
            foreach (var g in query.ToList())
            {
                list.Add(g);
            }
            return list;
        }

        [WebMethod]
        public string AddGame(string name, string description, float price) // metoda dodajaca gre do tabeli gry
        {
            GryPK NewGame = new GryPK();

            NewGame.nazwa = name;
            NewGame.opis = description;
            NewGame.cena = price;

            database.GryPKs.InsertOnSubmit(NewGame);

            try
            {
                database.SubmitChanges();
                return "Pomyślnie dodano grę";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public string DelGame(Int16 ID) // metoda zwracajaca wszystkie gry znajdujace sie w tabeli gry
        {
            var query = from db in database.GryPKs
                        where db.id == ID
                        select db;

            foreach (var game in query)
            {
                database.GryPKs.DeleteOnSubmit(game);
            }

            try
            {
                database.SubmitChanges();
                return "Pomyślnie usunięto grę";
            }
            catch (Exception e)
            {
                return ("Coś poszło nie tak... Gra nie została dodana do bazy.");
            }
        }
    }
}
