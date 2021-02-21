
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MelloApiV4.Common;

namespace MelloApiV4.Data.Connections
{
    public class SqlConnectionFactory : IConnectionFactory
    {
        private readonly CommandsConnectionString _commandsConnectionString;
        private readonly QueriesConnectionString _queriesConnectionString;

        public SqlConnectionFactory(CommandsConnectionString commandsConnectionString, QueriesConnectionString queriesConnectionString)
        {
            _commandsConnectionString = commandsConnectionString;
            _queriesConnectionString = queriesConnectionString;
        }

        public DbConnection CreatePrimaryConnection()
        {
            Gaurd.AgainstNull(_commandsConnectionString, nameof(_commandsConnectionString));

            return new SqlConnection("Data Source = mello.database.windows.net;initial catalog=MelloApiDatabase;user id=mello;password=");//_commandsConnectionString.Value);
        }

        public DbConnection CreateSecondaryConnection()
        {
            Gaurd.AgainstNull(_queriesConnectionString, nameof(_queriesConnectionString));

            return new SqlConnection("Data Source = mello.database.windows.net;initial catalog=MelloApiDatabase;user id=mello;password=");//_queriesConnectionString.Value);
        }
    }
}
