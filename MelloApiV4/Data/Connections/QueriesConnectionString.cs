using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Data.Connections
{
    public class QueriesConnectionString
    {
        public string Value { get; }

        public QueriesConnectionString(string value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public static Result<QueriesConnectionString> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Result.Fail<QueriesConnectionString>("No queries connection string provided");

            return Result.Ok(new QueriesConnectionString(value));
        }
    }
}
