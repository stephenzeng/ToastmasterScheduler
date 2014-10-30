using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ToastmasterScheduler.Domain.UnitTest
{
    /// <summary>
    /// The basic idea for arranging the members to each of the roles for a meeting is very simple. 
    /// 1. User defines a meeting template:
    ///    User adds the roles in the order. Roles can be repeated;
    ///    Roles can be assigned with Members by user;
    ///    User defines the meeting repeat pattern.
    /// 2. User askes the application to arrange the next meeting based on the template:
    ///    App copies the roles from the template;
    ///    App assigns the next meeting date based on the meeting repeat pattern;
    ///    App assigns the members to each of the unassigned roles based on statistics.
    /// 3. Users can edit the arranged meeting:
    ///    User can add extra roles or remove existing roles;
    ///    User can update the pre-filled role titles;
    ///    User can ask the app to re-assign all the roles with the members.
    /// 4. User can gernate the report or send notifications to all members by email.
    /// </summary>
    [TestFixture]
    public class toastmaster_sheduler
    {
        private Meeting _meetingTemplate;
        private Member[] _members;

        public toastmaster_sheduler()
        {
            SetupMembers();
            PredefineMeeting();
        }

        private void PredefineMeeting()
        {
            _meetingTemplate = new Meeting
            {
                Roles = new[]
                {
                    new MeetingRole
                    {
                        Title = "Setup",
                        Type = RoleTypes.Setup,
                        StartTime = new DateTime(2014, 11, 2, 18, 15, 0),
                        MinTime = new TimeSpan(0, 0, 10),
                        MedTime = new TimeSpan(0, 0, 12, 30),
                        MaxTime = new TimeSpan(0, 0, 15)
                    },
                    new MeetingRole
                    {
                        Title = "Sergeant at Arms",
                        Type = RoleTypes.SergeantAtArms,
                        StartTime = new DateTime(2014, 11, 2, 18, 30, 0),
                        MinTime = new TimeSpan(0, 0, 0, 30),
                        MedTime = new TimeSpan(0, 0, 0, 45),
                        MaxTime = new TimeSpan(0, 0, 1)
                    },
                    new MeetingRole
                    {
                        Title = "Introduction of Guests",
                        Type = RoleTypes.GuestIntroduction,
                        StartTime = new DateTime(2014, 11, 2, 18, 31, 0),
                        MinTime = new TimeSpan(0, 0, 2),
                        MedTime = new TimeSpan(0, 0, 2, 30),
                        MaxTime = new TimeSpan(0, 0, 3)
                    },
                    new MeetingRole
                    {
                        Title = "New Member Induction",
                        Type = RoleTypes.NewMemberInduction,
                        Member = _members.First(m => m.GivenName == "Keith" && m.Surname == "Green"),
                        StartTime = new DateTime(2014, 11, 2, 18, 35, 0),
                        MinTime = new TimeSpan(0, 0, 1),
                        MedTime = new TimeSpan(0, 0, 1, 30),
                        MaxTime = new TimeSpan(0, 0, 2)
                    },
                    new MeetingRole
                    {
                        Title = "Grammarian",
                        Type = RoleTypes.Grammarian,
                        StartTime = new DateTime(2014, 11, 2, 18, 38, 0),
                        MinTime = new TimeSpan(0, 0, 1),
                        MedTime = new TimeSpan(0, 0, 1, 30),
                        MaxTime = new TimeSpan(0, 0, 2)
                    },
                    new MeetingRole
                    {
                        Title = "Inspiration",
                        Type = RoleTypes.Inspiration,
                        StartTime = new DateTime(2014, 11, 2, 18, 41, 0),
                        MinTime = new TimeSpan(0, 0, 1),
                        MedTime = new TimeSpan(0, 0, 1, 30),
                        MaxTime = new TimeSpan(0, 0, 2)
                    },
                    new MeetingRole
                    {
                        Title = "Project speech",
                        Type = RoleTypes.ProjectSpeech,
                        StartTime = new DateTime(2014, 11, 2, 18, 44, 0),
                        MinTime = new TimeSpan(0, 0, 5),
                        MedTime = new TimeSpan(0, 0, 6),
                        MaxTime = new TimeSpan(0, 0, 7)
                    },
                    new MeetingRole
                    {
                        Title = "Evaluator",
                        Type = RoleTypes.Evaluator,
                        StartTime = new DateTime(2014, 11, 2, 18, 52, 0),
                        MinTime = new TimeSpan(0, 0, 2),
                        MedTime = new TimeSpan(0, 0, 2, 30),
                        MaxTime = new TimeSpan(0, 0, 3)
                    },
                    new MeetingRole
                    {
                        Title = "Project speech",
                        Type = RoleTypes.ProjectSpeech,
                        StartTime = new DateTime(2014, 11, 2, 18, 56, 0),
                        MinTime = new TimeSpan(0, 0, 5),
                        MedTime = new TimeSpan(0, 0, 6),
                        MaxTime = new TimeSpan(0, 0, 7)
                    },
                    new MeetingRole
                    {
                        Title = "Evaluator",
                        Type = RoleTypes.Evaluator,
                        StartTime = new DateTime(2014, 11, 2, 19, 4, 0),
                        MinTime = new TimeSpan(0, 0, 2),
                        MedTime = new TimeSpan(0, 0, 2, 30),
                        MaxTime = new TimeSpan(0, 0, 3)
                    },
                    new MeetingRole
                    {
                        Title = "Table Topics Master",
                        Type = RoleTypes.TableTopicsMaster,
                        StartTime = new DateTime(2014, 11, 2, 19, 8, 0),
                        MinTime = new TimeSpan(0, 0, 8),
                        MedTime = new TimeSpan(0, 0, 9),
                        MaxTime = new TimeSpan(0, 0, 10)
                    },
                    new MeetingRole
                    {
                        Title = "Tonic",
                        Type = RoleTypes.Tonic,
                        StartTime = new DateTime(2014, 11, 2, 19, 19, 0),
                        MinTime = new TimeSpan(0, 0, 0, 30),
                        MedTime = new TimeSpan(0, 0, 0, 45),
                        MaxTime = new TimeSpan(0, 0, 1)
                    },
                    new MeetingRole
                    {
                        Title = "Table Topics Evaluator",
                        Type = RoleTypes.TableTopicsEvaluator,
                        StartTime = new DateTime(2014, 11, 2, 19, 21, 0),
                        MinTime = new TimeSpan(0, 0, 4),
                        MedTime = new TimeSpan(0, 0, 5),
                        MaxTime = new TimeSpan(0, 0, 6)
                    },
                },
            };
        }

        private void SetupMembers()
        {
            _members = new[]
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
        }

        [Test]
        public void auto_arrange_meeting_should_succeed()
        {
            //arrange
            var meetingDate = DateTime.Now.AddDays(7);
            var scheduler = new MeettingScheduler(_meetingTemplate, meetingDate, _members);
            
            //act
            var arrangedMeeting = scheduler.Arrange();

            //assert
            Assert.AreNotSame(_meetingTemplate, arrangedMeeting);
            Assert.AreEqual(meetingDate, arrangedMeeting.DateTime);
            Assert.AreEqual(_meetingTemplate.Roles.Count, arrangedMeeting.Roles.Count);
            
            CollectionAssert.AllItemsAreNotNull(arrangedMeeting.Roles);
            CollectionAssert.AreEqual(_meetingTemplate.Roles.Select(r => r.Type), arrangedMeeting.Roles.Select(r => r.Type));
            CollectionAssert.AllItemsAreNotNull(arrangedMeeting.Roles.Select(r => r.Member));
        }
    }
}
