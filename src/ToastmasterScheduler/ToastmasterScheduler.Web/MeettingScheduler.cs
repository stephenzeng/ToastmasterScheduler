using System;
using System.Collections.Generic;
using System.Linq;
using Raven.Client;
using ToastmasterScheduler.Domain;

namespace ToastmasterScheduler.Web
{
    public class MeettingScheduler
    {
        private readonly IDocumentSession _session;

        public MeettingScheduler(IDocumentSession session)
        {
            _session = session;
        }

        public Meeting Initialize(MeetingTemplate meetingTemplate, DateTime dateTime)
        {
            var meeting = new Meeting
            {
                DateTime = dateTime,
                Items = new List<MeetingItem>(),
            };

            foreach (var meetingItem in meetingTemplate.Items)
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

        public void FillVacancies(Meeting meeting)
        {
            //todo:use index
            var vacancies = meeting.Items.Where(r => r.Member == null);
            var members = _session.Query<Member>().ToArray();

            var historicMemberIds = from m in _session.Query<Meeting>().ToArray()
                from i in m.Items
                select i.Member.Id;

            var historicCounts = from id in historicMemberIds
                group id by id into g
                select new
                {
                    Id = g.Key,
                    Count = g.Count()
                };

            foreach (var vacancy in vacancies)
            {
                var unassignedMembers = members.Where(m => meeting.Items.All(r => r.Member != m));

                var combinedCounts =
                    from m in unassignedMembers
                    join h in historicCounts on m.Id equals h.Id into memberGroup
                    from item in memberGroup.DefaultIfEmpty(new {m.Id, Count = 0})
                    select new
                    {
                        Member = m,
                        item.Count
                    };

                var orderedCounts = combinedCounts.OrderBy(m => m.Count)
                    .ThenBy(m => m.Member.JoinClubDate)
                    .ThenBy(m => m.Member.Surname)
                    .ThenBy(m => m.Member.GivenName);

                vacancy.Member = orderedCounts.First().Member;
            }
        }
    }
}