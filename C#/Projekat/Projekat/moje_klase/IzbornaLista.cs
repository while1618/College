using Projekat.moje_klase;
using System;
using System.Collections.Generic;
using System.Data;

namespace Projekat
{
    class IzbornaLista
    {
        private MojDataSet mojDataSet;
        private DataTable izbornaListaTabela;
        private Student student;
        private List<Predmet> listaPredmeta;

        public IzbornaLista()
        {
            this.student = new Student();
            this.listaPredmeta = new List<Predmet>();
        }

        public IzbornaLista(Student student, List<Predmet> listaPredmeta)
        {
            mojDataSet = MojDataSet.mojDataSetSingleton();
            izbornaListaTabela = mojDataSet.vratiTabeluIzbornaLista();
            this.student = student;
            this.listaPredmeta = listaPredmeta;
        }

        public static int vratiBrojStudenataNaPredmetu(Predmet predmet) 
        {
            MojDataSet mojDataSet = MojDataSet.mojDataSetSingleton();
            DataTable izbornaListaTabela = mojDataSet.vratiTabeluIzbornaLista();
            int brojStudenataNaPredmetu = 0;
            foreach(DataRow dataRow in izbornaListaTabela.Rows)
            {
                if(dataRow["predmet"].Equals(predmet.getNaziv()) && Convert.ToInt32(dataRow["aktivan"]) == 1)
                {
                    brojStudenataNaPredmetu++;
                }
            }
            return brojStudenataNaPredmetu;
        }

        public void dodajListuPredmeta()
        {
            foreach(Predmet predmet in listaPredmeta)
            {
                DataRow dataRow = izbornaListaTabela.NewRow();
                dataRow["student"] = student.getIndex();
                dataRow["predmet"] = predmet.getNaziv();
                dataRow["aktivan"] = 1;
                izbornaListaTabela.Rows.Add(dataRow);
            }            
        }

        public static void obrisiStudentovuListu(Student student)
        {
            MojDataSet mojDataSet = MojDataSet.mojDataSetSingleton();
            DataTable izbornaListaTabela = mojDataSet.vratiTabeluIzbornaLista();
            foreach(DataRow dataRow in izbornaListaTabela.Rows)
            {
                if (dataRow["student"].Equals(student.getIndex()))
                {
                    dataRow["aktivan"] = 0;
                }
            }
        }

        public static bool daLiStudentPohadjaPredmet(Predmet predmet, Student student)
        {
            MojDataSet mojDataSet = MojDataSet.mojDataSetSingleton();
            DataTable izbornaListaTabela = mojDataSet.vratiTabeluIzbornaLista();
            foreach(DataRow dataRow in izbornaListaTabela.Rows)
            {
                if(dataRow["predmet"].Equals(predmet.getNaziv()) && dataRow["student"].Equals(student.getIndex()) && Convert.ToInt32(dataRow["aktivan"]) == 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
