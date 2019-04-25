using System;
using System.IO;
using System.Collections.Generic;

namespace MineSweeper
{
    class MyFile
    {
        private FileStream fileStream;
        private int score;
        private String player;
        private String filePath;
        private int numberOfLineForChange;
        private List<String> linesFromFile;
        private String result;

        public MyFile(int score, String player, String filePath)
        {
            this.score = score;
            this.player = player;
            this.filePath = filePath;
            numberOfLineForChange = -1;
        }

        public void insertScoreIntoFile()
        {
            result = player + "\t\t~\t\t" + score;
            if (checkNumberOfLinesInFile())
            {
                fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write);
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine(result);
                streamWriter.Flush();
                streamWriter.Close();
                fileStream.Dispose();
            }
            else
            {
                checkIfSomeScoreInFileAreSmallerThanNewScore();
                if(numberOfLineForChange > -1)
                {
                    changeSmallestScoreInFile();
                }
            }
        }

        private bool checkNumberOfLinesInFile()
        {
            return (File.ReadAllLines(filePath).Length < 10) ? true : false;
        }

        private void checkIfSomeScoreInFileAreSmallerThanNewScore()
        {
            String line;
            linesFromFile = new List<String>();
            int smallestScore = score;
            int numberOfLines = 0;

            fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream);
            while ((line = streamReader.ReadLine()) != null)
            {
                if(line != "")
                {
                    linesFromFile.Add(line);
                    String[] tokens = line.Split('~');
                    if (Int32.Parse(tokens[1]) < smallestScore)
                    {
                        smallestScore = Int32.Parse(tokens[1]);
                        numberOfLineForChange = numberOfLines;
                    }
                    numberOfLines++;
                }                
            }
            streamReader.Close();
            fileStream.Dispose();
        }

        private void changeSmallestScoreInFile()
        {
            fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            linesFromFile[numberOfLineForChange] = result;
            foreach (String line in linesFromFile)
            {
                streamWriter.WriteLine(line);
            }
            streamWriter.Flush();
            streamWriter.Close();
            fileStream.Dispose();
        }
    }
}
