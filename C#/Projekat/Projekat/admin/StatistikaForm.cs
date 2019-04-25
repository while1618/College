using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Projekat
{
    public partial class StatistikaForm : Form
    {
        private GlavnaAdminForma adminFrm;
        private int brojStudenata;
        private Predmet predmet;
        private int brojStudenataNaPredmetu;
        private float procenat;

        public StatistikaForm(GlavnaAdminForma adminFrm)
        {
            InitializeComponent();
            this.adminFrm = adminFrm;
            brojStudenata = Student.vratiBrojStudenata();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            predmet = Predmet.vratiPredmetZaNaziv(comboBox1.SelectedItem.ToString());
        }

        private void StatistikaForm_Load(object sender, EventArgs e)
        {
            popuniComboBoxPredmetima(comboBox1);
            onemoguciPisanjeUComboBox();
        }

        private void popuniComboBoxPredmetima(ComboBox comboBox) 
        {
            List<Predmet> predmeti = Predmet.podaciIzTabelePredmet();
            foreach (Predmet predmet in predmeti)
            {
                comboBox.Items.Add(predmet.getNaziv());
            }
            comboBox.SelectedIndex = 0;
        }

        private void onemoguciPisanjeUComboBox() 
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void obrisiSadrzajLabela() 
        {
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            brojStudenataNaPredmetu = IzbornaLista.vratiBrojStudenataNaPredmetu(predmet);
            procenat = racunajProcenatStudenataKojiSlusajuPredmet();
            zaokruziNa2Decimale(); 
            obrisiSadrzajLabela();
            popuniLabele();
            procenat = procenat * 3.6F;
            this.Paint += crtanje;
            this.Invalidate();
        }

        private void zaokruziNa2Decimale() 
        {
            procenat = (float)Math.Round((Decimal)procenat, 2, MidpointRounding.AwayFromZero);
        }

        private float racunajProcenatStudenataKojiSlusajuPredmet()
        {
            return (float)brojStudenataNaPredmetu * 100 / brojStudenata;
        }

        private void crtanje(object sender, PaintEventArgs e)
        {
            Rectangle r = new Rectangle(130, 150, 100, 100);
            e.Graphics.DrawEllipse(Pens.Black, r);
            e.Graphics.FillEllipse(Brushes.Blue, r);
            e.Graphics.FillPie(Brushes.Red, r, -90F, procenat);
        }

        private void popuniLabele() 
        {
            label2.Text = "Broj studenta: " + brojStudenata;
            label3.Text = "Broj studenata na predmetu: " + brojStudenataNaPredmetu;
            label4.Text = "Procenat: " + procenat + " % ";
        }

        private void StatistikaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            adminFrm.Show();
        }
    }
}
