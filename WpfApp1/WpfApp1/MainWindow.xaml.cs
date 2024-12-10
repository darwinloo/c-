using System;
using System.Timers;
using System.Windows;

namespace TimerApp
{
    public partial class MainWindow : Window
    {
        private Timer _timer;
        private int _remainingMinutes = 90; 

        public MainWindow()
        {
            InitializeComponent();
            StartTimer();
        }

        private void StartTimer()
        {
            _timer = new Timer(300000); 
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
            ShowTime();
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if (_remainingMinutes > 0)
            {
                _remainingMinutes -= 5; 
                ShowTime();
            }
            else
            {
                _timer.Stop();
                Dispatcher.Invoke(() => TimerTextBlock.Text = "Занятие завершено!");
            }
        }

        private void ShowTime()
        {
            Dispatcher.Invoke(() =>
            {
                TimerTextBlock.Text = $"До конца занятия осталось {_remainingMinutes} минут.";
            });
        }
    }
}