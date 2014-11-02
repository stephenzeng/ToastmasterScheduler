using System;

namespace ToastmasterScheduler.Domain
{
    public class MeetingItem
    {
        public string Description { get; set; }
        public Role Role { get; set; }
        public Member Member { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan MinTime { get; set; }
        public TimeSpan MedTime { get; set; }
        public TimeSpan MaxTime { get; set; }
    }
}