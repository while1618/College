using Projekat.moje_klase;
using System;
using System.Collections.Generic;
using System.Data;

namespace Projekat
{
    class Student
    {
        private MojDataSet mojDataSet;
        private DataTable studentTabela;
        private string indexStudenta;
        private string korisnickoIme;
        private string imeStudenta;
        private string prezimeStudenta;
        private string jmbg;
        private string datumRodjenja;
        private string telefon;
        private Smer smer;

        public Student()
        {
            this.indexStudenta = "";
            this.korisnickoIme = "";
            this.imeStudenta = "";
            this.prezimeStudenta = "";
            this.jmbg = "";
            this.datumRodjenja = "";
            this.telefon = "";
            this.smer = new Smer();
        }

        public Student(string indexStudenta, string korisnickoIme, string imeStudenta, string prezimeStudenta, string jmbg, string datumRodjenja, string telefon, Smer smer)
        {
            mojDataSet = MojDataSet.mojDataSetSingleton();
            studentTabela = mojDataSet.vratiTabeluStudent();
            this.indexStudenta = indexStudenta;
            this.korisnickoIme = korisnickoIme;
            this.imeStudenta = imeStudenta;
            this.prezimeStudenta = prezimeStudenta;
            this.jmbg = jmbg;
            this.datumRodjenja = datumRodjenja;
            this.telefon = telefon;
            this.smer = smer;
        }

        public static int vratiBrojStudenata() 
        {
            MojDataSet mojDataSet = MojDataSet.mojDataSetSingleton();
            DataTable studentTabela = mojDataSet.vratiTabeluStudent();
            int brojStudenata = 0;
            foreach (DataRow dataRow in studentTabela.Rows)
            {
                if (Convert.ToInt32(dataRow["aktivan"]) == 1)
                {
                    brojStudenata++;
                }
            }
            return brojStudenata;
        }

        public void dodajNovogStudenta()
        {
            DataRow dataRow = studentTabela.NewRow();
            popuniPodatkeStudenta(dataRow);
            studentTabela.Rows.Add(dataRow);
        }

        public void azurirajStudenta(Student stariStudent)
        {
            foreach(DataRow dataRow in studentTabela.Rows)
            {
                if(dataRow["indeks"].Equals(stariStudent.getIndex()))
                {
                    popuniPodatkeStudenta(dataRow);
                }
            }
        }

        private void popuniPodatkeStudenta(DataRow dataRow) 
        {
            dataRow["indeks"] = this.indexStudenta;
            dataRow["korisnickoIme"] = this.korisnickoIme;
            dataRow["ime"] = this.imeStudenta;
            dataRow["prezime"] = this.prezimeStudenta;
            dataRow["jmbg"] = this.jmbg;
            dataRow["datumRodjenja"] = this.datumRodjenja;
            dataRow["telefon"] = this.telefon;
            dataRow["smer"] = this.smer.getNazivSmera();
            dataRow["aktivan"] = 1;
        } 

        public void obrisiStudenta()
        {
            foreach (DataRow dataRow in studentTabela.Rows)
            {
                if (dataRow["indeks"].Equals(this.indexStudenta))
                {
                    dataRow["aktivan"] = 0;
                }
            }
        }

        public static List<Student> podaciIzTabeleStudent()
        {
            MojDataSet mojDataSet = MojDataSet.mojDataSetSingleton();
            DataTable studentTabela = mojDataSet.vratiTabeluStudent();
            List<Student> studenti = new List<Student>();
            foreach(DataRow dataRow in studentTabela.Rows)
            {
                if(Convert.ToInt32(dataRow["aktivan"]) == 1)
                {
                    studenti.Add(parseData(dataRow));
                }
            }
            return studenti;
        }

        private static Student parseData(DataRow dataRow)
        {
            string index = dataRow["indeks"].ToString();
            string korisnickoIme = dataRow["korisnickoIme"].ToString();
            string ime = dataRow["ime"].ToString();
            string prezime = dataRow["prezime"].ToString();
            string jmbg = dataRow["jmbg"].ToString();
            string datumRodjenja = dataRow["datumRodjenja"].ToString();
            string telefon = dataRow["telefon"].ToString();
            string nazivSmera = dataRow["smer"].ToString();
            Smer smer = new Smer(nazivSmera);

            return new Student(index, korisnickoIme, ime, prezime, jmbg, datumRodjenja, telefon, smer);
        }

        public static Student vratiStudentaZaIndex(string index)
        {
            Student student = new Student();
            MojDataSet mojDataSet = MojDataSet.mojDataSetSingleton();
            DataTable studentTabela = mojDataSet.vratiTabeluStudent();
            foreach (DataRow dataRow in studentTabela.Rows)
            {
                if (Convert.ToInt32(dataRow["aktivan"]) == 1 && dataRow["indeks"].Equals(index))
                {
                    student = parseData(dataRow);
                }
            }
            return student;
        }

        public static Student vratiStudentaZaKorisnickoIme(string korisnickoIme)
        {
            Student student = new Student();
            MojDataSet mojDataSet = MojDataSet.mojDataSetSingleton();
            DataTable studentTabela = mojDataSet.vratiTabeluStudent();
            foreach (DataRow dataRow in studentTabela.Rows)
            {
                if (Convert.ToInt32(dataRow["aktivan"]) == 1 && dataRow["korisnickoIme"].Equals(korisnickoIme))
                {
                    student = parseData(dataRow);
                }
            }
            return student;
        }

        public bool daLiIndexVecPostoji()
        {
            foreach(DataRow dataRow in studentTabela.Rows)
            {
                if(dataRow["indeks"].Equals(this.indexStudenta))
                {
                    return true;
                }
            }
            return false;
        }

        public string getIndex()
        {
            return this.indexStudenta;
        }
        public string getIme()
        {
            return this.imeStudenta;
        }
        public string getPrezime()
        {
            return this.prezimeStudenta;
        }
        public string getJmbg()
        {
            return this.jmbg;
        }
        public string getDatumRodjenja()
        {
            return this.datumRodjenja;
        }
        public string getTelefon()
        {
            return this.telefon;
        }

        public string getKorisnickoIme()
        {
            return this.korisnickoIme;
        }
        public Smer getSmer()
        {
            return this.smer;
        }
    }
}
