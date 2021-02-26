using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Data
{
    public class UserEntity : IdentityUser<int>, IEntity
    {
        public static UserEntity Manager = new UserEntity("");
        public static string ManagerPassword = "";

        public bool IsAdmin { get; set; }

        public bool Deleted { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public int LoginCount { get; set; }

        public long? MasterID { get; set; }

        public string PasswordHash_Old { get; set; }

        public string SaltKey_Old { get; set; }

        public string RefreshToken { get; set; }

        public bool IsCompositeEntity() => false;

        public UserEntity()
        {
            RegistrationDate = DateTime.UtcNow;
        }

        public UserEntity(string email) : this()
        {
            Email = email;
            UserName = email;
        }

        public void UpdateLogin()
        {
            LastLoginDate = DateTime.UtcNow;
            LoginCount = LoginCount + 1;
        }

        public void Lockout()
        {
            LockoutEnabled = true;
            LockoutEnd = DateTime.UtcNow.AddYears(200);
        }

        public bool IsLockedOut() => LockoutEnd != null;

        public void Unlock()
        {
            LockoutEnd = null;
        }

    }
}

