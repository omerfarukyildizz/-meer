using Pbk.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Behaviors
{
    public static class AppHelper
    {
        private static string? language;
        private static int? _serviceId;
        private static int? _apDefaultLanguageId;
        public static int version = 1;
        public static int AppDefaultLanguageId
        {
            get => _apDefaultLanguageId ?? 1;
            set
            {
                _apDefaultLanguageId = value;
            }
        }

        public static string Token {  get; set; }    

        public static void setTokenHttpRequest (HttpRequest request)
        {
            var token = request.Headers["Authorization"].ToString().Replace("Bearer", "").Trim();
            AppHelper.Token = token;
        }

        public static string? getUserEmail(string? token = null)
        {
            try
            {
                var tokkenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokkenHandler.ReadJwtToken(token == null ? AppHelper.Token : token);
                var claims = securityToken.Claims;
                var email = claims.First(f => f.Type == "unique_name").Value;
                return email;
            }
            catch (Exception) 
            {
                return null;
            }
        }

        public static string Language
        {
            get => language ?? "en";
            set 
            {
                language = value;
                LanguageId = string.Equals(value, "en", StringComparison.OrdinalIgnoreCase) ? 4 : 5;
            }
        }

        public static int ServiceId
        {
            get => _serviceId ?? -1;
            set
            {
                _serviceId = value;
            }
        }

        public static int LanguageId { get; private set; } = 4;
    }
}
