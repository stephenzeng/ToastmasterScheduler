using System;
using System.Collections.Generic;
using System.Linq;

namespace ToastmasterScheduler.Domain
{
    public class MeettingScheduler
    {
        private readonly MeetingTemplate _meetingTemplate;
        private readonly DateTime _dateTime;
        private readonly IEnumerable<Member> _members;
        private readonly IEnumerable<Meeting> _historicMeetings = Enumerable.Empty<Meeting>(); 

        public MeettingScheduler(MeetingTemplate meetingTemplate, DateTime dateTime, IEnumerable<Member> members)
        {
            _meetingTemplate = meetingTemplate;
            _dateTime = dateTime;
            _members = members;
        }

        public Meeting Initialize()
        {
            var meeting = new Meeting
            {
                DateTime = _dateTime,
                Items = new List<MeetingItem>(),
            };

            foreach (var meetingItem in _meetingTemplate.Items)
            {
                var item = new MeetingItem
                {
                    Description = meetingItem.Role.Description,
                    Role = meetingItem.Role,
                    StartTime = meetingItem.StartTime,
                    MinTime = meetingItem.MinTime,
                    MedTime = meetingItem.MedTime,
                    MaxTime = meetingItem.MaxTime,
                    Member = meetingItem.Member,
                };

                meeting.Items.Add(item);
            }
            
            return meeting;
        }

        private void ArrangeRoles(IEnumerable<MeetingItem> meetingRoles)
        {
            var unassignedRoles = meetingRoles.Where(r => r.Member == null);

            foreach (var role in unassignedRoles)
            {
                //var roleType = role.Type;
                var unassignedMembers = _members.Where(m => meetingRoles.All(r => r.Member != m));
                var historicRoleCounts =
                    from r in _historicMeetings.SelectMany(m => m.Items)
                    //where r.Type == roleType
                    group r by r.Member
                    into g
                    select new
                    {
                        Member = g.Key,
                        Count = g.Count()
                    };

                var combinedRoleCounts = 
                    from m in unassignedMembers
                    join h in historicRoleCounts on m equals h.Member into memberGroup
                    from item in memberGroup.DefaultIfEmpty(new {Member = m, Count = 0})
                    select new
                    {
                        Member = m,
                        Count = item.Count
                    };

                role.Member = combinedRoleCounts.OrderBy(m => m.Count)
                    .ThenBy(m => m.Member.JoinClubDate)
                    .ThenBy(m => m.Member.Surname)
                    .ThenBy(m => m.Member.GivenName)
                    .First()
                    .Member;
            }
        }
    }
}