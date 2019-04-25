using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Client.ServiceG2A;

namespace Client
{
    public partial class Form1 : Form
    {
        G2AcomSoapClient WebService = new G2AcomSoapClient();
        private string place;
 
        public Form1()
        {
            InitializeComponent();
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            wylogujToolStripMenuItem.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panel2.Visible == true)
            {
                panel2.Visible = false;
                panel1.Visible = true;
            }
            else if (panel3.Visible == true)
            {
                panel3.Visible = false;
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = true;
            }

            UsernameBox.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string login = UsernameBox.Text;
            string password = PswdBox.Text;

            if (string.IsNullOrEmpty(login) == true || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Uzupełnij oba pola!", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                bool ws_login = WebService.Login(login,password);
                if (ws_login == true)
                {
                    UsernameBox.Clear();
                    PswdBox.Clear();

                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();

                    panel1.Visible  = false;
                    panel2.Visible  = false;
                    panel3.Visible  = false;
                    panel4.Visible  = true;
                    panel5.Visible  = true;
                    panel10.Visible = true;

                    loginToolStripMenuItem.Enabled = false;
                    gamesInStoreToolStripMenuItem.Enabled = false;
                    rejestracjaToolStripMenuItem.Enabled = false;
                    wylogujToolStripMenuItem.Visible = true;
                }
                else
                {
                    MessageBox.Show("Niepoprawne dane logowania, \nbądźnie masz uprawnień do logowania. \nPopraw dane i spróbuj ponownie. \nJeżeli problem będzie występować mimo wpisania poprawnych danych, proszę skontaktować się z administratorem.", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    UsernameBox.Clear();
                    PswdBox.Clear();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UsernameBox.Clear();
            PswdBox.Clear();
        }

        private void gamesInStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == true)
            {
                panel1.Visible = false;
                panel2.Visible = true;
            }
            else if (panel3.Visible == true)
            {
                panel3.Visible = false;
                panel2.Visible = true;
            }
            else
                panel2.Visible = true;
        }

        private void rejestracjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == true)
            {
                panel1.Visible = false;
                panel3.Visible = true;
            }
            else if (panel2.Visible == true)
            {
                panel2.Visible = false;
                panel3.Visible = true;
            }
            else
                panel3.Visible = true;

