using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZamkDb.Models;

namespace ZamkDb.Services.Interface
{
	public interface IBookingService
	{
		Booking GetBooking(int id);

		IEnumerable<Booking> GetAllBookings();

		Booking AddBooking(Booking booking);

		Booking DeleteBooking(int id);
	}
}
