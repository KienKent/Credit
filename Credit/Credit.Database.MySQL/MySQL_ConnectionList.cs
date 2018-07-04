using Credit.Database.Connections;
using Credit.Database.MySQL.Connections;

namespace Credit.Database.MySQL
{
    class MySQL_ConnectionList : ConnectionList
    {
        private MySQL_PlayerDataConnection playerDataConnection = new MySQL_PlayerDataConnection();
        public override PlayerDataConnection PlayerDataConnection
        {
            get
            {
                return playerDataConnection;
            }
        }

        public MySQL_ConnectionList()
        {
            childConnections.Add(playerDataConnection);
        }
    }
}