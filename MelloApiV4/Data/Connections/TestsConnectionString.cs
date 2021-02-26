/*using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Data.Connections
{
    public class TestsConnectionString
    {
        public CommandsConnectionString CommandsConnectionString { get; }
        public QueriesConnectionString QueriesConnectionString { get; }

        private TestsConnectionString(
            CommandsConnectionString commandsConnectionString,
            QueriesConnectionString queriesConnectionString)
        {
            CommandsConnectionString = commandsConnectionString ?? throw new ArgumentNullException(nameof(commandsConnectionString));
            QueriesConnectionString = queriesConnectionString ?? throw new ArgumentNullException(nameof(queriesConnectionString));
        }

        public static Result<TestsConnectionString> Create(
            string commandsConnectionString,
            string queriesConnectionString)
        {
            var commandsConnectionStringOrError = CommandsConnectionString.Create(commandsConnectionString);
            if (commandsConnectionStringOrError.IsFailure)
                return Result.Fail<TestsConnectionString>(commandsConnectionStringOrError.Error);

            var queriesConnectionStringOrError = QueriesConnectionString.Create(queriesConnectionString);
            if (queriesConnectionStringOrError.IsFailure)
                return Result.Fail<TestsConnectionString>(queriesConnectionStringOrError.Error);

            return Result.Ok(new TestsConnectionString(
                                    commandsConnectionStringOrError.Value,
                                    queriesConnectionStringOrError.Value));
        }
    }
}
*/