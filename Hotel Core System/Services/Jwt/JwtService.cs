﻿using Hotel_Core_System.Models;
using Hotel_Core_System.Utility;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Hotel_Core_System.Services.Jwt
{
    public class JwtService : IJwtService
    {

        public JwtService()
        {
           
        }

        public string GenerateToken(ApplicationUser user)
        {
            // generate token that is valid for 7 days

            return null;
        }

        public string ValidateToken(string token)
        {
            return null;
        }
    }
}
