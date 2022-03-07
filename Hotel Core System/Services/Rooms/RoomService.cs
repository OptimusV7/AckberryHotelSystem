using Hotel_Core_System.Models;
using Hotel_Core_System.Services.LogManagerConf;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Core_System.Services.Rooms
{
    public class RoomService : IRoomService
    {
        private readonly ApplicationDBContext _dbContext;

        private readonly ILoggerManager logger;

        public RoomService(ApplicationDBContext dBContext, ILoggerManager loggerManager)
        {
            _dbContext = dBContext;
            logger = loggerManager;
        }
        public async Task<int> AddRoom(Room model)
        {           
            var room = new Room
            {
                RoomNumber = model.RoomNumber,
                RoomType = model.RoomType,
                IsRoomAvailable = model.IsRoomAvailable,
                CheckIn = model.CheckIn,
                CheckOut = model.CheckOut,
                BookingPrice = model.BookingPrice,
                IsSmokingAllowed = model.IsSmokingAllowed,
            };
            _dbContext.Rooms.Add(room);
            var results = await _dbContext.SaveChangesAsync();
            if (results > 0)
            {
                logger.LogInformation(results.ToString());
            }
            logger.LogInformation(results.ToString());
            return 200;
        }

        public async Task<int> DeleteRoom(int roomId)
        {
            var roomdata = _dbContext.Rooms.FirstOrDefault(x => x.RoomId == roomId);
            if (roomdata != null)
            {
                _dbContext.Rooms.Remove(roomdata);
                return await _dbContext.SaveChangesAsync();
            }
            return 400;
        }

        public Room GetRoom(int roomId)
        {
            return _dbContext.Rooms.Where(x => x.RoomId == roomId).ToList().Select(c => new Room() { }).SingleOrDefault();
        }

        public List<Room> GetRoomList()
        {
            var roomlist = (from room in _dbContext.Rooms
                            select new Room
                            {
                                RoomId = room.RoomId,
                                RoomNumber = room.RoomNumber,
                                RoomType = room.RoomType,
                                IsRoomAvailable = room.IsRoomAvailable,
                                CheckIn = room.CheckIn,
                                CheckOut = room.CheckOut,
                                BookingPrice = room.BookingPrice,
                                IsSmokingAllowed = room.IsSmokingAllowed
                            }).ToList();
            return roomlist;
        }

        public async Task<int> UpdateRoom(Room model)
        {
            var roomdata = _dbContext.Rooms.FirstOrDefault(x => x.RoomId == model.RoomId);
            if (roomdata != null)
            {
                roomdata.RoomNumber = model.RoomNumber;
                roomdata.IsRoomAvailable = model.IsRoomAvailable;
                roomdata.RoomType = model.RoomType;
                roomdata.IsSmokingAllowed = model.IsSmokingAllowed;
                roomdata.CheckOut = model.CheckOut;
                roomdata.CheckIn = model.CheckIn;
                roomdata.BookingPrice = model.BookingPrice;

                return await _dbContext.SaveChangesAsync();
            }


            return 400;

        }
    }
}
