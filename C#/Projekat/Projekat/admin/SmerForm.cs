using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Projekat
{
    public partial class SmerForm : Form
    {
        private GlavnaAdminForma adminFrm;
        public SmerForm(GlavnaAdminForma adminFrm)
        {
            InitializeComponent();
            this.adminFrm = adminFrm;
        }

        private void SmerForm_Load(object sender, EventArgs e)
        {
            onemoguciPisanjeUComboBoxevima();
            popuniComboBoxPodacimaIzTabeleSmer(comboBox1);
            popuniComboBoxPodacimaIzTabeleSmer(comboBox2);
        }

        private void onemoguciPisanjeUComboBoxevima()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
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

        private void unosNovogSmeraButton_Click(object sender, EventArgs e)
        {
            unesiNoviSmer();
        }

        private void unesiNoviSmer()
        {
            string nazivSmera = textBox1.Text;
            if (proveraNazivaUnetogSmera(nazivSmera))
            {
                promeniUnetiNazivSmeraUVelikaSlova(ref nazivSmera);
                Smer smer = new Smer(nazivSmera);
                if (!daLiSeUnetiSmerVecNalaziUBazi(smer))
                {
                    smer.dodajNoviSmer();
                    MessageBox.Show("Uspesno ste dodali smer");
                    dodajSmerUComboBoxeveZaAzuriranjeIBrisanje(smer);
                }
            }
        }
        
        private bool proveraNazivaUnetogSmera(String nazivSmera)
        {
            if (nazivSmera.Equals(""))
            {
                MessageBox.Show("Niste uneli ime smera");
                return false;
            }
            return true;
        }

        private void promeniUnetiNazivSmeraUVelikaSlova(ref String nazivSmera)
        {
            nazivSmera = nazivSmera.ToUpper();
        }

        private bool daLiSeUnetiSmerVecNalaziUBazi(Smer smer)
        {
            if (smer.daLiNazivSmeraVecPostoji())
            {
                MessageBox.Show("Smer sa tim imenom vec postoji");
                return true;
            }
            return false;
        }       

        private void dodajSmerUComboBoxeveZaAzuriranjeIBrisanje(Smer smer)
        {
            dodajUnetiSmerUComboBox(comboBox1, smer);
            dodajUnetiSmerUComboBox(comboBox2, smer);
        }

        private void dodajUnetiSmerUComboBox(ComboBox comboBox, Smer smer)
        {
            comboBox.Items.Add(smer.getNazivSmera());
        }

        private void izmenaSmeraButton_Click(object sender, EventArgs e)
        {
            azurirajSmer();
        }

        private void azurirajSmer()
        {
            string stariNazivSmera = comboBox1.SelectedItem.ToString();
            string noviNazivSmera = textBox2.Text;
            if (proveraNazivaUnetogSmera(noviNazivSmera))
            {
                promeniUnetiNazivSmeraUVelikaSlova(ref noviNazivSmera);
                Smer stariSmer = new Smer(stariNazivSmera);
                Smer noviSmer = new Smer(noviNazivSmera);
                if (!daLiSeUnetiSmerVecNalaziUBazi(noviSmer))
                {
                    noviSmer.azurirajSmer(stariSmer);
                    MessageBox.Show("Uspesno ste azurirali smer");
                    azurirajComboBoxeveZaAzuriranjeIBrisanjeSmera(stariSmer, noviSmer);
                }                
            }
        }

        private void azurirajComboBoxeveZaAzuriranjeIBrisanjeSmera(Smer stariSmer, Smer noviSmer) 
        {
            obrisiSmerIzComboBoxa(comboBox1, stariSmer);
            obrisiSmerIzComboBoxa(comboBox2, stariSmer);
            dodajUnetiSmerUComboBox(comboBox1, noviSmer);
            dodajUnetiSmerUComboBox(comboBox2, noviSmer);
        }

        private void brisanjeSmeraButton_Click(object sender, EventArgs e)
        {
            obrisiSmer();
        }     

        private void obrisiSmer()
        {
            string nazivSmera = comboBox2.SelectedItem.ToString();
            Smer smer = new Smer(nazivSmera);
            if(!daLiNekoPohadjaSmer(smer))
            {
                smer.obrisiSmer();
                MessageBox.Show("Uspesno ste obrisali smer");
                obrisiSmerIzComboBoxevaZaAzuriranjeIBrisanje(smer);
            }         
        }
        
        private bool daLiNekoPohadjaSmer(Smer smer)
        {
            if (smer.daLiNekoPohadjaSmer())
            {
                MessageBox.Show("Ne mozete obrisati smer koji ima aktivnih studenata");
                return true;
            }
            return false;
        }

        private void obrisiSmerIzComboBoxevaZaAzuriranjeIBrisanje(Smer smer)
        {
            obrisiSmerIzComboBoxa(comboBox1, smer);
            obrisiSmerIzComboBoxa(comboBox2, smer);
        }

        private void obrisiSmerIzComboBoxa(ComboBox comboBox, Smer smer) 
        {
            comboBox.Items.Remove(smer.getNazivSmera());
            comboBox.SelectedIndex = 0;
        }

        private void SmerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            adminFrm.Show();
        }
    }
}
