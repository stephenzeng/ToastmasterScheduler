using System;
using System.Web.Mvc;
using Raven.Abstractions.Extensions;
using ToastmasterScheduler.Domain;

namespace ToastmasterScheduler.Web.Controllers
{
    public class SeedController : ControllerBase
    {
        private Role[] _roles;

        public ActionResult Index()
        {
            SeedMembers();
            SeedRoles();
            SeedMeetingTemplate();

            return View();
        }

        private void SeedRoles()
        {
            _roles = new[]
            {
                new Role {Description = "Set Up, Complete Manuals", OrderIndex = 0},
                new Role {Description = "Sergeant at Arms", OrderIndex = 1},
                new Role {Description = "Toastmaster Introduction of Guests", OrderIndex = 2},
                new Role {Description = "New Member Induction", OrderIndex = 3},
                new Role {Description = "Grammarian", OrderIndex = 4},
                new Role {Description = "Inspiration", OrderIndex = 5},
                new Role {Description = "Project Speech", OrderIndex = 6},
                new Role {Description = "Evaluator", OrderIndex = 7},
                new Role {Description = "Table Topics Master", OrderIndex = 8},
                new Role {Description = "Tonic", OrderIndex = 9},
                new Role {Description = "Table Topics Evaluator", OrderIndex = 10},
                new Role {Description = "BREAK - PLEASE BRING SNACKS", OrderIndex = 11},
                new Role {Description = "Tall Tales", OrderIndex = 12},
                new Role {Description = "Evaluate Evaluators", OrderIndex = 13},
                new Role {Description = "Timer", OrderIndex = 14},
                new Role {Description = "General Evaluation", OrderIndex = 15},
                new Role {Description = "Close", OrderIndex = 16},
            };

            _roles.ForEach(DocumentSession.Store);
        }

        private void SeedMembers()
        {
            var members = new[]
            {
                new Member {GivenName = "Stephen", Surname = "Zeng", JoinClubDate = new DateTime(2014, 8, 15)},
                new Member {GivenName = "Tom", Surname = "Bielski", JoinClubDate = new DateTime(2010, 10, 15)},
                new Member {GivenName = "Rajiv", Surname = "Kapur", JoinClubDate = new DateTime(2011, 8, 15)},
                new Member {GivenName = "Keith", Surname = "Green", JoinClubDate = new DateTime(2003, 8, 15)},
                new Member {GivenName = "Erin", Surname = "Monaghan", JoinClubDate = new DateTime(2014, 8, 15)},
                new Member {GivenName = "Jill", Surname = "Kadota", JoinClubDate = new DateTime(2008, 12, 15)},
                new Member {GivenName = "Simon", Surname = "Yamchikov", JoinClubDate = new DateTime(2013, 11, 15)},
                new Member {GivenName = "Ian", Surname = "Atkins", JoinClubDate = new DateTime(2013, 8, 2)},
                new Member {GivenName = "Dario", Surname = "Brozovic", JoinClubDate = new DateTime(2004, 7, 15)},
                new Member {GivenName = "Adrian", Surname = "Nathan", JoinClubDate = new DateTime(2010, 8, 14)},
                new Member {GivenName = "Lisa", Surname = "Kurniawati", JoinClubDate = new DateTime(2014, 8, 19)},
                new Member {GivenName = "Peter", Surname = "Passalacqua", JoinClubDate = new DateTime(2012, 8, 5)},
                new Member {GivenName = "David", Surname = "Wong", JoinClubDate = new DateTime(2012, 8, 5)},
                new Member {GivenName = "Sawan", Surname = "Tanna", JoinClubDate = new DateTime(2012, 8, 5)},
                new Member {GivenName = "Mina", Surname = "Cho", JoinClubDate = new DateTime(2012, 8, 5)},
            };

            members.ForEach(DocumentSession.Store);
        }

