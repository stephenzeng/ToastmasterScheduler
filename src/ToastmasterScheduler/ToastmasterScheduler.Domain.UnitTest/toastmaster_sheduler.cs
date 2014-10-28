using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public class toastmaster_sheduler
    {
        private void PredefineMeeting()
        {
            var meeting = new Meeting
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
                        Title = "Sergeant at Arms",
                        Type = RoleTypes.GuestIntroduction,
                        Member = new Member {GivenName = "Tom", Surname = "Bielski"},
                        StartTime = new DateTime(2014, 11, 2, 18, 30, 0),
                        MinTime = new TimeSpan(0, 0, 0, 30),
                        MedTime = new TimeSpan(0, 0, 0, 45),
                        MaxTime = new TimeSpan(0, 0, 1)
                    },
                    new MeetingRole
                    {
                        Title = "Sergeant at Arms",
                        Type = RoleTypes.SergeantAtArms,
                        Member = new Member {GivenName = "Tom", Surname = "Bielski"},
                        StartTime = new DateTime(2014, 11, 2, 18, 30, 0),
                        MinTime = new TimeSpan(0, 0, 0, 30),
                        MedTime = new TimeSpan(0, 0, 0, 45),
                        MaxTime = new TimeSpan(0, 0, 1)
                    },
                    new MeetingRole
                    {
                        Title = "Sergeant at Arms",
                        Type = RoleTypes.SergeantAtArms,
                        Member = new Member {GivenName = "Tom", Surname = "Bielski"},
                        StartTime = new DateTime(2014, 11, 2, 18, 30, 0),
                        MinTime = new TimeSpan(0, 0, 0, 30),
                        MedTime = new TimeSpan(0, 0, 0, 45),
                        MaxTime = new TimeSpan(0, 0, 1)
                    },
                    new MeetingRole
                    {
                        Title = "Sergeant at Arms",
                        Type = RoleTypes.SergeantAtArms,
                        Member = new Member {GivenName = "Tom", Surname = "Bielski"},
                        StartTime = new DateTime(2014, 11, 2, 18, 30, 0),
                        MinTime = new TimeSpan(0, 0, 0, 30),
                        MedTime = new TimeSpan(0, 0, 0, 45),
                        MaxTime = new TimeSpan(0, 0, 1)
                    },
                    new MeetingRole
                    {
                        Title = "Sergeant at Arms",
                        Type = RoleTypes.SergeantAtArms,
                        Member = new Member {GivenName = "Tom", Surname = "Bielski"},
                        StartTime = new DateTime(2014, 11, 2, 18, 30, 0),
                        MinTime = new TimeSpan(0, 0, 0, 30),
                        MedTime = new TimeSpan(0, 0, 0, 45),
                        MaxTime = new TimeSpan(0, 0, 1)
                    },
                    new MeetingRole
                    {
                        Title = "Sergeant at Arms",
                        Type = RoleTypes.SergeantAtArms,
                        Member = new Member {GivenName = "Tom", Surname = "Bielski"},
                        StartTime = new DateTime(2014, 11, 2, 18, 30, 0),
                        MinTime = new TimeSpan(0, 0, 0, 30),
                        MedTime = new TimeSpan(0, 0, 0, 45),
                        MaxTime = new TimeSpan(0, 0, 1)
                    },
                    new MeetingRole
                    {
                        Title = "Sergeant at Arms",
                        Type = RoleTypes.SergeantAtArms,
                        Member = new Member {GivenName = "Tom", Surname = "Bielski"},
                        StartTime = new DateTime(2014, 11, 2, 18, 30, 0),
                        MinTime = new TimeSpan(0, 0, 0, 30),
                        MedTime = new TimeSpan(0, 0, 0, 45),
                        MaxTime = new TimeSpan(0, 0, 1)
                    },
                },
            };
        }

    }
}
