using System;
using System.Windows;

namespace MineSweeper
{
    public partial class EasyWindow : Window
    {
        private MainWindow mainWindow;
        private int numberOfMines;
        private int numberOfRows;
        private int numberOfColumns;
        private String player;
        private String level;

        public EasyWindow(MainWindow mainWindow, String player)
        {
            InitializeComponent();            
            this.mainWindow = mainWindow;
            this.numberOfMines = 2;
            this.numberOfRows = 10;
            this.numberOfColumns = 10;
            labelMine.Content = numberOfMines;
            this.player = player;
            this.level = "easy";
            MyGraphics myGraphics = new MyGraphics(numberOfMines, numberOfRows, numberOfColumns, smileButton, labelTime, labelMine, grid);
            MineSweeperLogic mindSweeperLogic = new MineSweeperLogic(myGraphics, this, player, level);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainWindow.Show();
        }
    }
}
