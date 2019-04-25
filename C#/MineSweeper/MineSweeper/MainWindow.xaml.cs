using System;
using System.Windows;

namespace MineSweeper
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool checkIfNameIsEmpty()
        {
            return (textBox.Text.Equals("")) ? true : false;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if(!checkIfNameIsEmpty())
            {
                String player = textBox.Text;
                EasyWindow easy = new EasyWindow(this, player);
                this.Hide();
                easy.Show();
            }
            else
            {
                MessageBox.Show("Morate uneti ime");
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (!checkIfNameIsEmpty())
            {
                String player = textBox.Text;
                MediumWindow medium = new MediumWindow(this, player);
                this.Hide();
                medium.Show();
            }
            else
            {
                MessageBox.Show("Morate uneti ime");
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (!checkIfNameIsEmpty())
            {
                String player = textBox.Text;
                HardWindow hard = new HardWindow(this, player);
                this.Hide();
                hard.Show();
            }
            else
            {
                MessageBox.Show("Morate uneti ime");
            }
        }
    }
}
