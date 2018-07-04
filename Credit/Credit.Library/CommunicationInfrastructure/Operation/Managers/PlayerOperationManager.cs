using Credit.Library.CommunicationInfrastructure.Operation.Handlers;
using Credit.Library.CommunicationInfrastructure.Operation.Handlers.PlayerOperationHandlers;
using Credit.Protocol.Communication.FetchDataCodes;
using Credit.Protocol.Communication.FetchDataParameters;
using Credit.Protocol.Communication.OperationCodes;
using Credit.Protocol.Communication.OperationParameters.Player;
using System.Collections.Generic;

namespace Credit.Library.CommunicationInfrastructure.Operation.Managers
{
    public class PlayerOperationManager
    {
        private readonly Player player;
        private readonly Dictionary<PlayerOperationCode, OperationHandler<Player, PlayerOperationCode>> operationTable = new Dictionary<PlayerOperationCode, OperationHandler<Player, PlayerOperationCode>>();
        public PlayerFetchDataBroker FetchDataBroker { get; private set; }
    }
}
