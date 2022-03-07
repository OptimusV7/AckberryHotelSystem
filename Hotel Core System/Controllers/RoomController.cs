﻿using Hotel_Core_System.Models;
using Hotel_Core_System.Models.ViewModels;
using Hotel_Core_System.Services.Rooms;
using Hotel_Core_System.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Hotel_Core_System.Controllers
{
    public class RoomController : Controller
    {
        private IRoomService _roomService;

        public RoomController(IRoomService roomService )
        {
            _roomService = roomService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RoomDetails()
        {
            return View();
        }

        public IActionResult createRoom()
        {
            return View();
        }

        public IActionResult getAllRooms()
        {
            return View("~/Views/Admin/Room/Index.cshtml");
        }

        
        [HttpPost]
        public IActionResult Post(Room data)
        {
            if (ModelState.IsValid)
            {
                CommonResponse<int> commonRespose = new CommonResponse<int>();
                try
                {
                    commonRespose.status = _roomService.AddRoom(data).Result;
                    if (commonRespose.status == 200)
                    {
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

            return RedirectToAction("createRoom", "Room");

        }

        
        [HttpPost]
        public IActionResult Update(Room data)
        {
            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try
            {
                commonResponse.status = _roomService.UpdateRoom(data).Result;
                if (commonResponse.status > 0)
                {
                    commonResponse.message = Helper.roomUpdated;
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

        
        [HttpDelete]
        public IActionResult Delete(int roomId)
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
