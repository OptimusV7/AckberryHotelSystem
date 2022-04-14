﻿using Hotel_Core_System.Models;
using Hotel_Core_System.Models.ViewModels;
using Hotel_Core_System.Services.LogManagerConf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Core_System.Services.Rooms
{
    public class RoomService : IRoomService
    {
        private readonly ApplicationDBContext _dbContext;

        private readonly ILoggerManager logger;
        private readonly IWebHostEnvironment _hostEnvironment;

        public RoomService(ApplicationDBContext dBContext, ILoggerManager loggerManager, IWebHostEnvironment hostEnvironment)
        {
            _dbContext = dBContext;
            logger = loggerManager;
            _hostEnvironment = hostEnvironment;
        }


        public async Task<int> AddRoom(RoomVM model, IFormFile[] images)
        {           
            var room = new Room
            {
                RoomNumber = model.RoomNumber,
                RoomType = model.RoomType,
                IsRoomAvailable = model.IsRoomAvailable,
                CheckIn = false,
                CheckOut = false,
                BookingPrice = model.BookingPrice,
                IsSmokingAllowed = model.IsSmokingAllowed,
            };
            model.ImageFile = new List<string>();

            //save image
            foreach (IFormFile item in images)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(item.FileName);
                string extension = Path.GetExtension(item.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                model.imageName = fileName;
                string path = Path.GetFullPath(Path.Combine(wwwRootPath + "/images/", fileName)).Replace(@"\\", @"\");
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await item.CopyToAsync(fileStream);
                }
                string caption = "Room/Hotel Image";

                await AddImage(model.imageName, model.RoomNumber, caption);
            }
            
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

        public List<RoomType> GetRoomTypeList()
        {
            var roomTypeList = (from RoomType in _dbContext.RoomTypes
                                select new RoomType
                                {
                                    Id = RoomType.Id,
                                    Type_name = RoomType.Type_name

                                }).ToList();
            return roomTypeList;
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

        public async Task<int> AddImage(string ImgName, string roomNum, string caption)
        {
            var img = new RoomImage
            {
                RoomNumber = roomNum,
                ImageName = ImgName,
                Caption = caption,
            };
            _dbContext.RoomImages.Add(img);
            var results = await _dbContext.SaveChangesAsync();
            if (results > 0)
            {
                logger.LogInformation(results.ToString());
            }
            logger.LogInformation(results.ToString());
            return 200;
        }
    }
}
