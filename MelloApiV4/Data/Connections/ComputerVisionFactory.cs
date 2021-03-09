using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Data.Connections
{
    public class ComputerVisionFactory : IComputerVisionFactory
    {
        private readonly ComputerVisionEndpoint _computerVisionEndpoint;
        private readonly ComputerVisionKey _computerVisionKey;

        public ComputerVisionFactory(ComputerVisionEndpoint computerVisionEndpoint, ComputerVisionKey computerVisionKey)
        {
            _computerVisionEndpoint = computerVisionEndpoint;
            _computerVisionKey = computerVisionKey;
        }

        public string GetComputerVisionEndpoint()
        {
            return _computerVisionEndpoint.Value;
        }

        public string GetComputerVisionKey()
        {
            return _computerVisionKey.Value;
        }

    }
}
