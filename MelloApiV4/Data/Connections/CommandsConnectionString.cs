using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Data.Connections
{
    public class CommandsConnectionString
    {
        public string Value { get; }

        public CommandsConnectionString(string value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public static Result<CommandsConnectionString> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Result.Fail<CommandsConnectionString>("No commands connection string provided");

            return Result.Ok(new CommandsConnectionString(value));
        }
    }
}
