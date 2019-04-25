using Projekat.moje_klase;
using System;
using System.Collections.Generic;
using System.Data;

namespace Projekat
{
    class PredmetSmer
    {
        private MojDataSet mojDataSet;
        private DataTable predmetSmerTabela;
        private Predmet predmet;
        private List<Smer> listaSmerova;

        public PredmetSmer()
        {
            this.predmet = new Predmet();
            this.listaSmerova = new List<Smer>();
        }

        public PredmetSmer(Predmet predmet)
        {
            mojDataSet = MojDataSet.mojDataSetSingleton();
            predmetSmerTabela = mojDataSet.vratiTabeluPredmetSmer();
            this.predmet = predmet;
            this.listaSmerova = new List<Smer>();
        }

        public void dodajSmer(Smer smer)
        {
            this.listaSmerova.Add(smer);
        }

        public void dodajSmeroveZaPredmet()
        {
            foreach(Smer smer in listaSmerova)
            {
                dodajSmerUTabelu(smer);
            }
        }

        private void dodajSmerUTabelu(Smer smer)
        {
            DataRow dataRow = predmetSmerTabela.NewRow();
            dataRow["smer"] = smer.getNazivSmera();
            dataRow["predmet"] = predmet.getNaziv();
            dataRow["aktivan"] = 1;
            predmetSmerTabela.Rows.Add(dataRow);

        }

        private void obrisiSveSmeroveZaStariPredmet(Predmet stariPredmet)
        {
            foreach(DataRow dataRow in predmetSmerTabela.Rows)
            {
                if(dataRow["predmet"].Equals(stariPredmet.getNaziv()))
                {
                    dataRow["aktivan"] = 0;
                }
            }
        }

        public void azurirajSmeroveZaPredmet(Predmet stariPredmet)
        {
            obrisiSveSmeroveZaStariPredmet(stariPredmet);
            foreach (Smer smer in listaSmerova)
            {
                dodajSmerUTabelu(smer);             
            }
        }

        public void obrisiSveSmeroveZaPredmet()
        {
            foreach (DataRow dataRow in predmetSmerTabela.Rows)
            {
                if (dataRow["predmet"].Equals(predmet.getNaziv()))
                {
                    dataRow["aktivan"] = 0;
                }
            }
        }

        public void obrisiIzabraneSmeroveZaPredmet()
        {
            foreach(Smer smer in listaSmerova)
            {
                foreach (DataRow dataRow in predmetSmerTabela.Rows)
                {
                    if (dataRow["predmet"].Equals(predmet.getNaziv()) && dataRow["smer"].Equals(smer.getNazivSmera()))
                    {
                        dataRow["aktivan"] = 0;
                    }
                }
            }
        }

        public override String ToString()
        {
            String smerovi = "";
            foreach (Smer smer in listaSmerova)
            {
                smerovi += smer.getNazivSmera() + " ";
            }
            return smerovi;
        }
    }
}
