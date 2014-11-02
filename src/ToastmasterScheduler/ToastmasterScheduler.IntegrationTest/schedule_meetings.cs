using System;
using System.Linq;
using NUnit.Framework;
using ToastmasterScheduler.Domain;

namespace ToastmasterScheduler.IntegrationTest
{
    [TestFixture]
    public class schedule_meetings : IntegrationTestBase
    {
        [Test]
        public void initialize_meeting_from_template()
        {
            //arrange
            int meetingId;
            MeetingTemplate meetingTemplate;
            Meeting initializedMeeting;
            var meetingDate = DateTime.Now;

            using (var session = DocumentStore.OpenSession())
            {
                meetingTemplate = session.Query<MeetingTemplate>().First(t => t.Enabled);
                var members = session.Query<Member>();

                var scheduler = new MeettingScheduler(meetingTemplate, meetingDate, members);
                var meeting = scheduler.Initialize();

                session.Store(meeting);
                meetingId = meeting.Id;
                session.SaveChanges();
            }

            //act
            using (var session = DocumentStore.OpenSession())
            {
                initializedMeeting = session.Load<Meeting>(meetingId);
            }

            //assert
            Assert.AreEqual(meetingDate, initializedMeeting.DateTime);
            CollectionAssert.AreEqual(meetingTemplate.Items.Select(i => i.Role.Id), initializedMeeting.Items.Select(i => i.Role.Id));
        }
    }
}