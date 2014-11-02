using System;
using System.Collections.Generic;

namespace ToastmasterScheduler.Domain
{
    public class Meeting : EntityBase
    {
        public DateTime DateTime { get; set; }
        public IList<MeetingItem> Items { get; set; }
    }
}