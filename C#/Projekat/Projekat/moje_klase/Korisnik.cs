using Projekat.moje_klase;
using System;
using System.Collections.Generic;
using System.Data;

namespace Projekat
{
    class Korisnik
    {
        private MojDataSet mojDataSet;
        private DataTable korisnikTabela;

        private String korisnickoIme;
        private String sifra;
        private int aktivan;
        private int admin;
        private int defaultKorisnik;

        public Korisnik()
        {
            this.korisnickoIme = "";
            this.sifra = "";
            this.aktivan = 0;
            this.admin = 0;
            this.defaultKorisnik = 1;
        }

        public Korisnik(String korisnickoIme, String sifra, int aktivan, int admin)
        {
            mojDataSet = MojDataSet.mojDataSetSingleton();
            korisnikTabela = mojDataSet.vratiTabeluKorisnik();
            this.korisnickoIme = korisnickoIme;
            this.sifra = sifra;
            this.aktivan = aktivan;
            this.admin = admin;
            this.defaultKorisnik = 0;
        }

        public void unesiKorisnikaUBazu()
        {
            DataRow dataRow = korisnikTabela.NewRow();
            unesiPodatkeKorisnika(dataRow);
            korisnikTabela.Rows.Add(dataRow);
        }

        public void azurirajKorisnikaUBazi(String startoKorisnickoIme)
        {
            foreach (DataRow dataRow in korisnikTabela.Rows)
            {
                if (dataRow["korisnickoIme"].Equals(startoKorisnickoIme))
                {
                    unesiPodatkeKorisnika(dataRow);
                }
            }
        }

        private void unesiPodatkeKorisnika(DataRow dataRow) 
        {
            dataRow["korisnickoIme"] = this.korisnickoIme;
            dataRow["sifra"] = this.sifra;
            dataRow["admin"] = this.admin;
            dataRow["aktivan"] = this.aktivan;
        }

        public static void obrisiKorisnika(String korisnikZaBrisanje)
        {
            MojDataSet mojDataSet = MojDataSet.mojDataSetSingleton();
            DataTable korisnikTabela = mojDataSet.vratiTabeluKorisnik();
            foreach (DataRow dataRow in korisnikTabela.Rows)
            {
                if (dataRow["korisnickoIme"].Equals(korisnikZaBrisanje))
                {
                    dataRow["aktivan"] = 0;
                }
            }
        }

        public static List<Korisnik> uzmiKorisnikeIzBaze()
        {
            MojDataSet mojDataSet = MojDataSet.mojDataSetSingleton();
            DataTable korisnikTabela = mojDataSet.vratiTabeluKorisnik();
            List<Korisnik> korisnici = new List<Korisnik>();

            foreach (DataRow dataRow in korisnikTabela.Rows)
            {
                if(Convert.ToInt32(dataRow["aktivan"]) == 1)
                {
                    korisnici.Add(parseData(dataRow));
                }
            }
            return korisnici;
        }

        private static Korisnik parseData(DataRow dataRow)
        {
            String korisnickoIme = dataRow["korisnickoIme"].ToString();
            String sifra = dataRow["sifra"].ToString();
            int aktivan = Convert.ToInt32(dataRow["aktivan"]);
            int admin = Convert.ToInt32(dataRow["admin"]);

            return new Korisnik(korisnickoIme, sifra, aktivan, admin);
        }

        public String getKorisnickoIme()
        {
            return this.korisnickoIme;
        }

        public String getSifra()
        {
            return this.sifra;
        }

        public int getAktivan()
        {
            return this.aktivan;
        }

        public int getAdmin()
        {
            return this.admin;
        }

        public int getDefaultKorisnik()
        {
            return this.defaultKorisnik;
        }
    }
}
