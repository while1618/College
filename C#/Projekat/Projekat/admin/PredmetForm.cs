using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Projekat
{
    public partial class PredmetForm : Form
    {
        private Predmet noviPredmet;
        private Predmet stariPredmet;
        private GlavnaAdminForma adminFrm;

        public PredmetForm(GlavnaAdminForma adminFrm)
        {
            InitializeComponent();
            this.adminFrm = adminFrm;
        }

        private void PredmetForm_Load(object sender, EventArgs e)
        {
            postaviMogucnosMenjanjaCheckedListBoxovaNaClick();
            popuniSadrzajComboBoxova();
            onemoguciPisanjeSadrzajaUComboBoxove();
            popuniSadrzajCheckedListBoxova();
            setujRadioButtonNaTrue();
        }

        private void postaviMogucnosMenjanjaCheckedListBoxovaNaClick()
        {
            checkedListBox1.CheckOnClick = true;
            checkedListBox2.CheckOnClick = true;
            checkedListBox3.CheckOnClick = true;
        }

        private void popuniSadrzajComboBoxova()
        {
            popuniComboBoxPodacimaIzTabelePredmet(comboBox1);
            popuniComboBoxPodacimaIzTabelePredmet(comboBox2);
            popuniComboBoxBrojemSemestra(comboBox4);
            popuniComboBoxBrojemSemestra(comboBox6);
            popuniComboBoxBrojemEspb(comboBox3);
            popuniComboBoxBrojemEspb(comboBox5);
        }

        public void popuniComboBoxPodacimaIzTabelePredmet(ComboBox comboBox)
        {
            List<Predmet> predmeti = Predmet.podaciIzTabelePredmet();
            foreach (Predmet predmet in predmeti)
            {
                comboBox.Items.Add(predmet.getNaziv());
            }
            comboBox.SelectedIndex = 0;
        }

        private void popuniComboBoxBrojemSemestra(ComboBox brojSemestra)
        {
            for (int i = 0; i < 6; i++)
            {
                brojSemestra.Items.Add(i + 1);
            }
            brojSemestra.SelectedIndex = 0;
        }

        private void popuniComboBoxBrojemEspb(ComboBox espb)
        {
            for (int i = 0; i < 10; i++)
            {
                espb.Items.Add(i + 1);
            }
            espb.SelectedIndex = 5;
        }

        private void onemoguciPisanjeSadrzajaUComboBoxove()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox6.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void popuniSadrzajCheckedListBoxova()
        {
            popuniCheckedListBoxPodacimaIzTabeleSmer(checkedListBox1);
            popuniCheckedListBoxPodacimaIzTabeleSmer(checkedListBox2);
            popuniCheckedListBoxPodacimaIzTabeleSmer(checkedListBox3);
        }

        private void popuniCheckedListBoxPodacimaIzTabeleSmer(CheckedListBox checkedListBox)
        {
            int i = 0;
            List<Smer> smerovi = Smer.podaciIzTabeleSmer();
            foreach (Smer smer in smerovi)
            {
                checkedListBox.Items.Insert(i++, smer.getNazivSmera());
            }
        }

        private void setujRadioButtonNaTrue()
        {
            radioButton1.Checked = true;
        }

        private void UnesiButton_Click_1(object sender, EventArgs e)
        {
            if (unesiNoviPredmet())
            {
                unesiSmeroveZaPredmet();
            }
        }

        private void unesiSmeroveZaPredmet()
        {
            PredmetSmer predmetSmer = podaciPredmetSmer(checkedListBox3);
            predmetSmer.dodajSmeroveZaPredmet();
            MessageBox.Show("Uspesno ste dodali dodali predmet");
        }

        private PredmetSmer podaciPredmetSmer(CheckedListBox checkedListBox)
        {
            PredmetSmer predmetSmer = new PredmetSmer(noviPredmet);
            foreach (String s in checkedListBox.CheckedItems)
            {
                Smer smer = new Smer(s);
                predmetSmer.dodajSmer(smer);
            }
            return predmetSmer;
        }

        private bool unesiNoviPredmet()
        {
            noviPredmet = podaciNovogPredmeta(textBoxoviZaUnosNovogStudenta(), "unosNovogPredmeta");
            if(daLiSuUnetiValidniPodaci(noviPredmet))
            {
                if(!daLiUnetiNazivPredmetaVecPostojiUBazi(noviPredmet) && !daLiUnetiaSifraPredmetaVecPostojiUBazi(noviPredmet))
                {
                    noviPredmet.dodajNovPredmet();
                    dodajPredmetUComboBoxeveZaAzuriranjeIBrisanje(noviPredmet);
                    return true;
                }
            }
            return false;
        }

        private Predmet podaciNovogPredmeta(TextBox[] nizTextboxova, String tipUnosa)
        {
            int[] nizPodataka = new int[3];
            int sifra;
            if (!Int32.TryParse(nizTextboxova[0].Text, out sifra)) return new Predmet();
            String naziv = nizTextboxova[1].Text;
            String profesor = nizTextboxova[2].Text;
            nizPodataka = vracanjePodatakaNaOsnovuTipaUnosa(tipUnosa);
            if(proveraUnetihPodataka(sifra, naziv, profesor, nizPodataka))
            {
                int espb = nizPodataka[0];
                int semestar = nizPodataka[1];
                int obavezan = nizPodataka[2];
                return new Predmet(sifra, naziv, profesor, espb, obavezan, semestar);
            }
            return new Predmet();
        }

        private int[] vracanjePodatakaNaOsnovuTipaUnosa(String tipUnosa)
        {
            if (tipUnosa.Equals("unosNovogPredmeta"))
            {
                return unetiPodaci(comboBox3, comboBox4, checkBox1);
            }
            else if (tipUnosa.Equals("azuriranjePredmeta"))
            {
                return unetiPodaci(comboBox5, comboBox6, checkBox2);
            }
            else
            {
                return new int[0];
            }
        }

        private bool proveraUnetihPodataka(int sifra, String naziv, String profesor, int[] nizPodataka)
        {
            return (naziv != "" && profesor != "" && nizPodataka.Length == 3) ? true : false;
        }

        private int[] unetiPodaci(ComboBox espb, ComboBox semestar, CheckBox obavezan)
        {
            int[] nizPodataka = new int[3];
            nizPodataka[0] = Int32.Parse(espb.SelectedItem.ToString());
            nizPodataka[1] = Int32.Parse(semestar.SelectedItem.ToString());
            nizPodataka[2] = (obavezan.Checked) ? 1 : 0;
            return nizPodataka;
        }

        private TextBox[] textBoxoviZaUnosNovogStudenta()
        {
            TextBox[] nizTextBoxova = new TextBox[6];
            nizTextBoxova[0] = textBox1;
            nizTextBoxova[1] = textBox2;
            nizTextBoxova[2] = textBox3;

            return nizTextBoxova;
        }

        private bool daLiSuUnetiValidniPodaci(Predmet predmet)
        {
            if (predmet.getNaziv() == "")
            {
                MessageBox.Show("Niste uneli validne podatke");
                return false;
            }
            return true;
        }

        private bool daLiUnetiNazivPredmetaVecPostojiUBazi(Predmet predmet)
        {
            if (predmet.daLiPostojiNazivPredmeta())
            {
                MessageBox.Show("Uneti naziv predmeta vec postoji u bazi");
                return true;
            }
            return false;            
        }

        private bool daLiUnetiaSifraPredmetaVecPostojiUBazi(Predmet predmet)
        {
            if (predmet.daLiPostojiSifraPredmeta())
            {
                MessageBox.Show("Uneta sifra predmeta vec postoji u bazi");
                return true;
            }
            return false;
        }

        private void dodajPredmetUComboBoxeveZaAzuriranjeIBrisanje(Predmet predmet)
        {
            dodajUnetiPredmetUComboBox(comboBox1, predmet);
            dodajUnetiPredmetUComboBox(comboBox2, predmet);
        }

        private void dodajUnetiPredmetUComboBox(ComboBox comboBox, Predmet predmet)
        {
            comboBox.Items.Add(predmet.getNaziv());
        }

        private void IzmeniButton_Click_1(object sender, EventArgs e)
        {
            if (azurirajPredmet())
            {
                azurirajSmeroveZaPredmet();
            }
        }

        private void azurirajSmeroveZaPredmet()
        {
            PredmetSmer predmetSmer = podaciPredmetSmer(checkedListBox2);
            predmetSmer.azurirajSmeroveZaPredmet(stariPredmet);
            MessageBox.Show("Uspesno ste azurirali predmet");
        }

        private bool azurirajPredmet()
        {
            stariPredmet = podaciStarogPredmeta();
            noviPredmet = podaciNovogPredmeta(textBoxoviZaAzuriranje(), "azuriranjePredmeta");
            if (daLiSuUnetiValidniPodaci(noviPredmet))
            {
                if(!daLiJeUnetStariNaziv(noviPredmet, stariPredmet))
                {
                    if (daLiUnetiNazivPredmetaVecPostojiUBazi(noviPredmet))
                    {
                        return false;
                    }
                }
                if(!daLiJeUnetaStaraSifra(noviPredmet, stariPredmet))
                {
                    if(daLiUnetiaSifraPredmetaVecPostojiUBazi(noviPredmet))
                    {
                        return false;
                    }
                }
                noviPredmet.azurirajPredmet(stariPredmet);
                azurirajComboBoxeveZaAzuriranjeIBrisanje(stariPredmet, noviPredmet);
                return true;     
            }
            return false;
        }

        private Predmet podaciStarogPredmeta()
        {
            String stariNaziv = comboBox2.SelectedItem.ToString();
            return Predmet.vratiPredmetZaNaziv(stariNaziv);
        }

        private TextBox[] textBoxoviZaAzuriranje()
        {
            TextBox[] nizTextBoxova = new TextBox[6];
            nizTextBoxova[0] = textBox12;
            nizTextBoxova[1] = textBox11;
            nizTextBoxova[2] = textBox10;

            return nizTextBoxova;
        }

        private bool daLiJeUnetStariNaziv(Predmet noviPredmet, Predmet stariPredmet)
        {
            return (noviPredmet.getNaziv().Equals(stariPredmet.getNaziv())) ? true : false;
        }

        private bool daLiJeUnetaStaraSifra(Predmet noviPredmet, Predmet stariPredmet)
        {
            return (noviPredmet.getSifra().Equals(stariPredmet.getSifra())) ? true : false;
        }

        private void azurirajComboBoxeveZaAzuriranjeIBrisanje(Predmet startiPredmet, Predmet noviPredmet) 
        {
            obrisiPredmetIzComboBoxa(comboBox1, stariPredmet);
            obrisiPredmetIzComboBoxa(comboBox2, stariPredmet);
            dodajUnetiPredmetUComboBox(comboBox1, noviPredmet);
            dodajUnetiPredmetUComboBox(comboBox2, noviPredmet);
        }

        private void ObrisiButton_Click_1(object sender, EventArgs e)
        {
            obrisiPredmet();
        }

        private void obrisiPredmet()
        {
            String izabranPredmetZaBrisanje = comboBox1.Text;
            noviPredmet = Predmet.vratiPredmetZaNaziv(izabranPredmetZaBrisanje);
            if(!daLiNekoPohadjaPredmet(noviPredmet))
            {
                brisanjePredmetaNaOsnovuIzabranogRadioButtona(noviPredmet);
            }
        }

        private bool daLiNekoPohadjaPredmet(Predmet predmet)
        {
            if (predmet.daLiNekoPohadjaPredmet())
            {
                MessageBox.Show("Ne mozete obrisati predmet koji ima aktivnih studenata");
                return true;
            }
            return false;
        }

        private void brisanjePredmetaNaOsnovuIzabranogRadioButtona(Predmet predmetZaBrisanje)
        {
            if (radioButton1.Checked)
            {
                brisanjeCelogPredmetaSaSmerovima(predmetZaBrisanje);
                obrisiSmerIzComboBoxevaZaAzuriranjeIBrisanje(predmetZaBrisanje);
            }
            else if (radioButton2.Checked)
            {
                brisanjeSamoPredmetaSaOdredjenogSmera();
            }
        }

        private void brisanjeCelogPredmetaSaSmerovima(Predmet predmetZaBrisanje)
        {
            predmetZaBrisanje.obrisiPredmet();
            PredmetSmer predmetSmer = new PredmetSmer(predmetZaBrisanje);
            predmetSmer.obrisiSveSmeroveZaPredmet();
            MessageBox.Show("Uspesno ste obrisali predmet");
        }

        private void brisanjeSamoPredmetaSaOdredjenogSmera()
        {
            PredmetSmer predmetSmer = podaciPredmetSmer(checkedListBox1);
            predmetSmer.obrisiIzabraneSmeroveZaPredmet();
            MessageBox.Show("Uspesno ste obrisali predmet sa smerova: " + predmetSmer);
        }

        private void obrisiSmerIzComboBoxevaZaAzuriranjeIBrisanje(Predmet predmet)
        {
            obrisiPredmetIzComboBoxa(comboBox1, predmet);
            obrisiPredmetIzComboBoxa(comboBox2, predmet);
        }

        private void obrisiPredmetIzComboBoxa(ComboBox comboBox, Predmet predmet)
        {
            comboBox.Items.Remove(predmet.getNaziv());
            comboBox.SelectedIndex = 0;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                checkedListBox1.Enabled = false;
            }
            else if (radioButton2.Checked)
            {
                checkedListBox1.Enabled = true;
            }
        }

        private void PredmetForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            adminFrm.Show();
        }
    }
}
