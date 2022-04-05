using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Core_System.Models
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        {

        }

        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<RoomStatus> RoomStatus { get; set; }
        public DbSet<AccountStatus> AccountStatus { get; set; }
        public DbSet<PaymentStatus> PaymentStatus { get; set; }
        public DbSet<BookingStatus> BookingStatus { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<MpesaCallback> MpesaCallbacks { get; set; }
        public DbSet <MessageStatus> MessageStatuses { get; set; }
        public DbSet <Message> Messages { get; set; }


    }
}
