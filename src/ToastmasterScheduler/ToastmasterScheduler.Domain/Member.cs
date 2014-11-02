using System;

namespace ToastmasterScheduler.Domain
{
    public class Member : EntityBase
    {
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public DateTime JoinClubDate { get; set; }
    }
}
