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
        private MojDataSet mojDataSet;
        private DataSet dataSet;
        private delegate String Delegate(String korisnik);
        private Delegate handler;

        public static String posaljiKorisnika(String korisnik) 
        {
            return korisnik;
        }

        public PocetnaForm()
        {
            InitializeComponent();
            mojDataSet = MojDataSet.mojDataSetSingleton();
            dataSet = mojDataSet.vratiDataSet();
            handler = posaljiKorisnika;
        }

        private void PocetnaForm_Load(object sender, EventArgs e)
        {
            postaviZvezdicuZaIspisSifre();
        }

        private void postaviZvezdicuZaIspisSifre()
        {
            textBox2.PasswordChar = '*';
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

        private Korisnik ulogujKorisnika()
        {
            List<Korisnik> listaKorisnikaIzBaze = Korisnik.uzmiKorisnikeIzBaze();
            String korisnickoIme = textBox1.Text;
            String sifra = textBox2.Text;
            foreach (Korisnik korisnik in listaKorisnikaIzBaze)
            {
                if (korisnickoIme.Equals(korisnik.getKorisnickoIme()) && sifra.Equals(korisnik.getSifra()))
                {
                    return korisnik;
                }
            }
            return new Korisnik();
        }

        private void adminIliKorisnik(Korisnik korisnik)
        {
            if (korisnik.getAdmin() == 1)
            {
                GlavnaAdminForma adminForma = new GlavnaAdminForma(this);
                adminForma.Show();
                this.Hide();
            }
            else if (korisnik.getAdmin() == 0)
            {
                String korisnickoIme = korisnik.getKorisnickoIme();
                KorisnikForm korisnikForma = new KorisnikForm(handler(korisnickoIme), this);
                korisnikForma.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nepoznata greska");
            }
        }

        private void PocetnaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            upisiPodatkeIzDataSetaUBazu();
        }

        private void upisiPodatkeIzDataSetaUBazu() 
        {
            SQLiteDataAdapter[] adapteri = mojDataSet.vratiAdaptere();
            String[] imenaTabela = mojDataSet.vratiImenaTabela();
            for (int i = 0; i < adapteri.Length; i++)
            {
                SQLiteCommandBuilder builder = new SQLiteCommandBuilder(adapteri[i]);
                adapteri[i].UpdateCommand = builder.GetUpdateCommand(true);
                adapteri[i].InsertCommand = builder.GetInsertCommand(true);
                adapteri[i].Update(dataSet, imenaTabela[i]);
            }
        }

        public void obrisiTextBoxove() 
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
