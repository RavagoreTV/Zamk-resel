using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ZamkDb.Models;

namespace ZamDBUnitTestProject
{
    public class EFTestDataServers
    {
        protected DbContextOptions<ZamDbContext> ContexOptions { get; }

        protected EFTestDataServers(DbContextOptions<ZamDbContext> contexOptions) 
        {
            ContexOptions = contexOptions;
            Seed();
        }

        private void Seed()
        {
            using (var contex = new ZamDbContext(ContexOptions))
            {
                contex.Database.EnsureDeleted();
                contex.Database.EnsureCreated();
                contex.Participants.Add(new Participant() { Id = "4392d2b - 16d4 - 4bf5 - 8ea9 - 5309058cd2e", Name = "Jacob", Address = "Slotshaven", canBeDriver = true, DriverId = "4392d2b - 16d4 - 4bf5 - 8ea9 - 5309058cd2e", UserName = "test@test.dk", NormalizedUserName = "test@test.dk", Email = "test@test.dk", NormalizedEmail = "test@test.dk", EmailConfirmed = false, PasswordHash = "Test123!", SecurityStamp = "MO7OPBJ2QRIPBBJKJMGVX2AJUBGYSRHT", ConcurrencyStamp = "154d91ba-a350-457e-bc22-2c2ef36cd6d9", PhoneNumber = null, PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnd = null, LockoutEnabled = false, AccessFailedCount = 0 });
                contex.Participants.Add(new Participant() { Id = "203d93ad-bc81-4dd8-afcb-76794137058a", Name = "Tobias", Address = "Vejen 2", canBeDriver = true, DriverId = "203d93ad-bc81-4dd8-afcb-76794137058a", UserName = "test2@test.dk", NormalizedUserName = "test2@test.dk", Email = "test2@test.dk", NormalizedEmail = "test2@test.dk", EmailConfirmed = false, PasswordHash = "Test123!", SecurityStamp = "MO7OPBJ2QRIPBBJKJMGVX2AJUBGYSRHT", ConcurrencyStamp = "154d91ba-a350-457e-bc22-2c2ef36cd6d9", PhoneNumber = null, PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnd = null, LockoutEnabled = false, AccessFailedCount = 0 });
                contex.Courses.Add(new Course() { CourseId = 1, StartDateTime = new DateTime(2021, 07, 05), EndDateTime = new DateTime(2021, 07, 05), StartLocation = "Roskilde", EndLocation = "Hoblæk", PickUpPoint1 = "Lejre", PickUpPoint2 = "Tølløse", PickUpPoint3 = "Holbæk", ZealandLocation = "Roskilde", UserId = "203d93ad-bc81-4dd8-afcb-76794137058a", AvailableSeats = 3 });
                contex.Courses.Add(new Course() { CourseId = 2, StartDateTime = new DateTime(2021, 07, 05), EndDateTime = new DateTime(2021, 07, 05), StartLocation = "Roskilde", EndLocation = "Hoblæk", PickUpPoint1 = "Lejre", PickUpPoint2 = "Tølløse", PickUpPoint3 = "Holbæk", ZealandLocation = "Roskilde", UserId = "203d93ad-bc81-4dd8-afcb-76794137058a", AvailableSeats = 3 });
                contex.Bookings.Add(new Booking() { BookingId = 1, Date = new DateTime(2021, 07, 09), ParticipantId = "203d93ad-bc81-4dd8-afcb-76794137058a", CourseId = 1, ChosenPickUpPoint = "Lejre" });
                contex.SaveChanges();
            }
        }
    }
}
