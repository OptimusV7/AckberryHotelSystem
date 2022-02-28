using Hotel_Core_System.DbInitializer;
using Hotel_Core_System.Models;
using Hotel_Core_System.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_Core_System.DBInitializer
{
    public class DbInitialize : IDbInitializer
    {
        private readonly ApplicationDBContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<DbInitialize> _logger;


        public DbInitialize(ApplicationDBContext db, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, ILogger<DbInitialize> logger)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
            _logger = logger;
        }

        public void Initalize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error during migration to db" + ex.Message);
            }

            if (!_db.Roles.Any(x => x.Name == Utility.Helper.Admin))
            {
                _roleManager.CreateAsync(new IdentityRole(Helper.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Helper.Receptionist)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Helper.Manager)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Helper.Guest)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Helper.System)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Helper.Supervisor)).GetAwaiter().GetResult();
            }

            if (!_db.Users.Any(x => x.Email == Helper.InitEmail))
            {
                var user = new ApplicationUser
                {
                    UserName = Helper.InitEmail,
                    Email = Helper.InitEmail,
                    EmailConfirmed = true,
                    Name = "Admin Ackberry"
                };
                var result = _userManager.CreateAsync(user, Helper.InitPass).GetAwaiter().GetResult();
                if (result.Succeeded)
                {
                    _logger.LogDebug("Default User Added" + result);

                    user = _db.Users.FirstOrDefault(u => u.Email == Helper.InitEmail);
                    _logger.LogInformation("users" + user);
                    _userManager.AddToRoleAsync(user, Helper.Admin).GetAwaiter().GetResult();
                    return;
                }
                if (result.Errors.Any())
                {
                    _logger.LogError("Error adding Default User" + result);
                    return;

                }
            }


        }

        public void Seed()
        {
            if (_db.RoomStatus.Any(x => x.Status_name == Utility.Helper.Available) && _db.RoomTypes.Any(x => x.Type_name == Utility.Helper.Standard)
                && _db.AccountStatus.Any(x => x.Account_status_name == Utility.Helper.Active) && _db.BookingStatus.Any(x => x.Booking_status_name == Utility.Helper.Requested)
                && _db.PaymentStatus.Any(x => x.Payment_status_name == Utility.Helper.Unpaid)) return;

            IList<RoomStatus> roomStatuses = new List<RoomStatus>();

            roomStatuses.Add(new RoomStatus() { Status_name = Helper.Available });
            roomStatuses.Add(new RoomStatus() { Status_name = Helper.Occupied });
            roomStatuses.Add(new RoomStatus() { Status_name = Helper.NotAvailable });
            roomStatuses.Add(new RoomStatus() { Status_name = Helper.BeignServiced });
            roomStatuses.Add(new RoomStatus() { Status_name = Helper.Other });

            foreach (RoomStatus roomStatus in roomStatuses)
                _db.RoomStatus.AddAsync(roomStatus);
            _db.SaveChanges();

            IList<RoomType> roomTypes = new List<RoomType>();

            roomTypes.Add(new RoomType() { Type_name = Helper.Standard });
            roomTypes.Add(new RoomType() { Type_name = Helper.Deluxe });
            roomTypes.Add(new RoomType() { Type_name = Helper.Executive });
            roomTypes.Add(new RoomType() { Type_name = Helper.OneBedroom });
            roomTypes.Add(new RoomType() { Type_name = Helper.TwoBedroom });
            roomTypes.Add(new RoomType() { Type_name = Helper.ThreeBedroom });

            foreach (RoomType roomType in roomTypes)
                _db.RoomTypes.Add(roomType);
            _db.SaveChanges();

            IList<AccountStatus> accountStatuses = new List<AccountStatus>();

            accountStatuses.Add(new AccountStatus() { Account_status_name = Helper.Active });
            accountStatuses.Add(new AccountStatus() { Account_status_name = Helper.closed });
            accountStatuses.Add(new AccountStatus() { Account_status_name = Helper.Cancelled });
            accountStatuses.Add(new AccountStatus() { Account_status_name = Helper.Blacklisted });

            foreach (AccountStatus accountStatus in accountStatuses)
                _db.AccountStatus.Add(accountStatus);
            _db.SaveChanges();

            IList<BookingStatus> bookingStatuses = new List<BookingStatus>();

            bookingStatuses.Add(new BookingStatus() { Booking_status_name = Helper.Requested });
            bookingStatuses.Add(new BookingStatus() { Booking_status_name = Helper.Pending });
            bookingStatuses.Add(new BookingStatus() { Booking_status_name = Helper.Confirmed });
            bookingStatuses.Add(new BookingStatus() { Booking_status_name = Helper.Checked_in });
            bookingStatuses.Add(new BookingStatus() { Booking_status_name = Helper.Checked_out });
            bookingStatuses.Add(new BookingStatus() { Booking_status_name = Helper.Abandoned });

            foreach (BookingStatus bookingStatus in bookingStatuses)
                _db.BookingStatus.Add(bookingStatus);
            _db.SaveChanges();

            IList<PaymentStatus> paymentStatuses = new List<PaymentStatus>();

            paymentStatuses.Add(new PaymentStatus() { Payment_status_name = Helper.Unpaid });
            paymentStatuses.Add(new PaymentStatus() { Payment_status_name = Helper.PendingPayment });
            paymentStatuses.Add(new PaymentStatus() { Payment_status_name = Helper.CompletedPayment });
            paymentStatuses.Add(new PaymentStatus() { Payment_status_name = Helper.FailedPayment });
            paymentStatuses.Add(new PaymentStatus() { Payment_status_name = Helper.DeclinedPayment });
            paymentStatuses.Add(new PaymentStatus() { Payment_status_name = Helper.CancelledPayment });
            paymentStatuses.Add(new PaymentStatus() { Payment_status_name = Helper.AbandonedPayment });
            paymentStatuses.Add(new PaymentStatus() { Payment_status_name = Helper.RefundedPayment });

            foreach (PaymentStatus paymentStatus in paymentStatuses)
                _db.PaymentStatus.AddAsync(paymentStatus);
            _db.SaveChanges();

        }
    }
}
