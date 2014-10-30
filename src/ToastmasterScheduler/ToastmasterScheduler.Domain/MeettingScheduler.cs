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

        public MeettingScheduler(Meeting meetingTemplate, DateTime dateTime, IEnumerable<Member> members)
        {
            _meetingTemplate = meetingTemplate;
            _dateTime = dateTime;
            _members = members;
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
            var projectSpeechRoles = meetingRoles.Where(r => r.Member == null);

            foreach (var role in projectSpeechRoles)
            {
                var member = _members.Where(m => !meetingRoles.Select(mr => mr.Member).Contains(m))
                    .OrderBy(m => m.JoinClubDate)
                    .First();
                role.Member = member;
            }
        }
    }
}