using System;
using System.Windows.Forms;


namespace Projekat
{
    public partial class GlavnaAdminForma : Form
    {
        private PocetnaForm pocetnaForma;

        public GlavnaAdminForma(PocetnaForm pocetnaForma)
        {
            this.pocetnaForma = pocetnaForma;
            InitializeComponent();
        }

        private void smerButton_Click(object sender, EventArgs e)
        {
            SmerForm smerFrm = new SmerForm(this);
            smerFrm.Show();
            this.Hide();
        }

        private void studentButton_Click(object sender, EventArgs e)
        {
            StudentForm studentFrm = new StudentForm(this);
            studentFrm.Show();
            this.Hide();
        }

        private void predmetButton_Click(object sender, EventArgs e)
        {
            PredmetForm predmetFrm = new PredmetForm(this);
            predmetFrm.Show();
            this.Hide();
        }

        private void izbornaListaButton_Click(object sender, EventArgs e)
        {
            IzbornaListaForm izvbornaListaFrm = new IzbornaListaForm(this);
            izvbornaListaFrm.Show();
            this.Hide();
        }

        private void statistikaButton_Click(object sender, EventArgs e)
        {
            StatistikaForm statistikaFrm = new StatistikaForm(this);
            statistikaFrm.Show();
            this.Hide();
        }

        private void GlavnaAdminForma_FormClosing(object sender, FormClosingEventArgs e)
        {
            pocetnaForma.obrisiTextBoxove();
            pocetnaForma.Show();
        }
    }
}