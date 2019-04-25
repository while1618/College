using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace MineSweeper
{
    class MineSweeperLogic
    {
        private int numberOfMines;
        private int numberOfColumns;
        private int numberOfRows;
        private Button[,] buttons;
        private Label labelMines;
        private ImageBrush flagBrush;
        private Label labelTime;
        private Button smileButton;
        private ImageBrush mineBrush;
        private ImageBrush redMineBrush;
        private int originalNumberOfMines;
        private bool firstTimeButtonClicked;
        private int adjacentFields;
        private TimeThread timeThread;
        private int score;
        private String filePath;
        private Window levelWindow;
        private String level;
        private String player;

        public MineSweeperLogic(MyGraphics myGraphics, Window levelWindow, String player, String level)
        {
            numberOfMines = myGraphics.getNumberOfMines();
            numberOfColumns = myGraphics.getNumberOfColumns();
            numberOfRows = myGraphics.getNumberOfRows();
            buttons = myGraphics.getButtons();
            labelMines = myGraphics.getLabelMines();
            flagBrush = myGraphics.getFlagBrush();
            labelTime = myGraphics.getLabelTime();
            smileButton = myGraphics.getSmileButton();
            mineBrush = myGraphics.getMineBrush();
            redMineBrush = myGraphics.getRedMineBrush();
            originalNumberOfMines = myGraphics.getOriginalNumberOfMines();

            this.player = player;
            this.level = level;
            this.levelWindow = levelWindow;
            adjacentFields = 0;
            firstTimeButtonClicked = true;

            createOnClickEventForSmileButton();
            createMines();
            numberOfMinesSurroundingButton();
            createOnClickEvent();
        }

        private void createOnClickEventForSmileButton()
        {
            smileButton.Click += smileButton_Click;
        }

        private void smileButton_Click(object sender, EventArgs e)
        {
            resetNumberOfMines();
            resetButtons();
            resetTime();
            createMines();
            numberOfMinesSurroundingButton();
        }

        public void resetNumberOfMines()
        {
            this.numberOfMines = originalNumberOfMines;
            labelMines.Content = originalNumberOfMines;
        }

        public void resetButtons()
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    buttons[i, j].Uid = "";
                    buttons[i, j].Content = "";
                    buttons[i, j].IsEnabled = true;
                    buttons[i, j].IsHitTestVisible = true;
                    buttons[i, j].ClearValue(Button.BackgroundProperty);
                }
            }
        }

        public void resetTime()
        {
            if (timeThread != null)
            {
                timeThread.stopTimer();
            }
            firstTimeButtonClicked = true;
            labelTime.Content = 0;
        }

        public void createMines()
        {
            Random random = new Random();
            for (int i = 0; i < numberOfMines; i++)
            {
                int column = random.Next(0, numberOfColumns);
                int row = random.Next(0, numberOfRows);
                do
                {
                    column = random.Next(0, numberOfColumns);
                    row = random.Next(0, numberOfRows);
                } while (buttons[row, column].Uid.Equals("*"));
                buttons[row, column].Uid = "*";
            }
        }

        public void numberOfMinesSurroundingButton()
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    if (!buttons[i, j].Uid.Equals("*"))
                    {
                        checkAdjacentFields(i, j);
                        if (adjacentFields > 0)
                        {
                            buttons[i, j].Uid = adjacentFields.ToString();
                        }
                        adjacentFields = 0;
                    }
                }
            }
        }

        private void checkAdjacentFields(int column, int row)
        {
            checkRight(column, row);
            checkLeft(column, row);
            checkUp(column, row);
            checkDown(column, row);
            checkNorthEast(column, row);
            checkNorthWest(column, row);
            checkSouthEast(column, row);
            checkSouthWest(column, row);
        }

        private void createOnClickEvent()
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    buttons[i, j].MouseDown += right_Click;
                    buttons[i, j].Click += left_Click;
                }
            }
        }

        private void right_Click(object sender, MouseEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
            {
                tryToStartThread();                
                Button button = (Button)sender;
                if (button.Background.Equals(flagBrush))
                {
                    button.ClearValue(Button.BackgroundProperty);
                    numberOfMines++;
                    labelMines.Content = numberOfMines;
                }
                else
                {                    
                    button.Background = flagBrush;
                    numberOfMines--;
                    labelMines.Content = numberOfMines;
                }
            }
        }        

        private void left_Click(object sender, EventArgs e)
        {
            tryToStartThread();
            int column = Grid.GetColumn((Button)sender);
            int row = Grid.GetRow((Button)sender);
            checkFields(column, row);
            if(win())
            {
                timeThread.stopTimer();
                showAllFlags();
                disableButtons();
                calculateScore();
                createFilePath();
                MyFile myFile = new MyFile(score, player, filePath);
                myFile.insertScoreIntoFile();
                startAnimation();
            }
        }

        private void tryToStartThread()
        {
            if (firstTimeButtonClicked)
            {
                this.timeThread = new TimeThread(this.labelTime);
                timeThread.run();
                firstTimeButtonClicked = false;
            }
        }

        private void checkFields(int column, int row)
        {
            if(checkColumnAndRow(column, row))
            {
                if (!chechIfButtonIsFlagged(buttons[row, column]))
                {
                    if (!checkifButtonAlreadyChecked(buttons[row, column]))
                    {
                        int n;
                        if (int.TryParse(buttons[row, column].Uid.ToString(), out n))
                        {
                            buttonWithNumberOfMines(buttons[row, column], n);
                        }
                        else if (buttons[row, column].Uid.Equals("*"))
                        {
                            buttonWithMine(buttons[row, column]);
                        }
                        else {
                            emptyButton(column, row);
                        }
                    }
                }
            }
        }

        private bool checkColumnAndRow(int column, int row)
        {
            return (column >= 0 && column < numberOfColumns && row >= 0 && row < numberOfRows) ? true : false;
        }

        private bool chechIfButtonIsFlagged(Button button)
        {
            return (button.Background.Equals(flagBrush)) ? true : false;
        }

        private bool checkifButtonAlreadyChecked(Button button)
        {
            return (button.Uid.Equals("checked")) ? true : false;
        }

        private void buttonWithNumberOfMines(Button button, int numberOfMinesSurrounding)
        {
            button.Content = numberOfMinesSurrounding;
            button.FontSize = 16;
            button.Uid = "checked";
            MyGraphics.colorText(numberOfMinesSurrounding, button);
            button.IsEnabled = false;
        }

        private void buttonWithMine(Button button)
        {
            timeThread.stopTimer();
            showAllMines();
            disableButtons();
            button.Background = redMineBrush;
        }

        private void showAllMines()
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    if (buttons[i, j].Uid.Equals("*"))
                    {
                        buttons[i, j].Background = mineBrush;
                    }
                }
            }
        }

        private void disableButtons()
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    buttons[i, j].IsHitTestVisible = false;
                }
            }
        }        

        private void emptyButton(int column, int row)
        {
            buttons[row, column].Uid = "checked";
            buttons[row, column].IsEnabled = false;

            callRecursion(column, row);
        }

        private void callRecursion(int column, int row)
        {
            checkFields(column + 1, row);
            checkFields(column, row + 1);
            checkFields(column - 1, row);
            checkFields(column, row - 1);

            checkFields(column - 1, row - 1);
            checkFields(column + 1, row - 1);
            checkFields(column - 1, row + 1);
            checkFields(column + 1, row + 1);
        }

        private bool win()
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    if (!buttons[i, j].Uid.Equals("checked") && !buttons[i, j].Uid.Equals("*"))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void showAllFlags()
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    if (buttons[i, j].Uid.Equals("*"))
                    {
                        buttons[i, j].Background = flagBrush;
                    }
                }
            }
        }

        private void calculateScore()
        {
            int maxScore = 300;
            this.score = maxScore - Int32.Parse(this.labelTime.Content.ToString());
        }

        private void createFilePath()
        {
            filePath = "../../files/" + level + ".txt";
        }

        private void startAnimation()
        {
            Storyboard sb = levelWindow.FindResource("Storyboard1") as Storyboard;
            Storyboard.SetTarget(sb, this.smileButton);
            sb.Begin();
        }

        private void checkRight(int column, int row)
        {
            if (checkColumnAndRow(column + 1, row))
            {
                if (buttons[column + 1, row].Uid.Equals("*"))
                {
                    adjacentFields++;
                }
            }
        }

        private void checkLeft(int column, int row)
        {
            if (checkColumnAndRow(column - 1, row))
            {
                if (buttons[column - 1, row].Uid.Equals("*"))
                {
                    adjacentFields++;
                }
            }
        }

        private void checkUp(int column, int row)
        {
            if (checkColumnAndRow(column, row - 1))
            {
                if (buttons[column, row - 1].Uid.Equals("*"))
                {
                    adjacentFields++;
                }
            }
        }

        private void checkDown(int column, int row)
        {
            if (checkColumnAndRow(column, row + 1))
            {
                if (buttons[column, row + 1].Uid.Equals("*"))
                {
                    adjacentFields++;
                }
            }
        }

        private void checkNorthWest(int column, int row)
        {
            if (checkColumnAndRow(column - 1, row - 1))
            {
                if (buttons[column - 1, row - 1].Uid.Equals("*"))
                {
                    adjacentFields++;
                }
            }
        }

        private void checkNorthEast(int column, int row)
        {
            if (checkColumnAndRow(column + 1, row - 1))
            {
                if (buttons[column + 1, row - 1].Uid.Equals("*"))
                {
                    adjacentFields++;
                }
            }
        }

        private void checkSouthWest(int column, int row)
        {
            if (checkColumnAndRow(column - 1, row + 1))
            {
                if (buttons[column - 1, row + 1].Uid.Equals("*"))
                {
                    adjacentFields++;
                }
            }
        }

        private void checkSouthEast(int column, int row)
        {
            if (checkColumnAndRow(column + 1, row + 1))
            {
                if (buttons[column + 1, row + 1].Uid.Equals("*"))
                {
                    adjacentFields++;
                }
            }
        }             
    }
}