using Hotel_Core_System.Models;
using Hotel_Core_System.Models.ViewModels;
using Hotel_Core_System.Services.Rooms;
using Hotel_Core_System.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Hotel_Core_System.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService )
        {
            _roomService = roomService;
        }
        public IActionResult Index()
        {
            var rooms = _roomService.GetRoomList();
            if (rooms.Count > 0 )
            {
                foreach (var item in rooms)
                {
                    object roomFeaturesJson = item.RoomFeatureValues;
                    var FeatureValue = _roomService.GetRoomFeaturesList(roomFeaturesJson);
                    
                }
            }
            return View(rooms);
        }

        public IActionResult GetRoomDetails()
        {
            return View();
        }

        public IActionResult AddRoom()
        {
            ViewBag.RoomTypeList = _roomService.GetRoomTypeList();
            ViewBag.RoomFeaturesList = _roomService.GetRoomFeaturesList();
            return View("~/Views/Admin/Room/Create.cshtml");
        }

        public IActionResult AddFeature()
        {
            return View("~/Views/Admin/RoomFeatures/Create.cshtml");
        }
        public IActionResult GetAllFeatures()
        {
            var roomFeaturesList = _roomService.GetRoomFeaturesList();
            return View("~/Views/Admin/RoomFeatures/Index.cshtml", roomFeaturesList);
        }

        public IActionResult GetAllRooms()
        {
            var rooms = _roomService.GetRoomList();
            return View("~/Views/Admin/Room/Index.cshtml", rooms);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostRoom(RoomVM data, IFormFile[] ImageFile, List<string> RoomFeaturesValues)
        {
            if (ModelState.IsValid)
            {
                CommonResponse<int> commonRespose = new CommonResponse<int>();
                try
                {
                    commonRespose.status = _roomService.AddRoom(data, ImageFile, RoomFeaturesValues).Result;
                    if (commonRespose.status == 200)
                    {
                        ViewBag.Success = "Submitted Successfully";
                        return RedirectToAction("getAllRooms", "Room");
                    }
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);

                }

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Check your form data");

            return View("~/Views/Admin/Room/Create.cshtml", data);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostFeature(RoomFeature roomFeature)
        {
            if (ModelState.IsValid)
            {
                CommonResponse<int> commonRespose = new CommonResponse<int>();
                try
                {
                    commonRespose.status = _roomService.AddFeature(roomFeature).Result;
                    if (commonRespose.status == 200)
                    {
                        ViewBag.Success = "Submitted Successfully";
                        return RedirectToAction("AddFeature", "Room");
                    }
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);

                }

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Check your form data");

            return View("~/Views/Admin/RoomFeature/Create.cshtml", roomFeature);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateRoom(Room data)
        {
            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try
            {
                commonResponse.status = _roomService.UpdateRoom(data).Result;
                if (commonResponse.status > 0)
                {
                    commonResponse.message = Helper.roomUpdated;
                    ViewBag.Success = commonResponse;
                    return RedirectToAction("getAllRooms", "Room");
                }
            }
            catch (Exception e)
            {
                commonResponse.message = e.Message;
                ModelState.AddModelError("", e.Message);
            }

            return Ok(commonResponse);
        }

        
        [HttpDelete]
        public IActionResult DeleteRoom(int roomId)
        {
            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try
            {
                commonResponse.status = _roomService.DeleteRoom(roomId).Result;
                if (commonResponse.status > 0)
                {
                    commonResponse.message = Helper.roomDeleted;
                    commonResponse.status = Helper.success_code;
                }
            }
            catch (Exception e)
            {
                commonResponse.message = e.Message;
                commonResponse.status = Helper.failure_code;
            }

            return Ok(commonResponse);
        }

        
        [HttpGet]
        public IActionResult GetRoomsList()
        {
            CommonResponse<List<Room>> commonResponse = new CommonResponse<List<Room>>();
            try
            {
                commonResponse.dataenum = _roomService.GetRoomList();
                if (commonResponse.status > 0)
                {
                    commonResponse.message = Helper.roomList;
                    commonResponse.status = Helper.success_code;
                }
            }
            catch (Exception e)
            {
                commonResponse.message = e.Message;
                commonResponse.status = Helper.failure_code;
            }

            return Ok(commonResponse);
        }

        
        [HttpGet]
        public IActionResult GetRoomByID(int roomId)
        {
            CommonResponse<Room> commonResponse = new CommonResponse<Room>();
            try
            {
                commonResponse.dataenum = _roomService.GetRoom(roomId);
                if (commonResponse.status > 0)
                {
                    commonResponse.message = Helper.roomList;
                    commonResponse.status = Helper.success_code;
                }
            }
            catch (Exception e)
            {
                commonResponse.message = e.Message;
                commonResponse.status = Helper.failure_code;
            }

            return Ok(commonResponse);
        }
    }
}
