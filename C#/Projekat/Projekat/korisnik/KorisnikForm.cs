using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Projekat
{
    public partial class KorisnikForm : Form
    {
        private String korisnickoIme;
        private Student student;
        private int zbirBodova;
        private String prethodnaVrednostComboBoxa;
        private PocetnaForm pocetnaForma;

        public KorisnikForm(String korisnickoIme, PocetnaForm pocetnaForma)
        {
            this.pocetnaForma = pocetnaForma;
            this.korisnickoIme = korisnickoIme;
            this.prethodnaVrednostComboBoxa = "Bez predmeta sa drugog smera";
            this.student = Student.vratiStudentaZaKorisnickoIme(korisnickoIme);
            InitializeComponent();
        }

        private void KorisnikForm_Load(object sender, EventArgs e)
        {
            onemogucitiMouseWheelUComboBoxu();
            onemoguciKeyPressUComboBoxu();
            onemogucitiPisanjeUComboBoxevima();
            postaviMogucnosMenjanjaCheckedListBoxovaNaClick();
            postavitiNazivSmeraULabelu();
            popuniCheckedListBoxPredmetimaSaSmera();
            popuniComboBoxPredmetimaSaDrugihSmerova();
            racunajEspbBodove();
        }

        private void onemogucitiMouseWheelUComboBoxu()
        {
            comboBox1.MouseWheel += new MouseEventHandler(comboBox1_MouseWheel);
        }

        private void comboBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void onemoguciKeyPressUComboBoxu()
        {
            comboBox1.KeyDown += new KeyEventHandler(comboBox1_KeyDown);
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void onemogucitiPisanjeUComboBoxevima()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void postaviMogucnosMenjanjaCheckedListBoxovaNaClick()
        {
            checkedListBox1.CheckOnClick = true;
        }

        private void postavitiNazivSmeraULabelu()
        {
            label1.Text += student.getSmer().getNazivSmera();
        }

        private void popuniCheckedListBoxPredmetimaSaSmera()
        {
            int i = 0;
            List<Predmet> predmeti = Predmet.sortiraniPodaciIzTabelePredmet();
            foreach (Predmet predmet in predmeti)
            {
                if (predmet.daLiSePredmetNalaziNaSmeru(student.getSmer()))
                {
                    checkedListBox1.Items.Insert(i, predmet.getNaziv());
                    cekiranjePredmetaAkoGaStudentVecPohadja(predmet, i);
                    onemogucitiMenjanjeObaveznogPredmeta(predmet, i);
                    i++;
                }
            }
        }

        private void cekiranjePredmetaAkoGaStudentVecPohadja(Predmet predmet, int index)
        {
            if (predmet.daLiStudentPohadjaPredmet(student))
            {
                checkedListBox1.SetItemChecked(index, true);
            }
        }

        private void onemogucitiMenjanjeObaveznogPredmeta(Predmet predmet, int index)
        {
            if (predmet.getObavezan() == 1)
            {
                checkedListBox1.SetItemChecked(index, true);
                checkedListBox1.SetItemCheckState(index, CheckState.Indeterminate);
                checkedListBox1.ItemCheck += (s, e) => { if (e.CurrentValue == CheckState.Indeterminate) e.NewValue = CheckState.Indeterminate; };
            }
        }

        private void popuniComboBoxPredmetimaSaDrugihSmerova()
        {
            comboBox1.Items.Add("Bez predmeta sa drugog smera");
            comboBox1.SelectedIndex = 0;
            List<Predmet> predmeti = Predmet.podaciIzTabelePredmet();
            int brojPredmetaSaDrugogSmera = 0;
            foreach (Predmet predmet in predmeti)
            {
                if (!predmet.daLiSePredmetNalaziNaSmeru(student.getSmer()))
                {
                    brojPredmetaSaDrugogSmera++;
                    comboBox1.Items.Add(predmet.getNaziv());
                    postavljanjePredmetaKaoSelektovanUComboBoxuAkoGaStudentPohadja(predmet, brojPredmetaSaDrugogSmera);
                }
            }
        }

        private void postavljanjePredmetaKaoSelektovanUComboBoxuAkoGaStudentPohadja(Predmet predmet, int brojPredmetaSaDrugogSmera)
        {
            if (predmet.daLiStudentPohadjaPredmet(student))
            {
                comboBox1.SelectedIndex = brojPredmetaSaDrugogSmera;
            }
        }

        private void racunajEspbBodove()
        {
            this.zbirBodova = 0;
            this.zbirBodova += racunajBodovePredmetaSaSmera();
            this.zbirBodova += racunajBodovePredmetaSaDrugihSmerova();
            postaviBodoveULabelu();
        }

        private int racunajBodovePredmetaSaSmera()
        {
            int bodovi = 0;
            foreach (String s in checkedListBox1.CheckedItems)
            {
                Predmet predmet = Predmet.vratiPredmetZaNaziv(s);
                int espbBodovi = predmet.getEspbBodove();
                bodovi += espbBodovi;
            }
            return bodovi;
        }

        private int racunajBodovePredmetaSaDrugihSmerova()
        {
            int bodovi = 0;
            String izabraniPredmet = (String)comboBox1.SelectedItem;
            if (!izabraniPredmet.Equals("Bez predmeta sa drugog smera"))
            {
                Predmet predmet = Predmet.vratiPredmetZaNaziv(izabraniPredmet);
                int espbBodovi = predmet.getEspbBodove();
                bodovi += espbBodovi;
            }
            return bodovi;
        }

        private void postaviBodoveULabelu()
        {
            label3.Text = this.zbirBodova.ToString();
        }           

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            String nazivIzabranogPredmeta = checkedListBox1.Items[e.Index].ToString();
            Predmet izabraniPredmet = Predmet.vratiPredmetZaNaziv(nazivIzabranogPredmeta);

            if (izabraniPredmet.getObavezan() != 1)
            {
                menjanjeBrojaEspbUZavisnostiOdCekiranogPredmeta(izabraniPredmet);
                postaviBodoveULabelu();
            }
        }

        private void menjanjeBrojaEspbUZavisnostiOdCekiranogPredmeta(Predmet izabraniPredmet)
        {
            int index = checkedListBox1.FindString(izabraniPredmet.getNaziv());
            if (checkedListBox1.GetItemChecked(index))
            {
                this.zbirBodova -= izabraniPredmet.getEspbBodove();
            }
            else
            {
                this.zbirBodova += izabraniPredmet.getEspbBodove();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String izabraniPredmet = (String)comboBox1.SelectedItem;
            if (!izabraniPredmet.Equals("Bez predmeta sa drugog smera"))
            {
                izabranPredmetSaDrugogSmera(izabraniPredmet);
            }
            else
            {
                bezPredmetaSaDrugogSmera();
            }
        }

        private void izabranPredmetSaDrugogSmera(String izabraniPredmet)
        {
            if (!izabraniPredmet.Equals(prethodnaVrednostComboBoxa))
            {
                Predmet predmet = Predmet.vratiPredmetZaNaziv(izabraniPredmet);
                this.zbirBodova += predmet.getEspbBodove();
                if (!prethodnaVrednostComboBoxa.Equals("Bez predmeta sa drugog smera"))
                {
                    Predmet prethodniPredmet = Predmet.vratiPredmetZaNaziv(prethodnaVrednostComboBoxa);
                    this.zbirBodova -= prethodniPredmet.getEspbBodove();
                }
                postaviBodoveULabelu();
            }
        }

        private void bezPredmetaSaDrugogSmera()
        {
            if (!prethodnaVrednostComboBoxa.Equals("Bez predmeta sa drugog smera"))
            {
                Predmet prethodniPredmet = Predmet.vratiPredmetZaNaziv(prethodnaVrednostComboBoxa);
                this.zbirBodova -= prethodniPredmet.getEspbBodove();
                postaviBodoveULabelu();
            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            this.prethodnaVrednostComboBoxa = (String)comboBox1.SelectedItem;
        }

        private void unesiListu()
        {
            List<Predmet> listaIzabranihPredmeta = vratiListuPredmeta();
            IzbornaLista listaPredmeta = new IzbornaLista(this.student, listaIzabranihPredmeta);
            izbrisiSvePredmeteKojeSlusaStudent();
            listaPredmeta.dodajListuPredmeta();
            MessageBox.Show("Uspesno ste uneli listu");
        }

        private List<Predmet> vratiListuPredmeta()
        {
            List<Predmet> listaPredmeta = new List<Predmet>();
            predmetiSaSmera(listaPredmeta);
            predmetSaDrugogSmera(listaPredmeta);
            return listaPredmeta;
        }

        private void predmetiSaSmera(List<Predmet> listaPredmeta)
        {
            foreach (String s in checkedListBox1.CheckedItems)
            {
                Predmet predmet = Predmet.vratiPredmetZaNaziv(s);
                listaPredmeta.Add(predmet);
            }
        }

        private void predmetSaDrugogSmera(List<Predmet> listaPredmeta)
        {
            String nazivPredmetaSaDrugogSmera = comboBox1.Text;
            if (!nazivPredmetaSaDrugogSmera.Equals("Bez predmeta sa drugog smera"))
            {
                Predmet predmet = Predmet.vratiPredmetZaNaziv(nazivPredmetaSaDrugogSmera);
                listaPredmeta.Add(predmet);
            }
        }

        private void izbrisiSvePredmeteKojeSlusaStudent()
        {
            IzbornaLista.obrisiStudentovuListu(this.student);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.zbirBodova < 48)
            {
                MessageBox.Show("Morate imati 48 ili vise espb bodova!");
            }
            else
            {
                unesiListu();
                Close();
                pocetnaForma.obrisiTextBoxove();
                pocetnaForma.Show();
            }
        }

        private void KorisnikForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            pocetnaForma.obrisiTextBoxove();
            pocetnaForma.Show();
        }
    }
}
