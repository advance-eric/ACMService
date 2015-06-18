using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using ACMService.Helpers;
using System.Timers;

namespace ACMService
{
    public partial class ACMService : ServiceBase
    {
        DateTime curDate = new DateTime();
        bool exitFlag = false;
       
        public ACMService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            Timer timedEvent = new Timer((int)System.TimeSpan.FromMinutes(1).TotalMilliseconds);
            timedEvent.Elapsed += TimerEvent;
            timedEvent.Enabled = true;

        }

        protected override void OnStop()
        {
        }
        public void OnDebug()
        {
            OnStart(null);
        }



        public void TimerEvent(Object myObject, ElapsedEventArgs e)
        {
            if (TimeCheck(12, 03, curDate))
            {
                EmailHelper.SendEmail(new List<string> { "bryan.stackpole@advancenational.com.au" }, "8am", "This is an email to say that I should be in today unless something terrible happens");
                curDate = DateTime.Now;
                exitFlag = false;
            }
        
        }
        
        public bool TimeCheck(int hour, int minute, DateTime dateCheck)
        {
            if (DateTime.Now.TimeOfDay > new TimeSpan(hour, minute, 0) && DateTime.Now.TimeOfDay < new TimeSpan(hour, minute + 1, 0) && DateTime.Now.Day != dateCheck.Day)
            {
                return true;
            }
            return false;

        }
    }
}
