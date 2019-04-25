using System;
using System.Windows;

namespace MineSweeper
{
    public partial class MediumWindow : Window
    {
        private MainWindow mainWindow;
        private int numberOfMines;
        private int numberOfRows;
        private int numberOfColumns;
        private String player;
        private String level;

        public MediumWindow(MainWindow mainWindow, String player)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.numberOfMines = 15;
            this.numberOfRows = 12;
            this.numberOfColumns = 12;
            labelMine.Content = numberOfMines;
            this.player = player;
            this.level = "medium";
            MyGraphics myGraphics = new MyGraphics(numberOfMines, numberOfRows, numberOfColumns, smileButton, labelTime, labelMine, grid);
            MineSweeperLogic mindSweeperLogic = new MineSweeperLogic(myGraphics, this, player, level);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainWindow.Show();
        }
    }
}
