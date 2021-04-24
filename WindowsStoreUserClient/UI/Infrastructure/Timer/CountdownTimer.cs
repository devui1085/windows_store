using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace WindowsStore.Client.User.UI.Infrastructure.Timer
{
    public class CountdownTimer
    {
        DispatcherTimer _timer;
        public Action<object> Action { set; get; }
        public object ActionParameter { set; get; }

        public CountdownTimer(Action<object> action, object actionParameter, uint milliseconds)
        {
            Action = action;
            ActionParameter = actionParameter;
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(milliseconds);
            _timer.Tick += timer_Tick;
        }
        public CountdownTimer(uint milliseconds)
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(milliseconds);
            _timer.Tick += timer_Tick;
        }


        public void Start()
        {
            if (Action == null) throw new InvalidOperationException("Action delegate is null");
            _timer.Start();
        }

        private void timer_Tick(object sender, object e)
        {
            _timer.Stop();
            Action(ActionParameter);
        }
    }
}
