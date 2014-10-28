using System;
using System.Collections.Generic;

namespace ToastmasterScheduler.Domain
{
    public class Meeting
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public IList<MeetingRole> Roles { get; set; }
    }
}