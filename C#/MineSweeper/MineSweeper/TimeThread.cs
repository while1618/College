using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace MineSweeper
{
    class TimeThread
    {
        private int time;
        private Label timeLabel;
        private delegate void Updater(int UI);
        private bool work;
        private Updater uiUpdater;

        public TimeThread(Label timeLabel)
        {
            this.timeLabel = timeLabel;
            this.time = 0;
            this.work = true;
        }

        public void run()
        {
            new Thread(() =>
            {
                while(work)
                {                    
                    time++;
                    uiUpdater = new Updater(UpdateUI);
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, uiUpdater, time);
                    Thread.Sleep(1000);
                }
            }).Start();
        }

        private void UpdateUI(int time)
        {
            timeLabel.Content = time;
        }

        public void stopTimer()
        {
            this.work = false;
        }
    }
}
