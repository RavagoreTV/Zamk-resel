using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;
using ZamkDb.Models;
using ZamkDb.Services.EFService;

namespace ZamDBUnitTestProject
{
    public class UnitTest : EFTestDataServers
    {
        public UnitTest() : base(new DbContextOptionsBuilder<ZamDbContext>().UseInMemoryDatabase("Filename=Test.db").Options)
        {

        }

        [Fact]
        public void Get_All_Participants_Test()
        {
            using (var contex = new ZamDbContext(ContexOptions))
            {
                EFParticipantService pService = new EFParticipantService(contex);

                var participants = pService.GetAllParticipants().ToList();
                Assert.Equal(2, participants.Count);
                Assert.Equal("Jacob", participants[0].Name);
                Assert.Equal("Tobias", participants[1].Name);
            }
        }
        [Fact]

        public void Get_Participant_Test()
        {
            using (var contex = new ZamDbContext(ContexOptions))
            {
                EFParticipantService pService = new EFParticipantService(contex);

                var participants = pService.GetAllParticipants().ToList();
                Assert.True(participants.Count == 2);
            }
        }

        [Fact]
        public void Get_All_Course_Test()
        {
            using (var contex = new ZamDbContext(ContexOptions))
            {
                EFCourseService cService = new EFCourseService(contex);

                var courses = cService.GetAllCourses().ToList();
                Assert.Equal(1, courses[0].CourseId);
                Assert.Equal(2, courses[1].CourseId);
            }
        }

        

        [Fact]
        public void Add_Course_Test()
        {
            using (var context = new ZamDbContext(ContexOptions))
            {
                EFCourseService mService = new EFCourseService(context);



                mService.AddCourse(new Course()
                {
                    CourseId = 3,
                    StartLocation = "Holbæk",
                    EndLocation = "Vibysjælland",
                    ZealandLocation = "Roskilde",
                    PickUpPoint1 = "Månevej 12",
                    PickUpPoint2 = "",
                    PickUpPoint3 = "",
                    UserId = "b6271686-a911-41b2-85da-dda7e800612f"



                });
                var course = mService.GetAllCourses().ToList();
                Assert.True(course.Count == 3);
                Assert.Equal(3, course[2].CourseId);



            }
        }

        [Fact]
        public void Delete_Course_Test()
        {
            using (var contex = new ZamDbContext(ContexOptions))
            {
                EFCourseService cService = new EFCourseService(contex);

                var course = cService.GetAllCourses().Where(m => m.CourseId == 2).FirstOrDefault();

                cService.DeleteCourse(course.CourseId);
                var courses = cService.GetAllCourses().ToList();
                Assert.True(courses.Count == 1);
                Assert.Equal(1, courses[0].CourseId);
            }
        }

        [Fact]
        public void Edit_Course_Test()
        {
            using (var contex = new ZamDbContext(ContexOptions))
            {
                EFCourseService cService = new EFCourseService(contex);

                var course = cService.GetAllCourses();
            }
        }

        [Fact]
        public void Get_All_Booking()
        {
            using (var contex = new ZamDbContext(ContexOptions))
            {
                EFBookingService bService = new EFBookingService(contex);
                {
                    var booking = bService.GetAllBookings().ToList();

                    Assert.True(booking.Count == 1);
                    Assert.Equal(1, booking[0].BookingId);
                }
            }
        }
    }
}
