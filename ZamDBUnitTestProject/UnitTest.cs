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
        public void Get_Booking_Test()
        {
            using (var contex = new ZamDbContext(ContexOptions))
            {
                EFBookingService bService = new EFBookingService(contex);

                var booking = bService.GetAllBookings().Where(b => b.BookingId == 10);
                Assert.True(booking.ToList().Count == 0);
            }
        }

        [Fact]
        public void Get_All_Booking_Test()
        {
            using (var contex = new ZamDbContext(ContexOptions))
            {
                EFBookingService bService = new EFBookingService(contex);
                {
                    var booking = bService.GetAllBookings().ToList();

                    Assert.True(booking.Count == 2);
                    Assert.Equal("Lejre", booking[0].ChosenPickUpPoint);
                    Assert.Equal("T�ll�se", booking[1].ChosenPickUpPoint);
                }
            }
        }

        [Fact]
        public void Add_Booking_Test()
        {
            using (var context = new ZamDbContext(ContexOptions))
            {
                EFBookingService bService = new EFBookingService(context);

                bService.AddBooking(new Booking()
                {
                    BookingId = 3,
                    Date = new DateTime(2021, 05, 07),
                    ParticipantId = "b6271686-a911-41b2-85da-dda7e800612f",
                    CourseId = 1,
                    ChosenPickUpPoint = "Lejre"
                });
                var booking = bService.GetAllBookings().ToList();
                Assert.True(booking.Count == 3);
                Assert.Equal(1, booking[0].BookingId);

            }
        }

        [Fact]
        public void Delete_Booking_Test()
        {
            using (var contex = new ZamDbContext(ContexOptions))
            {
                EFBookingService bService = new EFBookingService(contex);

                var booking = bService.GetAllBookings().Where(b => b.BookingId == 2).FirstOrDefault();

                bService.DeleteBooking(booking.BookingId);
                var bookings = bService.GetAllBookings().ToList();
                Assert.True(booking.BookingId == 2);
                Assert.False(bookings[0].BookingId == 2);
            }
        }

        [Fact]
        public void Get_Course_Test()
        {
            using (var contex = new ZamDbContext(ContexOptions))
            {
                EFCourseService cService = new EFCourseService(contex);

                var course = cService.GetAllCourses().Where(c => c.CourseId == 10);
                Assert.True(course.ToList().Count == 0);
            }
        }

        [Fact]
        public void Get_All_Course_Test()
        {
            using (var contex = new ZamDbContext(ContexOptions))
            {
                EFCourseService cService = new EFCourseService(contex);

                var courses = cService.GetAllCourses().ToList();
                Assert.Equal(2, courses.Count);
                Assert.Equal("Holb�k", courses[0].ZealandLocation);
                Assert.Equal("Roskilde", courses[1].ZealandLocation);
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
                    StartDateTime = new DateTime(2021, 12, 05),
                    EndDateTime = new DateTime(2021, 12, 05),
                    StartLocation = "Holb�k",
                    EndLocation = "Vibysj�lland",
                    PickUpPoint1 = "M�nevej 12",
                    PickUpPoint2 = "",
                    PickUpPoint3 = "",
                    ZealandLocation = "N�stved",
                    UserId = "b6271686-a911-41b2-85da-dda7e800612f",
                    AvailableSeats = 4
                });

                var course = mService.GetAllCourses().ToList();
                Assert.True(course.Count == 3);
                Assert.Equal("N�stved", course[2].ZealandLocation);
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
                Assert.False(courses[0].CourseId == 2);
            }
        }

        [Fact]
        //Kan sku ikke l�se den drenge
        public void Edit_Course_Test()
        {
            using (var contex = new ZamDbContext(ContexOptions))
            {
                EFCourseService cService = new EFCourseService(contex);

                cService.EditCourse(new Course()
                {
                    CourseId = 1,
                    StartDateTime = new DateTime(2021, 07, 05),
                    EndDateTime = new DateTime(2021, 07, 05),
                    StartLocation = "Roskilde",
                    EndLocation = "Holb�k",
                    PickUpPoint1 = "Lejre",
                    PickUpPoint2 = "T�ll�se",
                    PickUpPoint3 = "Holb�k",
                    ZealandLocation = "Holb�k",
                    UserId = "203d93ad-bc81-4dd8-afcb-76794137058a",
                    AvailableSeats = 3
                });

                var course = cService.GetAllCourses().ToList();
                Assert.True(course.Count == 3);
                Assert.Equal(4, course[01].AvailableSeats);
            }
        }

        [Fact]
        public void Filter_Course_Test()
        {
            using (var contex = new ZamDbContext(ContexOptions))
            {
                EFCourseService cService = new EFCourseService(contex);

                string criteria = "Roskilde";
                var course = cService.FilterCourse(criteria);

                Assert.True(course.ToList().Count == 1);
                Assert.Equal("Roskilde", course.ToList()[0].ZealandLocation);
            }
        }

        [Fact]

        public void Get_Participant_Test()
        {
            using (var contex = new ZamDbContext(ContexOptions))
            {
                EFParticipantService pService = new EFParticipantService(contex);

                var participant = pService.GetAllParticipants().Where(p => p.Id == "");
                Assert.True(participant.ToList().Count == 0);
            }
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
        //Kan sku ikke l�se den need help!
        public void Edit_Participant_Test()
        {
            using (var contex = new ZamDbContext(ContexOptions))
            {
                EFParticipantService pService = new EFParticipantService(contex);

                pService.EditParticipant(new Participant()
                {
                    Id = "203d93ad-bc81-4dd8-afcb-76794137058a",
                    Name = "Tobias",
                    Address = "Vejen 2",
                    canBeDriver = true,
                    DriverId = "203d93ad-bc81-4dd8-afcb-76794137058a",
                    UserName = "test2@test.dk",
                    NormalizedUserName = "test2@test.dk",
                    Email = "test2@test.dk",
                    NormalizedEmail = "test2@test.dk",
                    EmailConfirmed = false,
                    PasswordHash = "Test123!",
                    SecurityStamp = "MO7OPBJ2QRIPBBJKJMGVX2AJUBGYSRHT",
                    ConcurrencyStamp = "154d91ba-a350-457e-bc22-2c2ef36cd6d9",
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                });

                var participant = pService.GetAllParticipants().ToList();
                Assert.True(participant.Count == 2);
                Assert.Equal("Victor", participant[0].Name);
            }
        }
    }
}
