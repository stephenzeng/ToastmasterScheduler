using System;
using System.Linq;
using NUnit.Framework;
using ToastmasterScheduler.Domain;
using ToastmasterScheduler.Web;

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
            var meetingDate = DateTime.Now;

            using (var session = DocumentStore.OpenSession())
            {
                meetingTemplate = session.Query<MeetingTemplate>().First(t => t.Enabled);
                var scheduler = new MeettingScheduler(session);
                
                //act
                var meeting = scheduler.Initialize(meetingTemplate, meetingDate);

                session.Store(meeting);
                meetingId = meeting.Id;
                session.SaveChanges();
            }

            //assert
            using (var session = DocumentStore.OpenSession())
            {
                var meeting = session.Load<Meeting>(meetingId);

                Assert.AreEqual(meetingDate, meeting.DateTime);
                CollectionAssert.AreEqual(meetingTemplate.Items.Select(i => i.Role.Id), meeting.Items.Select(i => i.Role.Id));
            }
        }

        [Test]
        public void fill_vacancies_for_a_meeting()
        {
            //arrange
            int meetingId;
            var meetingDate = DateTime.Now;

            using (var session = DocumentStore.OpenSession())
            {
                var meetingTemplate = session.Query<MeetingTemplate>().First(t => t.Enabled);

                var scheduler = new MeettingScheduler(session);
                var meeting = scheduler.Initialize(meetingTemplate, meetingDate);

                //act
                scheduler.FillVacancies(meeting);

                session.Store(meeting);
                meetingId = meeting.Id;
                session.SaveChanges();
            }

            //assert
            using (var session = DocumentStore.OpenSession())
            {
                var meeting = session.Load<Meeting>(meetingId);

                CollectionAssert.AllItemsAreNotNull(meeting.Items.Select(i => i.Member));
                CollectionAssert.AllItemsAreUnique(meeting.Items.Select(i => i.Member.Id));
            }
        }

        //todo:implement some of the roles may not require members assigned
        //todo:add a test that some vacancies are filled manually before auto-fill process
        
    }
}