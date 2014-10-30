using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToastmasterScheduler.Domain
{
    public class Member
    {
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public DateTime JoinClubDate { get; set; }
    }
}
