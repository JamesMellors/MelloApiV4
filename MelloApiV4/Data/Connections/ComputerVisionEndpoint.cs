using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Data.Connections
{
    public class ComputerVisionEndpoint
    {
        public string Value { get; }

        public ComputerVisionEndpoint(string value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public static Result<ComputerVisionEndpoint> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Result.Fail<ComputerVisionEndpoint>("No EndPoint for ComputerVision");

            return Result.Ok(new ComputerVisionEndpoint(value));
        }
    }
}
