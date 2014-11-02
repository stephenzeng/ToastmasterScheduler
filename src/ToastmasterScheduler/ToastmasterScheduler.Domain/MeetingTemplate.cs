using System.Collections.Generic;

namespace ToastmasterScheduler.Domain
{
    public class MeetingTemplate : EntityBase
    {
        public string Name { get; set; }
        public IList<MeetingItem> Items { get; set; }
        public bool Enabled { get; set; }
    }
}