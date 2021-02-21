using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Data
{
    public class RoleIdentity : IdentityRole<int>
    {
        public RoleIdentity(string name) : base(name)
        {
        }
    }
}