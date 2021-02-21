using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Data.Connections
{
    public interface IConnectionFactory
    {
        DbConnection CreatePrimaryConnection();
        DbConnection CreateSecondaryConnection();
    }
}
