using Projekat.moje_klase;
using System;
using System.Collections.Generic;
using System.Data;

namespace Projekat
{
    class Smer
    {
        private MojDataSet mojDataSet;
        private DataTable smerTabela;
        private DataTable studentTabela;
        private string nazivSmera;

        public Smer()
        {
            this.nazivSmera = "";
        }

        public Smer(string nazivSmera)
        {
            this.nazivSmera = nazivSmera;
            mojDataSet = MojDataSet.mojDataSetSingleton();
            smerTabela = mojDataSet.vratiTabeluSmer();
            studentTabela = mojDataSet.vratiTabeluStudent();
        }

        public void dodajNoviSmer()
        {
            DataRow dataRow = smerTabela.NewRow();
            dataRow["naziv"] = this.nazivSmera;
            dataRow["aktivan"] = 1;
            smerTabela.Rows.Add(dataRow);
        }

        public void azurirajSmer(Smer stariSmer)
        {
            foreach(DataRow dataRow in smerTabela.Rows)
            {
                if(dataRow["naziv"].Equals(stariSmer.getNazivSmera()))
                {
                    dataRow["naziv"] = this.nazivSmera;
                }
            }
        }

        public void obrisiSmer()
        {
            foreach (DataRow dataRow in smerTabela.Rows)
            {
                if (dataRow["naziv"].Equals(this.nazivSmera))
                {
                    dataRow["aktivan"] = 0;
                }
            }
        }

        public bool daLiNekoPohadjaSmer()
        {
            foreach(DataRow dataRow in studentTabela.Rows)
            {
                if(dataRow["smer"].Equals(this.nazivSmera) && Convert.ToInt32(dataRow["aktivan"]) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public static List<Smer> podaciIzTabeleSmer()
        {
            MojDataSet mojDataSet = MojDataSet.mojDataSetSingleton();
            DataTable smerTabela = mojDataSet.vratiTabeluSmer();
            List<Smer> smerovi = new List<Smer>();
            foreach(DataRow dataRow in smerTabela.Rows)
            {
                if(Convert.ToInt32(dataRow["aktivan"]) == 1)
                {
                    String nazivSmera = dataRow["naziv"].ToString();
                    smerovi.Add(new Smer(nazivSmera));
                }
            }
            return smerovi;
        }

        public bool daLiNazivSmeraVecPostoji()
        {
            foreach(DataRow dataRow in smerTabela.Rows)
            {
                if(dataRow["naziv"].Equals(this.nazivSmera))
                {
                    return true;
                }
            }
            return false;
        }

        public string getNazivSmera()
        {
            return this.nazivSmera;
        }
    }
}
