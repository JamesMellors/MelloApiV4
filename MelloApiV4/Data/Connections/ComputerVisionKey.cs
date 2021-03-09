using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Data.Connections
{
    public class ComputerVisionKey
    {
        public string Value { get; }

        public ComputerVisionKey(string value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public static Result<ComputerVisionKey> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Result.Fail<ComputerVisionKey>("No key for ComputerVision");

            return Result.Ok(new ComputerVisionKey(value));
        }
    }
}
