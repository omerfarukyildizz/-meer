using Pbk.Entities.Models;
using Pbk.Entities.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Utilities.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static User? ValidateADUser(string userName, string password)
        {
            try
            {
                bool isValidate = false;
                byte[] passwordHash;
                byte[] passwordSalt;

                User? user = null;

                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain))
                {
                    isValidate = pc.ValidateCredentials(userName, password);
                }

                if (isValidate)
                {
                    user = new User();
                    user.UserName = userName;
                    user.Email = userName;

                    return user;
                }
                else
                {
                    return user;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
