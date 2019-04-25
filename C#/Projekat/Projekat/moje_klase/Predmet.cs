using Projekat.moje_klase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Projekat
{
    class Predmet
    {
        private MojDataSet mojDataSet;
        private DataTable predmetTabela;
        private DataTable predmetSmerTabela;
        private DataTable izbornaListaTabela;

        private int sifraPredmeta;
        private string nazivPredmeta;
        private string profesor;
        private int brojEspb;
        private int obavezan;
        private int semestar;

        public Predmet()
        {
            this.sifraPredmeta = 0;
            this.nazivPredmeta = "";
            this.profesor = "";
            this.brojEspb = 0;
            this.obavezan = 0;
            this.semestar = 0;
        }

        public Predmet(int sifraPredmeta, string nazivPredmeta, string profesor, int brojEspb, int obavezan, int semestar)
        {
            mojDataSet = MojDataSet.mojDataSetSingleton();
            predmetTabela = mojDataSet.vratiTabeluPredmet();
            predmetSmerTabela = mojDataSet.vratiTabeluPredmetSmer();
            izbornaListaTabela = mojDataSet.vratiTabeluIzbornaLista();
            this.sifraPredmeta = sifraPredmeta;
            this.nazivPredmeta = nazivPredmeta;
            this.profesor = profesor;
            this.brojEspb = brojEspb;
            this.obavezan = obavezan;
            this.semestar = semestar;
        }

        public void dodajNovPredmet()
        {
            DataRow dataRow = predmetTabela.NewRow();
            popuniPodatkePredmeta(dataRow);
            predmetTabela.Rows.Add(dataRow);
        }

        public void azurirajPredmet(Predmet stariPredmet)
        {
            foreach (DataRow dataRow in predmetTabela.Rows)
            {
                if (Convert.ToInt32(dataRow["sifra"]) == Convert.ToInt32(stariPredmet.getSifra()))
                {
                    popuniPodatkePredmeta(dataRow);
                }
            }
        }

        private void popuniPodatkePredmeta(DataRow dataRow) 
        {
            dataRow["sifra"] = this.sifraPredmeta;
            dataRow["naziv"] = this.nazivPredmeta;
            dataRow["profesor"] = this.profesor;
            dataRow["espb"] = this.brojEspb;
            dataRow["obavezan"] = this.obavezan;
            dataRow["semestar"] = this.semestar;
            dataRow["aktivan"] = 1;
        }

        public void obrisiPredmet()
        {
            foreach (DataRow dataRow in predmetTabela.Rows)
            {
                if (Convert.ToInt32(dataRow["sifra"]) == this.sifraPredmeta)
                {
                    dataRow["aktivan"] = 0;
                }
            }
        }

        public bool daLiSePredmetNalaziNaSmeru(Smer smer)
        {
            foreach (DataRow dataRow in predmetSmerTabela.Rows)
            {
                if (dataRow["predmet"].Equals(this.nazivPredmeta) && dataRow["smer"].Equals(smer.getNazivSmera()) && Convert.ToInt32(dataRow["aktivan"]) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public static List<Predmet> podaciIzTabelePredmet()
        {
            MojDataSet mojDataSet = MojDataSet.mojDataSetSingleton();
            DataTable predmetTabela = mojDataSet.vratiTabeluPredmet();

            List<Predmet> predmeti = new List<Predmet>();
            foreach (DataRow dataRow in predmetTabela.Rows)
            {
                if (Convert.ToInt32(dataRow["aktivan"]) == 1)
                {
                    predmeti.Add(parseData(dataRow));
                }
            }
            return predmeti;
        }

        public static List<Predmet> sortiraniPodaciIzTabelePredmet()
        {
            List<Predmet> predmeti = podaciIzTabelePredmet();
            Predmet[] nizPredmeta = predmeti.ToArray();
            return nizPredmeta.OrderBy(a => a.semestar).ThenBy(a => a.nazivPredmeta).ToList();
        }

        private static Predmet parseData(DataRow dataRow)
        {
            int sifra = Convert.ToInt32(dataRow["sifra"]);
            string naziv = dataRow["naziv"].ToString();
            string profesor = dataRow["profesor"].ToString();
            int espb = Convert.ToInt32(dataRow["espb"]);
            int obavezan = Convert.ToInt32(dataRow["obavezan"]);
            int semestar = Convert.ToInt32(dataRow["semestar"]);

            return new Predmet(sifra, naziv, profesor, espb, obavezan, semestar);
        }

        public static Predmet vratiPredmetZaNaziv(string naziv)
        {
            MojDataSet mojDataSet = MojDataSet.mojDataSetSingleton();
            DataTable predmetTabela = mojDataSet.vratiTabeluPredmet();
            Predmet predmet = new Predmet();
            foreach (DataRow dataRow in predmetTabela.Rows)
            {
                if (Convert.ToInt32(dataRow["aktivan"]) == 1 && dataRow["naziv"].Equals(naziv))
                {
                    predmet = parseData(dataRow);
                }
            }
            return predmet;
        }

        public bool daLiPostojiSifraPredmeta()
        {
            foreach (DataRow dataRow in predmetTabela.Rows)
            {
                if (Convert.ToInt32(dataRow["sifra"]) == this.sifraPredmeta)
                {
                    return true;
                }
            }
            return false;
        }

        public bool daLiPostojiNazivPredmeta()
        {
            foreach (DataRow dataRow in predmetTabela.Rows)
            {
                if (dataRow["naziv"].Equals(this.nazivPredmeta))
                {
                    return true;
                }
            }
            return false;
        }

        public bool daLiNekoPohadjaPredmet()
        {
            foreach (DataRow dataRow in izbornaListaTabela.Rows)
            {
                if (dataRow["predmet"].Equals(this.nazivPredmeta) && Convert.ToInt32(dataRow["aktivan"]) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public bool daLiStudentPohadjaPredmet(Student student)
        {
            foreach (DataRow dataRow in izbornaListaTabela.Rows)
            {
                if (dataRow["predmet"].Equals(this.nazivPredmeta) && dataRow["student"].Equals(student.getIndex()) && Convert.ToInt32(dataRow["aktivan"]) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public string getNaziv()
        {
            return this.nazivPredmeta;
        }
        public int getSifra()
        {
            return this.sifraPredmeta;
        }

        public int getObavezan()
        {
            return this.obavezan;
        }

        public int getSemestar()
        {
            return this.semestar;
        }

        public int getEspbBodove()
        {
            return this.brojEspb;
        }
    }
}
