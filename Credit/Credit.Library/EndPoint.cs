using System;
using System.Net;
using Credit.Library.CommunicationInfrastructure;

namespace Credit.Library
{
    public class EndPoint
    {
        public Player Player { get; protected set; }
        public bool IsOnline { get { return Player != null; } }

        private IPAddress lastConnectedIPAddress;
        public IPAddress LastConnectedIPAddress
        {
            get { return lastConnectedIPAddress; }
            set
            {
                lastConnectedIPAddress = value;
                if (IsOnline)
                {
                    Player.LastConnectedIPAddress = value;
                }
            }
        }

        public CommunicationInterface CommunicationInterface { get; private set; }
        // public OperatoinInterface OperationInterface { get; private set; }

        //public EndPointEventManager EventManager { get; private set; }

        private event Action<Player> onPlayerOnline;
        public event Action<Player> OnPlayerOnline { add { onPlayerOnline += value; } remove { onPlayerOnline -= value; } }

        private event Action<Player> onPlayerOffline;
        public event Action<Player> OnPlayerOffline { add { onPlayerOffline += value; } remove { onPlayerOffline -= value; } }

        public EndPoint(CommunicationInterface communicationInterface, OperationInterface operationInterface)
        {
            CommunicationInterface = communicationInterface;
            OperationInterface = operationInterface;

            EventManager = new EndPointEventManager(this);
            OperationManager = new EndPointOperationManager(this);
            ResponseManager = new EndPointResponseManager(this);
        }

        public void PlayerOnline(Player player)
        {
            Player = player;
            player.EndPoint = this;
            onPlayerOnline?.Invoke(player);
        }
        public void PlayerOffline()
        {
            onPlayerOffline?.Invoke(Player);
            Player = null;
        }
    }
}
