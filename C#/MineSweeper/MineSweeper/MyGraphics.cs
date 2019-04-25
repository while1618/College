using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Documents;

namespace MineSweeper
{
    class MyGraphics
    {
        private Button smileButton;
        private Button[,] buttons;
        private int originalNumberOfMines;
        private int numberOfMines;
        private int numberOfRows;
        private int numberOfColumns;
        private ImageBrush redMineBrush;
        private Image smileImage;
        private ImageBrush flagBrush;
        private ImageBrush mineBrush;
        private Grid grid;
        private Label labelTime;
        private Label labelMine;

        public MyGraphics(int numberOfMines, int numberOfRows, int numberOfColumns, Button smileButton, Label labelTime, Label labelMine, Grid grid)
        {            
            this.numberOfMines = numberOfMines;
            this.numberOfRows = numberOfRows;
            this.numberOfColumns = numberOfColumns;
            this.grid = grid;
            this.originalNumberOfMines = numberOfMines;
            buttons = new Button[numberOfColumns, numberOfRows];
            this.smileButton = smileButton;
            this.labelMine = labelMine;
            this.labelTime = labelTime;

            createFlagBrush();
            createMineBrush();
            createRedMineBrush();
            createSmileBrush();
            createButtons();
        }

        private void createFlagBrush()
        {
            flagBrush = new ImageBrush();
            flagBrush.ImageSource = new BitmapImage(new Uri(@"../../img/flag.png", UriKind.Relative));
            flagBrush.Stretch = Stretch.Uniform;
        }

        private void createMineBrush()
        {
            mineBrush = new ImageBrush();
            mineBrush.ImageSource = new BitmapImage(new Uri(@"../../img/mine.jpg", UriKind.Relative));
            mineBrush.Stretch = Stretch.Uniform;
        }

        private void createRedMineBrush()
        {
            redMineBrush = new ImageBrush();
            redMineBrush.ImageSource = new BitmapImage(new Uri(@"../../img/redMine.jpg", UriKind.Relative));
            redMineBrush.Stretch = Stretch.Uniform;
        }

        private void createSmileBrush()
        {
            BitmapImage bitimg = new BitmapImage();
            bitimg.BeginInit();
            bitimg.UriSource = new Uri(@"../../img/smile.png", UriKind.RelativeOrAbsolute);
            bitimg.EndInit();

            smileImage = new Image();
            smileImage.Stretch = Stretch.Uniform;
            smileImage.Source = bitimg;
        }

        private void createButtons()
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Uid = "";
                    buttons[i, j].Content = "";
                    Grid.SetRow(buttons[i, j], i);
                    Grid.SetColumn(buttons[i, j], j);
                    grid.Children.Add(buttons[i, j]);
                }
            }
        }

        public static void colorText(int numberOfMinesSurrounding, Button button)
        {
            ContentPresenter cp = button.Template.FindName("contentPresenter", button) as ContentPresenter;
            switch (numberOfMinesSurrounding)
            {
                case 1:
                    cp.SetValue(TextElement.ForegroundProperty, Brushes.Blue);
                    break;
                case 2:
                    cp.SetValue(TextElement.ForegroundProperty, Brushes.Green);
                    break;
                case 3:
                    cp.SetValue(TextElement.ForegroundProperty, Brushes.Red);
                    break;
                case 4:
                    cp.SetValue(TextElement.ForegroundProperty, Brushes.Purple);
                    break;
                case 5:
                    cp.SetValue(TextElement.ForegroundProperty, Brushes.Orange);
                    break;
                case 6:
                    cp.SetValue(TextElement.ForegroundProperty, Brushes.Green);
                    break;
                case 7:
                    cp.SetValue(TextElement.ForegroundProperty, Brushes.Red);
                    break;
                case 8:
                    cp.SetValue(TextElement.ForegroundProperty, Brushes.Red);
                    break;
            }
        }

        public Button[,] getButtons()
        {
            return buttons;
        }

        public int getNumberOfMines()
        {
            return numberOfMines;
        }

        public int getNumberOfRows()
        {
            return numberOfRows;
        }

        public int getNumberOfColumns()
        {
            return numberOfColumns;
        }

        public Label getLabelMines()
        {
            return labelMine;
        }

        public ImageBrush getFlagBrush()
        {
            return flagBrush;
        }

        public Label getLabelTime()
        {
            return labelTime;
        }

        public Button getSmileButton()
        {
            return smileButton;
        }

        public ImageBrush getMineBrush()
        {
            return mineBrush;
        }

        public ImageBrush getRedMineBrush()
        {
            return redMineBrush;
        }

        public int getOriginalNumberOfMines()
        {
            return originalNumberOfMines;
        }
    }
}
