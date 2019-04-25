using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MZ
{
    /// <summary>
    /// Summary description for WebServiceMZ
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceMZ : System.Web.Services.WebService
    {
        DatasetDataContext database = new DatasetDataContext();

        [WebMethod]
        public bool Login(string username, string password) //metoda odpowiadająca za logowanie
        {
            var query = from db in database.UzytkownicyMZs
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
        public List<UzytkownicyMZ> GetUsers() // metoda wyswietlajaca wszystkich uzytkownikow w bazie danych
        {
            var query = from db in database.UzytkownicyMZs
                        select db;

            List<UzytkownicyMZ> list = new List<UzytkownicyMZ>();
            foreach (var g in query.ToList())
            {
                list.Add(g);
            }
            return list;
        }

        [WebMethod]
        public int NewUser(byte AccType, string Login, string Password, string Email, string Name, string Surname, string Street, string City, string ZipCode, string HouseNumber, string BlockNumber, string FlatNumber)
        {
            int LoginUsed = 1;
            int EmailUsed = 2;
            int Success = 3;

            var query_login = from db in database.UzytkownicyMZs
                              where db.login == Login
                              select db;

            var query_email = from db in database.UzytkownicyMZs
                              where db.mail == Email
                              select db;

            UzytkownicyMZ NewAcc = new UzytkownicyMZ();

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
                        database.UzytkownicyMZs.InsertOnSubmit(NewAcc);
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
                        database.UzytkownicyMZs.InsertOnSubmit(NewAcc);
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
            var query = from db in database.UzytkownicyMZs
                        where db.id == ID
                        select db;

            foreach (var user in query)
            {
                database.UzytkownicyMZs.DeleteOnSubmit(user);
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
        public List<GryMZ> GetGames() // metoda zwracajaca wszystkie gry znajdujace sie w tabeli gry
        {
            var query = from db in database.GryMZs
                        select db;

            List<GryMZ> list = new List<GryMZ>();
            foreach (var g in query.ToList())
            {
                list.Add(g);
            }
            return list;
        }

        [WebMethod]
        public string AddGame(string name, string description, float price) // metoda dodajaca gre do tabeli gry
        {
            GryMZ NewGame = new GryMZ();

            NewGame.nazwa = name;
            NewGame.opis = description;
            NewGame.cena = price;

            database.GryMZs.InsertOnSubmit(NewGame);

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
            var query = from db in database.GryMZs
                        where db.id == ID
                        select db;

            foreach (var game in query)
            {
                database.GryMZs.DeleteOnSubmit(game);
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
