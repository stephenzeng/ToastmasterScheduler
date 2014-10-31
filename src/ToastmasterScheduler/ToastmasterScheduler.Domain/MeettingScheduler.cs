using System;
using System.Collections.Generic;
using System.Linq;

namespace ToastmasterScheduler.Domain
{
    public class MeettingScheduler
    {
        private readonly Meeting _meetingTemplate;
        private readonly DateTime _dateTime;
        private readonly IEnumerable<Member> _members;
        private readonly IEnumerable<Meeting> _historicMeetings = Enumerable.Empty<Meeting>(); 

        public MeettingScheduler(Meeting meetingTemplate, DateTime dateTime, IEnumerable<Member> members)
        {
            _meetingTemplate = meetingTemplate;
            _dateTime = dateTime;
            _members = members;
            _historicMeetings = new[]
            {
                new Meeting
                {
                    DateTime = DateTime.Now.AddDays(-7),
                    Roles = new[]
                    {
                        new MeetingRole
                        {
                            Title = "Setup",
                            Type = RoleTypes.Setup,
                        },
                        new MeetingRole
                        {
                            Title = "Sergeant at Arms",
                            Type = RoleTypes.SergeantAtArms,
                            Member = _members.Single(m => m.GivenName == "Stephen")
                        },
                        new MeetingRole
                        {
                            Title = "Introduction of Guests",
                            Type = RoleTypes.GuestIntroduction,
                            Member = _members.Single(m => m.GivenName == "Tom")
                        },
                        new MeetingRole
                        {
                            Title = "New Member Induction",
                            Type = RoleTypes.NewMemberInduction,
                            Member = _members.Single(m => m.GivenName == "Keith" && m.Surname == "Green"),
                        },
                        new MeetingRole
                        {
                            Title = "Grammarian",
                            Type = RoleTypes.Grammarian,
                            Member = _members.Single(m => m.GivenName == "Jill")
                        },
                    }
                }
            };
        }

        public Meeting Arrange()
        {
            var meeting = new Meeting
            {
                DateTime = _dateTime,
                Roles = new List<MeetingRole>(),
            };

            foreach (var r in _meetingTemplate.Roles)
            {
                var role = new MeetingRole
                {
                    StartTime = r.StartTime,
                    MinTime = r.MinTime,
                    MedTime = r.MedTime,
                    MaxTime = r.MaxTime,
                    Type = r.Type,
                    Member = r.Member,
                };

                meeting.Roles.Add(role);
            }

            ArrangeRoles(meeting.Roles);

            return meeting;
        }

        private void ArrangeRoles(IEnumerable<MeetingRole> meetingRoles)
        {
            var unassignedRoles = meetingRoles.Where(r => r.Member == null);

            foreach (var role in unassignedRoles)
            {
                var roleType = role.Type;
                var unassignedMembers = _members.Where(m => meetingRoles.All(r => r.Member != m));
                var historicRoleCounts =
                    from r in _historicMeetings.SelectMany(m => m.Roles)
                    where r.Type == roleType
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