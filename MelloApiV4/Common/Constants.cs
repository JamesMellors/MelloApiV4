using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Common
{
    public class Constants
    {

        public class Connections
        {
            public const string MelloConnectionString = "MelloConnectionString";

        }

        public class Cors
        {
            public const string AllowAllPolicy = "AllowAll";
        }

        public class Authentication
        {
            public const string JwtIssuerKeyName = "JwtIssuer";
            public const string JwtExpiryName = "JwtExpiry";
            public const string JwtAudienceKeyName = "JwtAudience";
            public const string IssuerSigningSecretKey = "test";
        }


        public static class Validation
        {
            public const int OneMegaByte = 1 * 1024 * 1024;
            public const int TenMegaBytes = 10 * 1024 * 1024;
        }

    }
}
