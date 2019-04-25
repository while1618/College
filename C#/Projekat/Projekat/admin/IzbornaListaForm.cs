using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Projekat
{
    public partial class IzbornaListaForm : Form
    {
        private GlavnaAdminForma adminFrm;
        private Student student;
        private int zbirBodova;
        private String prethodnaVrednostComboBoxa;

        public IzbornaListaForm(GlavnaAdminForma adminFrm)
        {
            InitializeComponent();
            this.adminFrm = adminFrm;
            this.prethodnaVrednostComboBoxa = "Bez predmeta sa drugog smera";
        }

        private void IzbornaListaForm_Load(object sender, EventArgs e)
        {
            onemogucitiMouseWheelUComboBoxu();
            onemoguciKeyPressUComboBoxu();
            onemogucitiPisanjeUComboBoxevima();
            punjenjeComboBoxevaPodacima();
            this.student = podaciStudenta(comboBox1);
            postaviMogucnosMenjanjaCheckedListBoxovaNaClick();
            racunajEspbBodove();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.student = podaciStudenta(comboBox1);
            checkedListBox1.Items.Clear();
            comboBox2.Items.Clear();
            popuniCheckedListBoxPredmetimaSaSmera();
            popuniComboBoxPredmetimaSaDrugihSmerova();
            postavitiNazivSmeraULabelu();
            racunajEspbBodove();
        }

        private void onemogucitiMouseWheelUComboBoxu()
        {
            comboBox2.MouseWheel += new MouseEventHandler(comboBox2_MouseWheel);
        }

        private void comboBox2_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void onemoguciKeyPressUComboBoxu()
        {
            comboBox2.KeyDown += new KeyEventHandler(comboBox2_KeyDown);
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }          

        private void onemogucitiPisanjeUComboBoxevima()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void punjenjeComboBoxevaPodacima()
        {
            popuniComboBoxPodacimaIzTableleStudent(comboBox1);
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

        private void popuniComboBoxPredmetimaSaDrugihSmerova()
        {
            comboBox2.Items.Add("Bez predmeta sa drugog smera");
            comboBox2.SelectedIndex = 0;
            List<Predmet> predmeti = Predmet.podaciIzTabelePredmet();
            int brojPredmetaSaDrugogSmera = 0;
            foreach (Predmet predmet in predmeti)
            {
                if (!predmet.daLiSePredmetNalaziNaSmeru(student.getSmer()))
                {
                    brojPredmetaSaDrugogSmera++;
                    comboBox2.Items.Add(predmet.getNaziv());
                    postavljanjePredmetaKaoSelektovanUComboBoxuAkoGaStudentPohadja(predmet, brojPredmetaSaDrugogSmera);
                }
            }
        }

        private void postavljanjePredmetaKaoSelektovanUComboBoxuAkoGaStudentPohadja(Predmet predmet, int brojPredmetaSaDrugogSmera)
        {
            if (predmet.daLiStudentPohadjaPredmet(student))
            {
                comboBox2.SelectedIndex = brojPredmetaSaDrugogSmera;
            }
        }

        private Student podaciStudenta(ComboBox comboBox)
        {
            string izabraniStudentZaAzuriranje = comboBox.SelectedItem.ToString();
            string[] tokens = izabraniStudentZaAzuriranje.Split(':');
            string stariIndex = tokens[0];
            return Student.vratiStudentaZaIndex(stariIndex);
        }

        private void postaviMogucnosMenjanjaCheckedListBoxovaNaClick()
        {
            checkedListBox1.CheckOnClick = true;
        }

        private void postavitiNazivSmeraULabelu()
        {
            label1.Text = "Predmeti za smer: " + student.getSmer().getNazivSmera();
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
            String izabraniPredmet = (String)comboBox2.SelectedItem;
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

        private void unesiListu()
        {
            List<Predmet> listaIzabranihPredmeta = vratiListuPredmeta();
            IzbornaLista listaPredmeta = new IzbornaLista(this.student, listaIzabranihPredmeta);
            izbrisiSvePredmeteKojeSlusaStudent();
            listaPredmeta.dodajListuPredmeta();
            MessageBox.Show("Uspesno ste uneli listu");
        }

        private void izbrisiSvePredmeteKojeSlusaStudent()
        {
            IzbornaLista.obrisiStudentovuListu(this.student);
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
            String nazivPredmetaSaDrugogSmera = comboBox2.Text;
            if (!nazivPredmetaSaDrugogSmera.Equals("Bez predmeta sa drugog smera"))
            {
                Predmet predmet = Predmet.vratiPredmetZaNaziv(nazivPredmetaSaDrugogSmera);
                listaPredmeta.Add(predmet);
            }
        }

        private void obrisiIzbornuListuStudentu()
        {
            IzbornaLista.obrisiStudentovuListu(student);
            MessageBox.Show("Uspesno ste obrisali studentovu izbornu listu");
            checkedListBox1.Items.Clear();
            comboBox2.Items.Clear();
            popuniCheckedListBoxPredmetimaSaSmera();
            popuniComboBoxPredmetimaSaDrugihSmerova();
            racunajEspbBodove();
        }       

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.zbirBodova < 48)
            {
                MessageBox.Show("Morate imati 48 ili vise espb bodova!");
            }
            else
            {
                unesiListu();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            obrisiIzbornuListuStudentu();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String izabraniPredmet = (string)comboBox2.SelectedItem;
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

        private void comboBox2_Click(object sender, EventArgs e)
        {
            this.prethodnaVrednostComboBoxa = (string)comboBox2.SelectedItem;
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

        private void IzbornaListaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            adminFrm.Show();
        }
    }
}
