using Hotel_Core_System.Models;
using Hotel_Core_System.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel_Core_System.Services.Rooms
{
    public interface IRoomService
    {
        public List<Room> GetRoomList();
        public List<RoomType> GetRoomTypeList();
        public Task<int> UpdateRoom(Room model);
        public Task<int> DeleteRoom(int roomId);
        public Room GetRoom(int roomId);
        public Task<int> AddRoom(RoomVM model, IFormFile[] images);
        public Task<int> AddImage(string imageName, string roomNum, string caption);
    }
}
