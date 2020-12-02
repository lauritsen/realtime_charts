using System;
using System.Threading;

namespace RealTimeChartsServer.TimerFeatures
{
    public class TimerManager
    {
        private Timer _timer;
        private AutoResetEvent _autoResetEvent;
        private Action _action;

        public DateTime TimerStarted { get; }

        public TimerManager(Action action)
        {
            _action = action;
            _autoResetEvent = new AutoResetEvent(false);
            _timer = new Timer(Execute, _autoResetEvent, 1000, 2000);
            TimerStarted = DateTime.UtcNow;
        }

        public void Execute(object state)
        {
            _action();

            if((DateTime.UtcNow - TimerStarted).Seconds > 60)
            {
                _timer.Dispose();
            }
        }
    }
}
