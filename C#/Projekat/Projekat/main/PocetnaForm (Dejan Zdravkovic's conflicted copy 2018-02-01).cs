using Projekat.moje_klase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Projekat
{
    public partial class PocetnaForm : Form
    {
        private AdministracijaForm frm2;
        private StudentForm frm3;
        private MojDataSet mojDataSet;
        private DataSet dataSet;
        private delegate String posalji(String korisnickoIme);
        private posalji delegat;

        public TextBox getUserNameTextBox()
        {
            return textBox1;
        }

        public static String posaljiKorisnika(String korisnickoIme) {
            return korisnickoIme;
        }

        public TextBox getPasswordTextBox()
        {
            return textBox2;
        }

        public PocetnaForm()
        {
            InitializeComponent();
            delegat = posaljiKorisnika;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            mojDataSet = MojDataSet.mojDataSetSingleton();
            dataSet = mojDataSet.vratiDataSet();
        }

        private Korisnik ulogujKorisnika()
        {
            List<Korisnik> listaKorisnikaIzBaze = Korisnik.uzmiKorisnikeIzBaze();
            String korisnickoIme = textBox1.Text;
            String sifra = textBox2.Text;
            foreach(Korisnik korisnik in listaKorisnikaIzBaze)
            {
                if(korisnickoIme.Equals(korisnik.getKorisnickoIme()) && sifra.Equals(korisnik.getSifra()))
                {
                    return korisnik;
                }
            }
            return new Korisnik();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Korisnik korisnik = ulogujKorisnika();
            if(korisnik.getDefaultKorisnik() == 1)
            {
                MessageBox.Show("Pogresna sifra ili korisnicko ime");
            }
            else
            {
                adminIliKorisnik(korisnik);
            }
        }

        private void adminIliKorisnik(Korisnik korisnik)
        {
            if (korisnik.getAdmin() == 1)
            {
                frm2 = new AdministracijaForm(this);
                frm2.Show();
                this.Hide();
            }
            else if (korisnik.getAdmin() == 0)
            {
                frm3 = new StudentForm(delegat(korisnik.getKorisnickoIme()), this);
                frm3.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nepoznata greska");
            }
        }

        private void PocetnaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SQLiteDataAdapter[] adapteri = mojDataSet.vratiAdaptere();
            String[] imenaTabela = mojDataSet.vratiImenaTabela();
            for(int i = 0; i < adapteri.Length; i++)
            {
                SQLiteCommandBuilder builder = new SQLiteCommandBuilder(adapteri[i]);
                adapteri[i].UpdateCommand = builder.GetUpdateCommand(true);
                adapteri[i].InsertCommand = builder.GetInsertCommand(true); 
                adapteri[i].Update(dataSet, imenaTabela[i]);
            }
        }
    }
}
