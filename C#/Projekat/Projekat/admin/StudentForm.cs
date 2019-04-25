using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Projekat
{

    public partial class StudentForm : Form
    {
        private String korisnickoIme;
        private const string brojTelefonaRegex = @"^[0-9+]+$";
        private GlavnaAdminForma adminFrm;

        public StudentForm(GlavnaAdminForma adminFrm)
        {
            InitializeComponent();
            this.adminFrm = adminFrm;
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            popuniComboBoxeve();
            onemoguciPisanjeUComboBoxove();
        }

        private void popuniComboBoxeve()
        {
            popuniComboBoxMesecima(comboBox6);
            popuniComboBoxGodinama(comboBox7);
            popuniComboBoxMesecima(comboBox9);
            popuniComboBoxGodinama(comboBox10);
            popuniComboBoxPodacimaIzTableleStudent(comboBox1);
            popuniComboBoxPodacimaIzTableleStudent(comboBox4);
            popuniComboBoxPodacimaIzTabeleSmer(comboBox3);
            popuniComboBoxPodacimaIzTabeleSmer(comboBox2);
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            obrisiComboBoxSaDanima(comboBox5);
            if (daLiJeIzabranFebruar(comboBox6))
            {
                popuniDaneZaFebruar(comboBox5);
            }
            else if (daLiJeIzabranMesecSa30Dana(comboBox6))
            {
                popuniDaneZaMesecSa30Dana(comboBox5);
            }
            else
            {
                popuniDaneZaMesecSa31Dan(comboBox5);
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            obrisiComboBoxSaDanima(comboBox8);
            if (daLiJeIzabranFebruar(comboBox9))
            {
                popuniDaneZaFebruar(comboBox8);
            }
            else if (daLiJeIzabranMesecSa30Dana(comboBox9))
            {
                popuniDaneZaMesecSa30Dana(comboBox8);
            }
            else
            {
                popuniDaneZaMesecSa31Dan(comboBox8);
            }
        }

        private void obrisiComboBoxSaDanima(ComboBox dani)
        {
            dani.Items.Clear();
        }

        private void popuniComboBoxGodinama(ComboBox godina)
        {
            for (int i = 1950; i < 2001; i++)
            {
                godina.Items.Add(i);
            }
            godina.SelectedIndex = 50;
        }

        private void popuniComboBoxMesecima(ComboBox mesec)
        {
            for (int i = 0; i < 12; i++)
            {
                mesec.Items.Add(i + 1);
            }
            mesec.SelectedIndex = 0;
        }

        private bool daLiJeIzabranFebruar(ComboBox mesec)
        {
            return (mesec.SelectedItem.ToString().Equals("2")) ? true : false; 
        }

        private void popuniDaneZaFebruar(ComboBox dan)
        {
            for (int i = 0; i < 28; i++)
            {
                dan.Items.Add(i + 1);
            }
            dan.SelectedIndex = 0;
        }        

        private bool daLiJeIzabranMesecSa30Dana(ComboBox mesec)
        {
            return (Int32.Parse(mesec.SelectedItem.ToString()) % 2 == 0) ? true : false;
        }

        private void popuniDaneZaMesecSa30Dana(ComboBox dan)
        {
            for (int i = 0; i < 30; i++)
            {
                dan.Items.Add(i + 1);
            }
            dan.SelectedIndex = 0;
        }

        private void popuniDaneZaMesecSa31Dan(ComboBox dan)
        {
            for (int i = 0; i < 31; i++)
            {
                dan.Items.Add(i + 1);
            }
            dan.SelectedIndex = 0;
        }

        private void popuniComboBoxPodacimaIzTableleStudent(ComboBox comboBox)
        {
            List<Student> studenti = Student.podaciIzTabeleStudent();
            foreach (Student student in studenti)
            {
                comboBox.Items.Add(student.getIndex() + ": " + student.getIme() + student.getPrezime());
            }
            comboBox.SelectedIndex = 0;
        }

        private void popuniComboBoxPodacimaIzTabeleSmer(ComboBox comboBox)
        {
            List<Smer> smerovi = Smer.podaciIzTabeleSmer();
            foreach (Smer smer in smerovi)
            {
                comboBox.Items.Add(smer.getNazivSmera());
            }
            comboBox.SelectedIndex = 0;
        }

        private void onemoguciPisanjeUComboBoxove()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox6.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox7.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox8.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox9.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox10.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void UnesiButton_Click(object sender, EventArgs e)
        {
            if (unesitNovogStudenta())
            {
                unesitPodatkeUTabeluKorisnik();
            }
        }

        private bool unesitNovogStudenta()
        {
            Student student = podaciNovogStudenta(textBoxoviZaUnosStudenta(), "unosNovogStudenta");
            if(daLiSuUnetiValidniPodaci(student))
            {
                if(!daLiUnetiIndexVecPostoji(student))
                {
                    student.dodajNovogStudenta();
                    MessageBox.Show("Uspesno ste dodali studenta");
                    unesiStudentaUComboBoxeveZaAzuriranjeIBrisanje(student);
                    return true;
                }                
            }
            return false;
        }

        private Student podaciNovogStudenta(TextBox[] nizTextboxova, String tipUnosa)
        {
            long broj = 0;
            String jmbg = "";
            String index = nizTextboxova[0].Text;
            String ime = nizTextboxova[1].Text;
            String prezime = nizTextboxova[2].Text;
            if (!proveraUnosaJmbga(nizTextboxova[3], ref broj, ref jmbg)) return new Student();
            String telefon = nizTextboxova[4].Text;
            if (!proveraUnosaTelefona(telefon)) return new Student();
            String[] nizPodataka = vracanjePodatakaNaOsnovuTipaUnosa(tipUnosa);
            this.korisnickoIme = kreirajKorisnickoIme(ime, index);
            if(proveraUnetihPodataka(index, ime, prezime, jmbg, telefon, nizPodataka))
            {
                String datumRodjenja = nizPodataka[0];
                String nazivSmera = nizPodataka[1];
                Smer smer = new Smer(nazivSmera);
                return new Student(index, this.korisnickoIme, ime, prezime, jmbg, datumRodjenja, telefon, smer);
            }
            return new Student();
        }

        private bool proveraUnosaTelefona(String telefon)
        {
            Match match = Regex.Match(telefon, brojTelefonaRegex);
            return match.Success;
        }

        private bool proveraUnosaJmbga(TextBox jedinstveniBroj, ref long broj, ref String jmbg)
        {
            if (proveraUnosaBroja(jedinstveniBroj, ref broj))
            {
                jmbg = broj.ToString();
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool proveraUnosaBroja(TextBox podatak, ref long broj)
        {
            return Int64.TryParse(podatak.Text, out broj);
        }

        private String[] vracanjePodatakaNaOsnovuTipaUnosa(String tipUnosa)
        {
            if (tipUnosa.Equals("unosNovogStudenta"))
            {
                return unetiPodaci(comboBox5, comboBox6, comboBox7, comboBox2);
            }
            else if (tipUnosa.Equals("azuriranjeStudenta"))
            {
                return unetiPodaci(comboBox8, comboBox9, comboBox10, comboBox3);
            }
            else
            {
                return new String[0];
            }
        }

        private String[] unetiPodaci(ComboBox dan, ComboBox mesec, ComboBox godina, ComboBox nazivSmera)
        {
            String[] nizPodataka = new string[2];
            nizPodataka[0] = uzmiDatumRodjenjaStudenta(dan, mesec, godina);
            nizPodataka[1] = nazivSmera.SelectedItem.ToString();
            return nizPodataka;
        }

        private String uzmiDatumRodjenjaStudenta(ComboBox dan, ComboBox mesec, ComboBox godina)
        { 
            return dan.SelectedItem.ToString() + "." + mesec.SelectedItem.ToString() + "." + godina.SelectedItem.ToString() + ".";
        }

        private bool proveraUnetihPodataka(String index, String ime, String prezime, String jmbg, String telefon, String[] nizPodataka)
        {
            return (index != "" && ime != "" && prezime != "" && jmbg != "" && telefon != "" && nizPodataka.Length == 2) ? true : false;
        }

        private TextBox[] textBoxoviZaUnosStudenta()
        {
            TextBox[] nizTextBoxova = new TextBox[6];
            nizTextBoxova[0] = textBox1;
            nizTextBoxova[1] = textBox2;
            nizTextBoxova[2] = textBox3;
            nizTextBoxova[3] = textBox4;
            nizTextBoxova[4] = textBox6;

            return nizTextBoxova;
        }

        private bool daLiSuUnetiValidniPodaci(Student student)
        {
            if (student.getIme() == "")
            {
                MessageBox.Show("Niste uneli validne podatke");
                return false;
            }
            return true;
        }

        private bool daLiUnetiIndexVecPostoji(Student student)
        {
            if (student.daLiIndexVecPostoji())
            {
                MessageBox.Show("Uneti indeks vec postoji");
                return true;
            }
            return false;
        }

        private void unesitPodatkeUTabeluKorisnik()
        {
            String sifra = kreirajSifru();
            Korisnik korisnik = new Korisnik(this.korisnickoIme, sifra, 1, 0);
            korisnik.unesiKorisnikaUBazu();
        }

        private void unesiStudentaUComboBoxeveZaAzuriranjeIBrisanje(Student student) 
        {
            unesiStudentaUComboBox(comboBox1, student);
            unesiStudentaUComboBox(comboBox4, student);
        }

        private void unesiStudentaUComboBox(ComboBox comboBox, Student student) 
        {
            comboBox.Items.Add(student.getIndex() + ": " + student.getIme() + student.getPrezime());
        }

        private void IzmeniButton_Click_1(object sender, EventArgs e)
        {
            azurirajStudenta();
        }

        private bool azurirajStudenta()
        {
            Student stariPodaciStudenta = podaciStudentaZaIzmenuIliBrisanje(comboBox1);
            Student noviPodaciStudenta = podaciNovogStudenta(textBoxoviZaAzuriranjeStudenta(), "azuriranjeStudenta");

            if(daLiSuUnetiValidniPodaci(noviPodaciStudenta))
            {
                if (!daLiJeUnetStariIndex(noviPodaciStudenta, stariPodaciStudenta))
                {
                    if (daLiUnetiIndexVecPostoji(noviPodaciStudenta))
                    {
                        return false;
                    }
                }
                noviPodaciStudenta.azurirajStudenta(stariPodaciStudenta);
                azurirajPodatkeUTabeliKorisnik(stariPodaciStudenta.getKorisnickoIme());
                MessageBox.Show("Uspesno ste azurirali studenta");
                azurirajComboBoxeveZaAzuriranjeIBrisanje(stariPodaciStudenta, noviPodaciStudenta);
                return true;
            }
            return false;                                             
        }
        private Student podaciStudentaZaIzmenuIliBrisanje(ComboBox comboBox)
        {
            String izabraniStudentZaAzuriranje = comboBox.SelectedItem.ToString();
            String[] tokens = izabraniStudentZaAzuriranje.Split(':');
            String stariIndex = tokens[0];
            return Student.vratiStudentaZaIndex(stariIndex);
        }

        private TextBox[] textBoxoviZaAzuriranjeStudenta()
        {
            TextBox[] nizTextBoxova = new TextBox[6];
            nizTextBoxova[0] = textBox12;
            nizTextBoxova[1] = textBox11;
            nizTextBoxova[2] = textBox10;
            nizTextBoxova[3] = textBox9;
            nizTextBoxova[4] = textBox7;

            return nizTextBoxova;
        }        

        private bool daLiJeUnetStariIndex(Student noviPodaciStudenta, Student stariPodaciStudenta)
        {
            return (noviPodaciStudenta.getIndex().Equals(stariPodaciStudenta.getIndex())) ? true : false;
        }
        
        private void azurirajPodatkeUTabeliKorisnik(String staroKorisnickoIme)
        {
            String sifra = kreirajSifru();
            Korisnik korisnik = new Korisnik(this.korisnickoIme, sifra, 1, 0);
            korisnik.azurirajKorisnikaUBazi(staroKorisnickoIme);
        }
                
        private String kreirajKorisnickoIme(String ime, String index)
        {
            return ime.ToLower() + index.ToLower();
        }

        private String kreirajSifru()
        {
            return "a123";  //moze da se stavi neka random sifra, al meni je bilo ovako lakse zbog logovanja
        }

        private void azurirajComboBoxeveZaAzuriranjeIBrisanje(Student stariStudent, Student noviStudent) 
        {
            obrisiStudentaIzComboBoxa(comboBox1, stariStudent);
            obrisiStudentaIzComboBoxa(comboBox4, stariStudent);
            unesiStudentaUComboBox(comboBox1, noviStudent);
            unesiStudentaUComboBox(comboBox4, noviStudent);
        }

        private void ObrisiButton_Click(object sender, EventArgs e)
        {
            obrisiStudenta();
        }

        private void obrisiStudenta()
        {
            Student studentZaBrisanje = podaciStudentaZaIzmenuIliBrisanje(comboBox4);
            studentZaBrisanje.obrisiStudenta();
            obrisiPodatkeUTabeliKorisnik(studentZaBrisanje.getKorisnickoIme());
            MessageBox.Show("Uspseno ste obrisali studenta");
            obrisiStudentaIzComboBoxevaZaAzuriranjeIBrisanje(studentZaBrisanje);
        }             

        private void obrisiPodatkeUTabeliKorisnik(String korisnikZaBrisanje)
        {
            Korisnik.obrisiKorisnika(korisnikZaBrisanje);
        }

        private void obrisiStudentaIzComboBoxevaZaAzuriranjeIBrisanje(Student student)
        {
            obrisiStudentaIzComboBoxa(comboBox1, student);
            obrisiStudentaIzComboBoxa(comboBox4, student);
        }

        private void obrisiStudentaIzComboBoxa(ComboBox comboBox, Student student)
        {
            comboBox.Items.Remove(student.getIndex() + ": " + student.getIme() + student.getPrezime());
            comboBox.SelectedIndex = 0;
        }

        private void StudentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            adminFrm.Show();
        }
    }
}
