using System;
using System.Data.SQLite;
using System.Data;

namespace Projekat.moje_klase
{
    class MojDataSet
    {
        private static MojDataSet instance;
        private DataSet dataSet;
        private DataBase database;
        private SQLiteDataAdapter[] nizAdaptera;
        private String[] nizTabela;

        public static MojDataSet mojDataSetSingleton()
        {
            if (instance == null)
                instance = new MojDataSet();
            return instance;
        }

        private MojDataSet()
        {
            database = DataBase.DataBaseSingleton();
            dataSet = new DataSet();
            nizAdaptera = new SQLiteDataAdapter[6];
            nizTabela = new String[6];
            popuniDataSet();
        }

        private void popuniDataSet()
        {
            database.upaliKonekciju();
            popuniNizAdaptera();
            popuniNiztabela();            
            for (int i = 0; i < nizAdaptera.Length; i++) 
            {
                popuniTabeleDataSeta(nizAdaptera[i], nizTabela[i]);
            }
            database.ugasiKonekciju();
        }

        private void popuniNizAdaptera()
        {
            nizAdaptera[0] = izvrisSelect("SELECT * FROM Smer");
            nizAdaptera[1] = izvrisSelect("SELECT * FROM Student");
            nizAdaptera[2] = izvrisSelect("SELECT * FROM PredmetSmer");
            nizAdaptera[3] = izvrisSelect("SELECT * FROM Predmet");
            nizAdaptera[4] = izvrisSelect("SELECT * FROM Korisnik");
            nizAdaptera[5] = izvrisSelect("SELECT * FROM IzbornaLista");
        }

        private void popuniNiztabela()
        {
            nizTabela[0] = "Smer";
            nizTabela[1] = "Student";
            nizTabela[2] = "PredmetSmer";
            nizTabela[3] = "Predmet";
            nizTabela[4] = "Korisnik";
            nizTabela[5] = "IzbornaLista";
        }

        private SQLiteDataAdapter izvrisSelect(String sql)
        {
            return database.selectZaDataSet(sql);
        }

        private void popuniTabeleDataSeta(SQLiteDataAdapter adapter, String tabela)
        {
            adapter.Fill(dataSet, tabela);
        }

        public DataSet vratiDataSet()
        {
            return dataSet;
        }

        public DataTable vratiTabeluKorisnik()
        {
            return dataSet.Tables["Korisnik"];
        }

        public DataTable vratiTabeluPredmet()
        {
            return dataSet.Tables["Predmet"];
        }

        public DataTable vratiTabeluIzbornaLista()
        {
            return dataSet.Tables["IzbornaLista"];
        }

        public DataTable vratiTabeluPredmetSmer()
        {
            return dataSet.Tables["PredmetSmer"];
        }

        public DataTable vratiTabeluSmer()
        {
            return dataSet.Tables["Smer"];
        }

        public DataTable vratiTabeluStudent()
        {
            return dataSet.Tables["Student"];
        }

        public String[] vratiImenaTabela()
        {
            return nizTabela;
        }

        public SQLiteDataAdapter[] vratiAdaptere()
        {
            return nizAdaptera;
        }
    }
}