            MessageBox.Show("W celu rejestracji należy uzupełnić wszystkie pola.");
            NameBox.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string login = LoginBox.Text;
            string password = PasswordBox.Text;
            string confirmPassword = VerifyPasswordBox.Text;
            string email = EmailBox.Text;
            string name = NameBox.Text;
            string surname = SurnameBox.Text;
            string city = CityBox.Text;
            string zipCode = ZipCodeBox.Text;
            string street = StreetBox.Text;
            string blockNumber = BlockNumberBox.Text;
            string flatNumber = FlatNumberBox.Text;
            string houseNumber = HouseNumberBox.Text;
            string place = PlaceComboBox.GetItemText(PlaceComboBox.SelectedItem);

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(street) || string.IsNullOrEmpty(zipCode) || (ResidentialBlock.Checked == false && DetachedHouse.Checked == false))
            {
                MessageBox.Show("Uzupełnij i zaznacz wszystkie pola!");
                if (DetachedHouse.Checked == true)
                {
                    if (string.IsNullOrEmpty(houseNumber) == true)
                    {
                        MessageBox.Show("Uzupełnij i zaznacz wszystkie pola!");
                    }
                }

                if (ResidentialBlock.Checked == true)
                {
                    if (string.IsNullOrEmpty(blockNumber) == true || string.IsNullOrEmpty(flatNumber))
                    {
                        MessageBox.Show("Uzupełnij i zaznacz wszystkie pola!");
                    }
                }

            }
            else if (Regex.IsMatch(name, @"^[a-ząęćłńóśżA-ZĄĘĆŁŃÓŚŹŻ]+$") == false)
            {
                DialogResult result = MessageBox.Show("Podaj poprawne imie! \nZresetować pole?", "Błąd!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (result == DialogResult.Yes)
                {
                    NameBox.Clear();
                    NameBox.Focus();
                }
            }
            else if (Regex.IsMatch(surname, @"^[a-ząęćłńóśżA-ZĄĘĆŁŃÓŚŹŻ]+$") == false)
            {
                DialogResult result = MessageBox.Show("Podaj poprawne nazwisko! \nZresetować pole?", "Błąd!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    SurnameBox.Clear();
                    SurnameBox.Focus();
                }
            }
            else if (Regex.IsMatch(login, @"^[a-z0-9]{6,}$") == false)
            {
                DialogResult result = MessageBox.Show("Podaj poprawny login! \nDozwolone liczby i litery, bez polskich znaków. \nMinimalna liczba znaków to 6. \nZresetować pole?", "Błąd!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    LoginBox.Clear();
                    LoginBox.Focus();
                }
            }
            else if (Regex.IsMatch(password, @"^[a-zA-Z0-9-_]{6,}$") == false)
            {
                DialogResult result = MessageBox.Show("Podaj poprawe hasło! \nDozwolone tylko male litery, liczby, myślnik oraz podkreślnik, bez polskich znaków. \nMinimalna długość hasła to 6 znaków. \nZresetować pole?", "Błąd!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    PasswordBox.Clear();
                    PasswordBox.Focus();
                }
            }
            else if (password != confirmPassword)
            {
                DialogResult result = MessageBox.Show("Hasła się różnią! \nPopraw odpowiednie pola. \nZresetować pola?", "Błąd!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    PasswordBox.Clear();
                    VerifyPasswordBox.Clear();
                    PasswordBox.Focus();
                }
            }
            else if (Regex.IsMatch(email, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", RegexOptions.IgnoreCase) == false)
            {
                DialogResult result = MessageBox.Show("Podaj poprawny adres mailowy! \nZresetować pole?", "Błąd!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    EmailBox.Clear();
                    EmailBox.Focus();
                }
            }
            else if (Regex.IsMatch(city, @"^[a-ząęćłńóśżA-ZĄĘĆŁŃÓŚŹŻ]{1,}$") == false)
            {
                DialogResult result = MessageBox.Show("Podaj poprawną miejscowość! \nDozwolone tylko litery \nZresetować pole?", "Błąd!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    CityBox.Clear();
                    CityBox.Focus();
                }
            }
            else if (Regex.IsMatch(zipCode, @"^\d{2}-\d{3}$") == false)
            {
                DialogResult result = MessageBox.Show("Podaj poprawny kod pocztowy! \nDozwolony format XX-XXX \nZresetować pole?", "Błąd!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    ZipCodeBox.Clear();
                    ZipCodeBox.Focus();
                }
            }
            else if (Regex.IsMatch(street, @"^[a-ząęćłńóśżA-ZĄĘĆŁŃÓŚŹŻ ]+") == false)
            {
                DialogResult result = MessageBox.Show("Podaj poprawną nazwę ulicy! \nDozwolone tylko litery \nZresetować pole?", "Błąd!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    StreetBox.Clear();
                    StreetBox.Focus();
                }
            }
            else if (ResidentialBlock.Checked == false && DetachedHouse.Checked == false)
            {
                DialogResult result = MessageBox.Show("Wybierz, czy mieszkasz w domu, czy w domu wolnostojącym.", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (DetachedHouse.Checked == true && Regex.IsMatch(houseNumber, @"^[a-z0-9]{1,5}$") == false)
            {
                DialogResult result = MessageBox.Show("Pole jest puste bądź podałeś/ąś niepoprawny domu! \nDostępne tylko liczby oraz litery.Przykład: 50a, 50. \nZresetować pole?", "Błąd!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    HouseNumberBox.Clear();
                    HouseNumberBox.Focus();
                }
            }
            else if (ResidentialBlock.Checked == true && Regex.IsMatch(blockNumber, @"^[0-9]{1,10}$") == false)
            {
                DialogResult result = MessageBox.Show("Pole jest puste bądź podałeś/ąś niepoprawny numer bloku! \nDostępne tylko liczby.\nZresetować pole?", "Błąd!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    BlockNumberBox.Clear();
                    BlockNumberBox.Focus();
                }
            }
            else if (ResidentialBlock.Checked == true && Regex.IsMatch(flatNumber, @"^[0-9]{1,10}$") == false)
            {
                DialogResult result = MessageBox.Show("Pole jest puste bądź podałeś/ąś niepoprawny numer mieszkania! \nDostępne tylko liczby.\nZresetować pole?", "Błąd!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    FlatNumberBox.Clear();
                    FlatNumberBox.Focus();
                }
            }
            else if (PlaceComboBox.SelectedIndex == -1)
            {
                DialogResult result = MessageBox.Show("Nie wybrałeś,w którym sklepie chcesz się zarejestrować.\nDokonaj wyboru?", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PlaceComboBox.SelectedItem = -1;
            }
            else
            {
                int message = WebService.NewUser(place, 0, login, password, email, name, surname, street, city, zipCode, houseNumber, blockNumber, flatNumber);
                
                if (message == 1)
                {
                    DialogResult result = MessageBox.Show("Podany login jest zajęty. \nProszę wybrać inny \nZresetować pole Login?", "Błąd!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        LoginBox.Clear();
                        LoginBox.Focus();
                    }
                }
                else if (message == 2)
                {
                    DialogResult result = MessageBox.Show("Podany adres mailowy jest zajęty. \nProszę podać inny \nZresetować pole Email?", "Błąd!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    {
                        EmailBox.Clear();
                        EmailBox.Focus();
                    }
                }
                else if (message == 3)
                {
                    MessageBox.Show("Pomyślnie zarejestrowano użytkownika");
                    NameBox.Clear();
                    SurnameBox.Clear();
                    LoginBox.Clear();
                    PasswordBox.Clear();
                    EmailBox.Clear();
                    VerifyPasswordBox.Clear();
                    CityBox.Clear();
                    StreetBox.Clear();
                    HouseNumberBox.Clear();
                    BlockNumberBox.Clear();
                    FlatNumberBox.Clear();
                    ZipCodeBox.Clear();
                    PlaceComboBox.SelectedItem = -1;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NameBox.Clear();
            SurnameBox.Clear();
            LoginBox.Clear();
            PasswordBox.Clear();
            EmailBox.Clear();
            CityBox.Clear();
            StreetBox.Clear();
            FlatNumberBox.Clear();
            HouseNumberBox.Clear();
            ZipCodeBox.Clear();
            VerifyPasswordBox.Clear();
            HouseNumberBox.Clear();
            FlatNumberBox.Clear();
        }

        private void użytkownicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView3.Visible == true)
            {
                dataGridView3.Visible = false;
                dataGridView2.Visible = true;
                dataGridView3.DataSource = null;
                dataGridView3.Rows.Clear();
            }
            else
                dataGridView2.Visible = true;

            //dataGridView2.DataSource = WebService.GetUsers();

            dataGridView2.Columns[0].HeaderText  = "L.P";
            dataGridView2.Columns[1].HeaderText  = "Login";
            dataGridView2.Columns[3].HeaderText  = "Email";
            dataGridView2.Columns[4].HeaderText  = "Imię";
            dataGridView2.Columns[5].HeaderText  = "Nazwisko";
            dataGridView2.Columns[6].HeaderText  = "Miasto";
            dataGridView2.Columns[7].HeaderText  = "Kod pocztowy";
            dataGridView2.Columns[8].HeaderText  = "Ulica";
            dataGridView2.Columns[9].HeaderText  = "Numer domu";
            dataGridView2.Columns[10].HeaderText = "Numer bloku";
            dataGridView2.Columns[11].HeaderText = "Numer mieszkania";

            dataGridView2.Columns[2].Visible = false;

            panel5.Visible = true;
        }

        private void wylogujToolStripMenuItem_Click(object sender, EventArgs e)
        {         
            gamesInStoreToolStripMenuItem.Enabled = true;
            rejestracjaToolStripMenuItem.Enabled  = true;
            loginToolStripMenuItem.Enabled        = true;
            wylogujToolStripMenuItem.Visible      = false;

            dataGridView2.Visible = false;
            dataGridView3.Visible = false;

            panel4.Visible = false;

            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView3.DataSource = null;
            dataGridView3.Rows.Clear();
        }

        private void gryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Visible == true)
            {
                panel6.Visible = false;
                panel7.Visible = false;
                dataGridView2.Visible = false;
                dataGridView3.Visible = true;
            }
            else
                dataGridView3.Visible = true;

            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();

            //dataGridView3.DataSource = WebService.GetGames();

            dataGridView3.Columns[0].Width = 50;
            dataGridView3.Columns[1].Width = 170;
            dataGridView3.Columns[2].Width = 625;
            dataGridView3.Columns[3].Width = 50;

            dataGridView3.Columns[0].HeaderText = "L.P";
            dataGridView3.Columns[1].HeaderText = "Nazwa gry";
            dataGridView3.Columns[2].HeaderText = "Opis";
            dataGridView3.Columns[3].HeaderText = "Cena";
        }

        private void dodajAdministratoraToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (panel7.Visible == true)
            {
                panel7.Visible = false;
                panel6.Visible = true;
            }
            else
                panel6.Visible = true;
        }

        private void textBoxTest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(this, new EventArgs());
            }
        }

        private void PswdBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(this, new EventArgs());
            }
        }

        private void ResidentialBlock_CheckedChanged(object sender, EventArgs e)
        {
            if (BlockNumberBox.Enabled == false || FlatNumberBox.Enabled == false)
            {
                HouseNumberBox.Enabled = false;
                HouseNumberBox.Clear();
                BlockNumberBox.Enabled = true;
                FlatNumberBox.Enabled  = true;
            }
        }

        private void DetachedHouse_CheckedChanged(object sender, EventArgs e)
        {
            if (HouseNumberBox.Enabled == false)
            {
                BlockNumberBox.Enabled = false;
                BlockNumberBox.Clear();
                FlatNumberBox.Enabled  = false;
                FlatNumberBox.Clear();
                HouseNumberBox.Enabled = true;
            }
                
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (panel6.Visible == true)
            {
                panel6.Visible = false;
                panel7.Visible = true;
            }
            else
                panel7.Visible = true;

            UsersID.Items.Clear();

            for (int i = 0; i <= (dataGridView2.Rows.Count - 1); i++)
            {
                UsersID.Items.Add(dataGridView2.Rows[i].Cells["id"].Value);
            }
        }

        private void AdminClear_Click_1(object sender, EventArgs e)
        {
            AdminLoginBox.Clear();
            AdminPasswordBox.Clear();
            ConfirmAdminPasswordBox.Clear();
            AdminEmailBox.Clear();
        }

        private void AdminAdd_Click_1(object sender, EventArgs e)
        {
            string login = AdminLoginBox.Text;
            string password = AdminPasswordBox.Text;
            string confirmPassword = ConfirmAdminPasswordBox.Text;
            string email = AdminEmailBox.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(email) )
            {
                MessageBox.Show("Uzupełnij i zaznacz wszystkie pola!");
            }
            else if (Regex.IsMatch(login, @"^[a-z0-9]+$") == false)
            {
                DialogResult result = MessageBox.Show("Podaj poprawny login! \nDozwolone liczby i litery, bez polskich znaków. \nZresetować pole?", "Błąd!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    AdminLoginBox.Clear();
                    AdminLoginBox.Focus();
                }
            }
            else if (Regex.IsMatch(password, @"^[a-zA-Z0-9-_]{6,}$") == false)
            {
                DialogResult result = MessageBox.Show("Podaj poprawe hasło! \nDozwolone tylko male litery, liczby, myślnik oraz podkreślnik, bez polskich znaków. \nMinimalna długość hasła to 6 znaków. \nZresetować pole?", "Błąd!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    AdminPasswordBox.Clear();
                    AdminPasswordBox.Focus();
                }
            }
            else if (password != confirmPassword)
            {
                DialogResult result = MessageBox.Show("Hasła się różnią! \nPopraw odpowiednie pola. \nZresetować pola?", "Błąd!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    AdminPasswordBox.Clear();
                    ConfirmAdminPasswordBox.Clear();
                    AdminPasswordBox.Focus();
                }
            }
            else if (Regex.IsMatch(email, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", RegexOptions.IgnoreCase) == false)
            {
                DialogResult result = MessageBox.Show("Podaj poprawny adres mailowy! \nZresetować pole?", "Błąd!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    AdminEmailBox.Clear();
                    AdminEmailBox.Focus();
                }
            }
            else
            {
                int message = WebService.NewUser(place, 1, login, password, email, Name: "", Surname: "", Street: "", City: "", ZipCode: "", HouseNumber: "", BlockNumber: "", FlatNumber: "");

                if (message == 1)
                {
                    DialogResult result = MessageBox.Show("Podany login jest zajęty. \nProszę wybrać inny \nZresetować pole Login?", "Błąd!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        AdminLoginBox.Clear();
                        AdminLoginBox.Focus();
                    }

                }
                else if (message == 2)
                {
                    DialogResult result = MessageBox.Show("Podany adres mailowy jest zajęty. \nProszę podać inny \nZresetować pole Email?", "Błąd!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    {
                        AdminEmailBox.Clear();
                        AdminEmailBox.Focus();
                    }
                }
                else if (message == 3)
                {
                    MessageBox.Show("Pomyślnie dodano nowego administratora");

                    AdminLoginBox.Clear();
                    AdminPasswordBox.Clear();
                    ConfirmAdminPasswordBox.Clear();
                    AdminEmailBox.Clear();

                    if (place == "Podkarpackie")
                    {
                        dataGridView2.DataSource = null;
                        dataGridView2.Rows.Clear();
                        dataGridView2.DataSource = WebService.UsersPK();
                        dataGridView2.Columns[1].HeaderText = "L.P";
                        dataGridView2.Columns[2].HeaderText = "Login";
                        dataGridView2.Columns[4].HeaderText = "Email";
                        dataGridView2.Columns[5].HeaderText = "Imię";
                        dataGridView2.Columns[6].HeaderText = "Nazwisko";
                        dataGridView2.Columns[7].HeaderText = "Miasto";
                        dataGridView2.Columns[8].HeaderText = "Kod pocztowy";
                        dataGridView2.Columns[9].HeaderText = "Ulica";
                        dataGridView2.Columns[10].HeaderText = "Numer domu";
                        dataGridView2.Columns[11].HeaderText = "Numer bloku";
                        dataGridView2.Columns[12].HeaderText = "Numer mieszkania";
                        dataGridView2.Columns[0].Visible = false;
                    }
                    else
                    {
                        dataGridView2.DataSource = null;
                        dataGridView2.Rows.Clear();
                        dataGridView2.DataSource = WebService.UsersMZ();
                        dataGridView2.Columns[1].HeaderText = "L.P";
                        dataGridView2.Columns[2].HeaderText = "Login";
                        dataGridView2.Columns[4].HeaderText = "Email";
                        dataGridView2.Columns[5].HeaderText = "Imię";
                        dataGridView2.Columns[6].HeaderText = "Nazwisko";
                        dataGridView2.Columns[7].HeaderText = "Miasto";
                        dataGridView2.Columns[8].HeaderText = "Kod pocztowy";
                        dataGridView2.Columns[9].HeaderText = "Ulica";
                        dataGridView2.Columns[10].HeaderText = "Numer domu";
                        dataGridView2.Columns[11].HeaderText = "Numer bloku";
                        dataGridView2.Columns[12].HeaderText = "Numer mieszkania";
                        dataGridView2.Columns[0].Visible = false;
                    }

                }
            }
        }

        private void DelUserButton_Click(object sender, EventArgs e)
        {
            if (UsersID.SelectedIndex > -1)
            {
                Int16 id = Convert.ToInt16(UsersID.GetItemText(UsersID.SelectedItem));

                MessageBox.Show(WebService.DelUser(place, id));

                UsersID.Items.Clear();
                UsersID.Text = "Wybierz ID użytkownika";

                if (place == "Podkarpackie")
                {
                    dataGridView2.DataSource = null;
                    dataGridView2.Rows.Clear();
                    dataGridView2.DataSource = WebService.UsersPK();
                    dataGridView2.Columns[1].HeaderText = "L.P";
                    dataGridView2.Columns[2].HeaderText = "Login";
                    dataGridView2.Columns[4].HeaderText = "Email";
                    dataGridView2.Columns[5].HeaderText = "Imię";
                    dataGridView2.Columns[6].HeaderText = "Nazwisko";
                    dataGridView2.Columns[7].HeaderText = "Miasto";
                    dataGridView2.Columns[8].HeaderText = "Kod pocztowy";
                    dataGridView2.Columns[9].HeaderText = "Ulica";
                    dataGridView2.Columns[10].HeaderText = "Numer domu";
                    dataGridView2.Columns[11].HeaderText = "Numer bloku";
                    dataGridView2.Columns[12].HeaderText = "Numer mieszkania";
                    dataGridView2.Columns[0].Visible = false;
                    dataGridView2.Columns[3].Visible = false;
                }
                else
                {
                    dataGridView2.DataSource = null;
                    dataGridView2.Rows.Clear();
                    dataGridView2.DataSource = WebService.UsersMZ();
                    dataGridView2.Columns[1].HeaderText = "L.P";
                    dataGridView2.Columns[2].HeaderText = "Login";
                    dataGridView2.Columns[4].HeaderText = "Email";
                    dataGridView2.Columns[5].HeaderText = "Imię";
                    dataGridView2.Columns[6].HeaderText = "Nazwisko";
                    dataGridView2.Columns[7].HeaderText = "Miasto";
                    dataGridView2.Columns[8].HeaderText = "Kod pocztowy";
                    dataGridView2.Columns[9].HeaderText = "Ulica";
                    dataGridView2.Columns[10].HeaderText = "Numer domu";
                    dataGridView2.Columns[11].HeaderText = "Numer bloku";
                    dataGridView2.Columns[12].HeaderText = "Numer mieszkania";
                    dataGridView2.Columns[0].Visible = false;
                }


                for (int i = 0; i <= (dataGridView2.Rows.Count - 1); i++)
                {
                    UsersID.Items.Add(dataGridView2.Rows[i].Cells["id"].Value);
                }
            }
            else
                MessageBox.Show("Nie wybrano numeru użytkownika do usunięcia. Wybierz i spróbuj ponownie.");
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            GameNameBox.Clear();
            GamePriceBox.Clear();
            GameDescriptionBox.Clear();
        }

        private void AddGame_Click(object sender, EventArgs e)
        {
            string name = GameNameBox.Text;
            string description = GameDescriptionBox.Text;
            string price = GamePriceBox.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(price))
            {
                MessageBox.Show("Uzupełnij i zaznacz wszystkie pola!");
            }
            else if (Regex.IsMatch(name, @"^[a-ząęćłńóśżA-ZĄĘĆŁŃÓŚŹŻ0-9-_,.'/:;IVX ]+$") == false )
            {
                DialogResult result = MessageBox.Show("Popraw nazwę gry! \nDozwolone małe i duże litery, liczby, polskie znaki, liczby rzymskie \n oraz takie znaki jak: -_,.'/:;. \nZresetować pole?", "Błąd!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    GameNameBox.Clear();
                    GameNameBox.Focus();
                }
            }
            else if (Regex.IsMatch(price, @"^[0-9]{1,3},[0-9]{2}$") == false)
            {
                DialogResult result = MessageBox.Show("Podaj poprawną cenę! \nDozwolone liczby i przecinek. Format: XXX,XX (np. 23,47; 100,00) \nZresetować pole?", "Błąd!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    GamePriceBox.Clear();
                    GamePriceBox.Focus();
                }
            }
            else
            {
                string message = WebService.AddGame(place, name, description, Convert.ToSingle(price));
                MessageBox.Show(message);

                GameNameBox.Clear();
                GameDescriptionBox.Clear();
                GamePriceBox.Clear();

                if (place == "Podkarpackie")
                {
                    dataGridView3.DataSource = null;
                    dataGridView3.Rows.Clear();
                    dataGridView3.DataSource = WebService.GamesPK();
                    dataGridView3.Columns[1].Width = 50;
                    dataGridView3.Columns[2].Width = 170;
                    dataGridView3.Columns[3].Width = 625;
                    dataGridView3.Columns[4].Width = 50;
                    dataGridView3.Columns[1].HeaderText = "L.P";
                    dataGridView3.Columns[2].HeaderText = "Nazwa gry";
                    dataGridView3.Columns[3].HeaderText = "Opis";
                    dataGridView3.Columns[4].HeaderText = "Cena";
                    dataGridView3.Columns[0].Visible = false;
                }
                else
                {
                    dataGridView3.DataSource = null;
                    dataGridView3.Rows.Clear();
                    dataGridView3.DataSource = WebService.GamesMZ();
                    dataGridView3.Columns[1].Width = 50;
                    dataGridView3.Columns[2].Width = 170;
                    dataGridView3.Columns[3].Width = 625;
                    dataGridView3.Columns[4].Width = 50;
                    dataGridView3.Columns[1].HeaderText = "L.P";
                    dataGridView3.Columns[2].HeaderText = "Nazwa gry";
                    dataGridView3.Columns[3].HeaderText = "Opis";
                    dataGridView3.Columns[4].HeaderText = "Cena";
                    dataGridView3.Columns[0].Visible = false;
                }
            }
        }

        private void dodajGręToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (panel9.Visible == true)
            {
                panel9.Visible = false;
                panel8.Visible = true;
            }
            else
            {
                panel8.Visible = true;
            }
        }

        private void DelGame_Click(object sender, EventArgs e)
        {
            if (GamesID.SelectedIndex > -1)
            {
                Int16 id = Convert.ToInt16(GamesID.GetItemText(GamesID.SelectedItem));

                MessageBox.Show(WebService.DelGame(place, id));

                if (place == "Podkarpackie")
                {
                    dataGridView3.DataSource = null;
                    dataGridView3.Rows.Clear();
                    dataGridView3.DataSource = WebService.GamesPK();
                    dataGridView3.Columns[1].Width = 50;
                    dataGridView3.Columns[2].Width = 170;
                    dataGridView3.Columns[3].Width = 625;
                    dataGridView3.Columns[4].Width = 50;
                    dataGridView3.Columns[1].HeaderText = "L.P";
                    dataGridView3.Columns[2].HeaderText = "Nazwa gry";
                    dataGridView3.Columns[3].HeaderText = "Opis";
                    dataGridView3.Columns[4].HeaderText = "Cena";
                    dataGridView3.Columns[0].Visible = false;
                }
                else
                {
                    dataGridView3.DataSource = null;
                    dataGridView3.Rows.Clear();
                    dataGridView3.DataSource = WebService.GamesMZ();
                    dataGridView3.Columns[1].Width = 50;
                    dataGridView3.Columns[2].Width = 170;
                    dataGridView3.Columns[3].Width = 625;
                    dataGridView3.Columns[4].Width = 50;
                    dataGridView3.Columns[1].HeaderText = "L.P";
                    dataGridView3.Columns[2].HeaderText = "Nazwa gry";
                    dataGridView3.Columns[3].HeaderText = "Opis";
                    dataGridView3.Columns[4].HeaderText = "Cena";
                    dataGridView3.Columns[0].Visible = false;
                }

                GamesID.Items.Clear();
                GamesID.Text = "Wybierz ID użytkownika";

                for (int i = 0; i <= (dataGridView3.Rows.Count - 1); i++)
                {
                    GamesID.Items.Add(dataGridView3.Rows[i].Cells["id"].Value);
                }
            }
            else
                MessageBox.Show("Nie wybrano numeru użytkownika do usunięcia. Wybierz i spróbuj ponownie.");
        }

        private void usuńGręToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (panel8.Visible == true)
            {
                panel8.Visible = false;
                panel9.Visible = true;
            }
            else
                panel9.Visible = true;

            GamesID.Items.Clear();

            for (int i = 0; i <= (dataGridView3.Rows.Count - 1); i++)
            {
                GamesID.Items.Add(dataGridView3.Rows[i].Cells["id"].Value);
            }
        }

        private void podkarpackieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();

                dataGridView1.DataSource = WebService.GamesPK();

                dataGridView1.Columns[0].Visible = false;

                dataGridView1.Columns[1].HeaderText = "L.P";
                dataGridView1.Columns[2].HeaderText = "Nazwa gry";
                dataGridView1.Columns[3].HeaderText = "Opis";
                dataGridView1.Columns[4].HeaderText = "Cena";

                dataGridView1.Columns[1].Width = 30;
                dataGridView1.Columns[2].Width = 107;
                dataGridView1.Columns[3].Width = 700;
                dataGridView1.Columns[4].Width = 60;
            }
            else
            {
                dataGridView1.DataSource = WebService.GamesPK();

                dataGridView1.Columns[0].Visible = false;

                dataGridView1.Columns[1].HeaderText = "L.P";
                dataGridView1.Columns[2].HeaderText = "Nazwa gry";
                dataGridView1.Columns[3].HeaderText = "Opis";
                dataGridView1.Columns[4].HeaderText = "Cena";

                dataGridView1.Columns[1].Width = 30;
                dataGridView1.Columns[2].Width = 107;
                dataGridView1.Columns[3].Width = 700;
                dataGridView1.Columns[4].Width = 60;
            }
                
        }

        private void mazowieckieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.DataSource = WebService.GamesMZ();

                dataGridView1.Columns[0].Visible = false;

                dataGridView1.Columns[1].HeaderText = "L.P";
                dataGridView1.Columns[2].HeaderText = "Nazwa gry";
                dataGridView1.Columns[3].HeaderText = "Opis";
                dataGridView1.Columns[4].HeaderText = "Cena";

                dataGridView1.Columns[1].Width = 30;
                dataGridView1.Columns[2].Width = 107;
                dataGridView1.Columns[3].Width = 700;
                dataGridView1.Columns[4].Width = 60;
            }
            else
            {
                dataGridView1.DataSource = WebService.GamesMZ();

                dataGridView1.Columns[0].Visible = false;

                dataGridView1.Columns[1].HeaderText = "L.P";
                dataGridView1.Columns[2].HeaderText = "Nazwa gry";
                dataGridView1.Columns[3].HeaderText = "Opis";
                dataGridView1.Columns[4].HeaderText = "Cena"; ;

                dataGridView1.Columns[1].Width = 30;
                dataGridView1.Columns[2].Width = 107;
                dataGridView1.Columns[3].Width = 700;
                dataGridView1.Columns[4].Width = 60;
            }
        }

        private void uzytkownicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView3.Visible == true)
            {
                panel8.Visible = false;
                panel9.Visible = false;

                dataGridView3.Visible = false;
                dataGridView3.DataSource = null;
                dataGridView3.Rows.Clear();

                dataGridView2.Visible = true;
                dataGridView2.DataSource = WebService.UsersPK();
                dataGridView2.Columns[1].HeaderText = "L.P";
                dataGridView2.Columns[2].HeaderText = "Login";
                dataGridView2.Columns[4].HeaderText = "Email";
                dataGridView2.Columns[5].HeaderText = "Imię";
                dataGridView2.Columns[6].HeaderText = "Nazwisko";
                dataGridView2.Columns[7].HeaderText = "Miasto";
                dataGridView2.Columns[8].HeaderText = "Kod pocztowy";
                dataGridView2.Columns[9].HeaderText = "Ulica";
                dataGridView2.Columns[10].HeaderText = "Numer domu";
                dataGridView2.Columns[11].HeaderText = "Numer bloku";
                dataGridView2.Columns[12].HeaderText = "Numer mieszkania";
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[3].Visible = false;
            }
            else if (dataGridView3.Visible == true)
            {
                dataGridView2.DataSource = null;
                dataGridView2.Rows.Clear();

                dataGridView2.DataSource = WebService.UsersPK();
                dataGridView2.Columns[1].HeaderText = "L.P";
                dataGridView2.Columns[2].HeaderText = "Login";
                dataGridView2.Columns[4].HeaderText = "Email";
                dataGridView2.Columns[5].HeaderText = "Imię";
                dataGridView2.Columns[6].HeaderText = "Nazwisko";
                dataGridView2.Columns[7].HeaderText = "Miasto";
                dataGridView2.Columns[8].HeaderText = "Kod pocztowy";
                dataGridView2.Columns[9].HeaderText = "Ulica";
                dataGridView2.Columns[10].HeaderText = "Numer domu";
                dataGridView2.Columns[11].HeaderText = "Numer bloku";
                dataGridView2.Columns[12].HeaderText = "Numer mieszkania";
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[3].Visible = false;
            }
            else
            {
                dataGridView2.Visible = true;
                dataGridView2.DataSource = WebService.UsersPK();
                dataGridView2.Columns[1].HeaderText = "L.P";
                dataGridView2.Columns[2].HeaderText = "Login";
                dataGridView2.Columns[4].HeaderText = "Email";
                dataGridView2.Columns[5].HeaderText = "Imię";
                dataGridView2.Columns[6].HeaderText = "Nazwisko";
                dataGridView2.Columns[7].HeaderText = "Miasto";
                dataGridView2.Columns[8].HeaderText = "Kod pocztowy";
                dataGridView2.Columns[9].HeaderText = "Ulica";
                dataGridView2.Columns[10].HeaderText = "Numer domu";
                dataGridView2.Columns[11].HeaderText = "Numer bloku";
                dataGridView2.Columns[12].HeaderText = "Numer mieszkania";
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[3].Visible = false;
            }
        }

        private void dodajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panel7.Visible == true)
            {
                panel7.Visible = false;
                panel6.Visible = true;
            }
            else
                panel6.Visible = true;
        }

        private void gryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Visible == true)
            {
                panel6.Visible = false;
                panel7.Visible = false;

                dataGridView2.Visible = false;
                dataGridView2.DataSource = null;
                dataGridView2.Rows.Clear();

                dataGridView3.Visible = true;
                dataGridView3.DataSource = WebService.GamesPK();
                dataGridView3.Columns[1].Width = 50;
                dataGridView3.Columns[2].Width = 170;
                dataGridView3.Columns[3].Width = 625;
                dataGridView3.Columns[4].Width = 50;
                dataGridView3.Columns[1].HeaderText = "L.P";
                dataGridView3.Columns[2].HeaderText = "Nazwa gry";
                dataGridView3.Columns[3].HeaderText = "Opis";
                dataGridView3.Columns[4].HeaderText = "Cena";
                dataGridView3.Columns[0].Visible = false;
            }
            else if (dataGridView3.Visible == true)
            {
                dataGridView3.DataSource = null;
                dataGridView3.Rows.Clear();

                dataGridView3.DataSource = WebService.GamesPK();
                dataGridView3.Columns[1].Width = 50;
                dataGridView3.Columns[2].Width = 170;
                dataGridView3.Columns[3].Width = 625;
                dataGridView3.Columns[4].Width = 50;
                dataGridView3.Columns[1].HeaderText = "L.P";
                dataGridView3.Columns[2].HeaderText = "Nazwa gry";
                dataGridView3.Columns[3].HeaderText = "Opis";
                dataGridView3.Columns[4].HeaderText = "Cena";
                dataGridView3.Columns[0].Visible = false;
            }
            else
            {
                dataGridView3.Visible = true;
                dataGridView3.DataSource = WebService.GamesPK();
                dataGridView3.Columns[1].Width = 50;
                dataGridView3.Columns[2].Width = 170;
                dataGridView3.Columns[3].Width = 625;
                dataGridView3.Columns[4].Width = 50;
                dataGridView3.Columns[1].HeaderText = "L.P";
                dataGridView3.Columns[2].HeaderText = "Nazwa gry";
                dataGridView3.Columns[3].HeaderText = "Opis";
                dataGridView3.Columns[4].HeaderText = "Cena";
                dataGridView3.Columns[0].Visible = false;
            }
                
        }

        private void gryToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Visible == true)
            {
                panel6.Visible = false;
                panel7.Visible = false;

                dataGridView2.Visible = false;
                dataGridView2.DataSource = null;
                dataGridView2.Rows.Clear();

                dataGridView3.Visible = true;
                dataGridView3.DataSource = WebService.GamesMZ();
                dataGridView3.Columns[1].Width = 50;
                dataGridView3.Columns[2].Width = 170;
                dataGridView3.Columns[3].Width = 625;
                dataGridView3.Columns[4].Width = 50;
                dataGridView3.Columns[1].HeaderText = "L.P";
                dataGridView3.Columns[2].HeaderText = "Nazwa gry";
                dataGridView3.Columns[3].HeaderText = "Opis";
                dataGridView3.Columns[4].HeaderText = "Cena";
                dataGridView3.Columns[0].Visible = false;
            }
            else if (dataGridView3.Visible == true)
            {
                dataGridView3.DataSource = null;
                dataGridView3.Rows.Clear();

                dataGridView3.DataSource = WebService.GamesMZ();
                dataGridView3.Columns[1].Width = 50;
                dataGridView3.Columns[2].Width = 170;
                dataGridView3.Columns[3].Width = 625;
                dataGridView3.Columns[4].Width = 50;
                dataGridView3.Columns[1].HeaderText = "L.P";
                dataGridView3.Columns[2].HeaderText = "Nazwa gry";
                dataGridView3.Columns[3].HeaderText = "Opis";
                dataGridView3.Columns[4].HeaderText = "Cena";
                dataGridView3.Columns[0].Visible = false;
            }
            else
            {
                dataGridView3.Visible = true;
                dataGridView3.DataSource = WebService.GamesMZ();
                dataGridView3.Columns[1].Width = 50;
                dataGridView3.Columns[2].Width = 170;
                dataGridView3.Columns[3].Width = 625;
                dataGridView3.Columns[4].Width = 50;
                dataGridView3.Columns[1].HeaderText = "L.P";
                dataGridView3.Columns[2].HeaderText = "Nazwa gry";
                dataGridView3.Columns[3].HeaderText = "Opis";
                dataGridView3.Columns[4].HeaderText = "Cena";
                dataGridView3.Columns[0].Visible = false;
            }
        }

        private void użytkownicyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dataGridView3.Visible == true)
            {
                panel8.Visible = false;
                panel9.Visible = false;

                dataGridView3.Visible = false;
                dataGridView3.DataSource = null;
                dataGridView3.Rows.Clear();

                dataGridView2.Visible = true;
                dataGridView2.DataSource = WebService.UsersMZ();
                dataGridView2.Columns[1].HeaderText = "L.P";
                dataGridView2.Columns[2].HeaderText = "Login";
                dataGridView2.Columns[4].HeaderText = "Email";
                dataGridView2.Columns[5].HeaderText = "Imię";
                dataGridView2.Columns[6].HeaderText = "Nazwisko";
                dataGridView2.Columns[7].HeaderText = "Miasto";
                dataGridView2.Columns[8].HeaderText = "Kod pocztowy";
                dataGridView2.Columns[9].HeaderText = "Ulica";
                dataGridView2.Columns[10].HeaderText = "Numer domu";
                dataGridView2.Columns[11].HeaderText = "Numer bloku";
                dataGridView2.Columns[12].HeaderText = "Numer mieszkania";
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[3].Visible = false;
            }
            else if (dataGridView2.Visible == true)
            {
                dataGridView2.DataSource = null;
                dataGridView2.Rows.Clear();

                dataGridView2.DataSource = WebService.UsersMZ();
                dataGridView2.Columns[1].HeaderText = "L.P";
                dataGridView2.Columns[2].HeaderText = "Login";
                dataGridView2.Columns[4].HeaderText = "Email";
                dataGridView2.Columns[5].HeaderText = "Imię";
                dataGridView2.Columns[6].HeaderText = "Nazwisko";
                dataGridView2.Columns[7].HeaderText = "Miasto";
                dataGridView2.Columns[8].HeaderText = "Kod pocztowy";
                dataGridView2.Columns[9].HeaderText = "Ulica";
                dataGridView2.Columns[10].HeaderText = "Numer domu";
                dataGridView2.Columns[11].HeaderText = "Numer bloku";
                dataGridView2.Columns[12].HeaderText = "Numer mieszkania";
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[3].Visible = false;
            }
            else
            {
                dataGridView2.Visible = true;
                dataGridView2.DataSource = WebService.UsersMZ();
                dataGridView2.Columns[1].HeaderText = "L.P";
                dataGridView2.Columns[2].HeaderText = "Login";
                dataGridView2.Columns[4].HeaderText = "Email";
                dataGridView2.Columns[5].HeaderText = "Imię";
                dataGridView2.Columns[6].HeaderText = "Nazwisko";
                dataGridView2.Columns[7].HeaderText = "Miasto";
                dataGridView2.Columns[8].HeaderText = "Kod pocztowy";
                dataGridView2.Columns[9].HeaderText = "Ulica";
                dataGridView2.Columns[10].HeaderText = "Numer domu";
                dataGridView2.Columns[11].HeaderText = "Numer bloku";
                dataGridView2.Columns[12].HeaderText = "Numer mieszkania";
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[3].Visible = false;
            }
        }

        private void usuńAdministratoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panel6.Visible == true)
            {
                panel6.Visible = false;
                panel7.Visible = true;
            }
            else
                panel7.Visible = true;


            UsersID.Items.Clear();

            for (int i = 0; i <= (dataGridView2.Rows.Count - 1); i++)
            {
                UsersID.Items.Add(dataGridView2.Rows[i].Cells["id"].Value);
            }
        }

        private void podkarpacieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            place = "";
            place = "Podkarpackie";
        }

        private void mazowieckieToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            place = "";
            place = "Mazowieckie";
        }

        private void dodajAdministratoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panel7.Visible == true)
            {
                panel7.Visible = false;
                panel6.Visible = true;
            }
            else
                panel6.Visible = true;
        }

        private void usuńUżytkownikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panel6.Visible == true)
            {
                panel6.Visible = false;
                panel7.Visible = true;
            }
            else
                panel7.Visible = true;

            UsersID.Items.Clear();

            for (int i = 0; i <= (dataGridView2.Rows.Count - 1); i++)
            {
                UsersID.Items.Add(dataGridView2.Rows[i].Cells["id"].Value);
            }
        }

        private void dodajGręToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panel9.Visible == true)
            {
                panel9.Visible = false;
                panel8.Visible = true;
            }
            else
                panel8.Visible = true;
        }

        private void dodajGręToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (panel9.Visible == true)
            {
                panel9.Visible = false;
                panel8.Visible = true;
            }
            else
                panel8.Visible = true;
        }

        private void usuńGręToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panel8.Visible == true)
            {
                panel8.Visible = false;
                panel9.Visible = true;
            }
            else
                panel9.Visible = true;

            GamesID.Items.Clear();

            for (int i = 0; i <= (dataGridView3.Rows.Count - 1); i++)
            {
                GamesID.Items.Add(dataGridView3.Rows[i].Cells["id"].Value);
            }
        }

        private void usuńGręToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (panel8.Visible == true)
            {
                panel8.Visible = false;
                panel9.Visible = true;
            }
            else
                panel9.Visible = true;

            GamesID.Items.Clear();

            for (int i = 0; i <= (dataGridView3.Rows.Count - 1); i++)
            {
                GamesID.Items.Add(dataGridView3.Rows[i].Cells["id"].Value);
            }
        }
    }
}
