using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Data.Connections
{
    public interface IComputerVisionFactory
    {
        string GetComputerVisionEndpoint();
        string GetComputerVisionKey();
    }
}
