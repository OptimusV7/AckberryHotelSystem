using Hotel_Core_System.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelAPI.Services.Rooms
{
    public interface IRoomService
    {
        public List<Room> GetRoomList();
        public Task<int> UpdateRoom(Room model);
        public Task<int> DeleteRoom(int roomId);
        public Room GetRoom(int roomId);
        public Task<int> AddRoom(Room model);
    }
}
