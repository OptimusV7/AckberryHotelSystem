﻿using HotelAPI.Services.Jwt;
using HotelAPI.Services.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.Utility
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Appsettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<Appsettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtService jwtService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtService.ValidateToken(token);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = userService.GetById(userId.ToString());
            }

            await _next(context);
        }
    }
}
