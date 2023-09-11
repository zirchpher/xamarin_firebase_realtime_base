using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Model
{
    public class Reminder
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string creation_date { get; set; }
        public string reminder_date { get; set; }
        public string reminder_time { get; set; }
    }
}
