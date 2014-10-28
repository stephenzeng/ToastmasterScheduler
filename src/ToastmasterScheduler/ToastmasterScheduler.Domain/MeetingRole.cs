using System;
using System.ComponentModel.DataAnnotations;

namespace ToastmasterScheduler.Domain
{
    public class MeetingRole
    {
        public string Title { get; set; }
        public RoleTypes Type { get; set; }
        public Member Member { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan MinTime { get; set; }
        public TimeSpan MedTime { get; set; }
        public TimeSpan MaxTime { get; set; }
    }
}