        private void SeedMeetingTemplate()
        {
            var template = new MeetingTemplate
            {
                Name = "Test meeting template",
                Enabled = true,
                Items = new[]
                {
                    new MeetingItem
                    {
                        Role = _roles[0],
                        Description = _roles[0].Description,
                        StartTime = new TimeSpan(18, 15, 0),
                        MinTime = new TimeSpan(0, 0, 10),
                        MedTime = new TimeSpan(0, 0, 12, 30),
                        MaxTime = new TimeSpan(0, 0, 15)
                    },
                    new MeetingItem
                    {
                        Role = _roles[1],
                        Description = _roles[1].Description,
                        StartTime = new TimeSpan(18, 30, 0),
                        MinTime = new TimeSpan(0, 0, 0, 30),
                        MedTime = new TimeSpan(0, 0, 0, 45),
                        MaxTime = new TimeSpan(0, 0, 1)
                    },
                    new MeetingItem
                    {
                        Role = _roles[2],
                        Description = _roles[2].Description,
                        StartTime = new TimeSpan(18, 31, 0),
                        MinTime = new TimeSpan(0, 0, 2),
                        MedTime = new TimeSpan(0, 0, 2, 30),
                        MaxTime = new TimeSpan(0, 0, 3)
                    },
                    new MeetingItem
                    {
                        Role = _roles[3],
                        Description = _roles[3].Description,
                        StartTime = new TimeSpan(18, 35, 0),
                        MinTime = new TimeSpan(0, 0, 1),
                        MedTime = new TimeSpan(0, 0, 1, 30),
                        MaxTime = new TimeSpan(0, 0, 2)
                    },
                    new MeetingItem
                    {
                        Role = _roles[4],
                        Description = _roles[4].Description,
                        StartTime = new TimeSpan(18, 38, 0),
                        MinTime = new TimeSpan(0, 0, 1),
                        MedTime = new TimeSpan(0, 0, 1, 30),
                        MaxTime = new TimeSpan(0, 0, 2)
                    },
                    new MeetingItem
                    {
                        Role = _roles[5],
                        Description = _roles[5].Description,
                        StartTime = new TimeSpan(18, 41, 0),
                        MinTime = new TimeSpan(0, 0, 1),
                        MedTime = new TimeSpan(0, 0, 1, 30),
                        MaxTime = new TimeSpan(0, 0, 2)
                    },
                    new MeetingItem
                    {
                        Role = _roles[6],
                        Description = _roles[6].Description,
                        StartTime = new TimeSpan(18, 44, 0),
                        MinTime = new TimeSpan(0, 0, 5),
                        MedTime = new TimeSpan(0, 0, 6),
                        MaxTime = new TimeSpan(0, 0, 7)
                    },
                    new MeetingItem
                    {
                        Role = _roles[7],
                        Description = _roles[7].Description,
                        StartTime = new TimeSpan(18, 52, 0),
                        MinTime = new TimeSpan(0, 0, 2),
                        MedTime = new TimeSpan(0, 0, 2, 30),
                        MaxTime = new TimeSpan(0, 0, 3)
                    },
                    new MeetingItem
                    {
                        Role = _roles[6],
                        Description = _roles[8].Description,
                        StartTime = new TimeSpan(18, 56, 0),
                        MinTime = new TimeSpan(0, 0, 5),
                        MedTime = new TimeSpan(0, 0, 6),
                        MaxTime = new TimeSpan(0, 0, 7)
                    },
                    new MeetingItem
                    {
                        Role = _roles[7],
                        Description = _roles[0].Description,
                        StartTime = new TimeSpan(19, 4, 0),
                        MinTime = new TimeSpan(0, 0, 2),
                        MedTime = new TimeSpan(0, 0, 2, 30),
                        MaxTime = new TimeSpan(0, 0, 3)
                    },
                    new MeetingItem
                    {
                        Role = _roles[8],
                        Description = _roles[8].Description,
                        StartTime = new TimeSpan(19, 8, 0),
                        MinTime = new TimeSpan(0, 0, 8),
                        MedTime = new TimeSpan(0, 0, 9),
                        MaxTime = new TimeSpan(0, 0, 10)
                    },
                    new MeetingItem
                    {
                        Role = _roles[9],
                        Description = _roles[9].Description,
                        StartTime = new TimeSpan(19, 19, 0),
                        MinTime = new TimeSpan(0, 0, 0, 30),
                        MedTime = new TimeSpan(0, 0, 0, 45),
                        MaxTime = new TimeSpan(0, 0, 1)
                    },
                    new MeetingItem
                    {
                        Role = _roles[10],
                        Description = _roles[10].Description,
                        StartTime = new TimeSpan(19, 21, 0),
                        MinTime = new TimeSpan(0, 0, 4),
                        MedTime = new TimeSpan(0, 0, 5),
                        MaxTime = new TimeSpan(0, 0, 6)
                    },
                },
            };

            DocumentSession.Store(template);
        }
    }
}