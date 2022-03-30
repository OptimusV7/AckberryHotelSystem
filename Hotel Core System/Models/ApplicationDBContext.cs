using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static Hotel_Core_System.Models.ApplicationDBContext;

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

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<ApplicationUser>(b =>
        //    {
        //        b.HasMany(e => e.UserRoles)
        //        .WithOne(e => e.User)
        //        .HasForeignKey(ur => ur.UserId)
        //        .IsRequired();
        //    });

        //    builder.Entity<Role>(b =>
        //    {
        //        b.HasMany(e => e.UserRoles)
        //            .WithOne(e => e.Role)
        //            .HasForeignKey(ur => ur.RoleId)
        //            .IsRequired();
        //    });
        //}

        /*public class User : IdentityUser
        {
            public string Name { get; set; }
            public virtual ICollection<UserRole> UserRoles { get; set; }
        }*/

        //public class UserRole : IdentityUserRole<string>
        //{
        //    public virtual ApplicationUser User { get; set; }
        //    public virtual Role Role { get; set; }
        //}

        //public class Role : IdentityRole
        //{
        //    public virtual ICollection<UserRole> UserRoles { get; set; }
        //}
    }
}
