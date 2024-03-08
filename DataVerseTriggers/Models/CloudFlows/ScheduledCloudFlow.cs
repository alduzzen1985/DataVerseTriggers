using System;
using System.ComponentModel;
using System.Linq;

namespace DataVerseTrigger.Models
{
    public class ScheduledCloudFlow : CommonAutomation
    {


        private string frequency;
        private int interval;
        private DateTime startTime;
        private string timeZone;
        private string[] weekDays;
        private int[] hours;
        private int[] minutes;


        private string weekDaysDescription;
        private string hoursDescription;
        private string minutesDescription;

        [Browsable(true)]                         
        [ReadOnly(true)]                          
        [Description("")]            
        [Category("Scheduling")]                 
        [DisplayName("Frequency")]
        public string Frequency { get => frequency; set => frequency = value; }
        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Scheduling")]
        [DisplayName("Interval")]
        public int Interval { get => interval; set => interval = value; }
        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Scheduling")]
        [DisplayName("Start time")]
        public DateTime StartTime { get => startTime; set => startTime = value; }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Scheduling")]
        [DisplayName("TimeZone")]
        public string TimeZone { get => timeZone; set => timeZone = value; }

        [Browsable(false)]
        public string[] WeekDays
        {
            get => weekDays; set
            {
                weekDays = value;
                weekDaysDescription = string.Join(",", value);
            }
        }
        [Browsable(false)]
        public int[] Hours
        {
            get => hours; set
            {

                hours = value;
                hoursDescription = string.Join(",", value.Select(x => x.ToString()).ToArray());
            }
        }
        [Browsable(false)]
        public int[] Minutes
        {
            get => minutes; set
            {
                minutes = value;
                minutesDescription = string.Join(",", value.Select(x => x.ToString()).ToArray());
            }
        }


        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Scheduling")]
        [DisplayName("Week Days")]
        public string WeekDaysDescription { get => weekDaysDescription; set => weekDaysDescription = value; }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Scheduling")]
        [DisplayName("Hours")]
        public string HoursDescription { get => hoursDescription; set => hoursDescription = value; }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Scheduling")]
        [DisplayName("Minutes")]
        public string MinutesDescription { get => minutesDescription; set => minutesDescription = value; }

    }
}
