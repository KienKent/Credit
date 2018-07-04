using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Credit.Library;
using Credit.Library.CommunicationInfrastructure;

namespace Credit.Server
{
    public class ServerEndPoint : EndPoint
    {
        public Guid Guid { get; protected set; }

        public ServerEndPoint(CommunicationInterface communicationInterface) : base(communicationInterface, new ServerOperationInterface())
        {
            Guid = Guid.NewGuid();
            while (EndPointFactory.Instance.ContainsEndPointGuid(Guid))
            {
                Guid = Guid.NewGuid();
            }
            WaitingPlayerCounter.OnWaitingPlayerCountUpdated += EventManager.SyncDataBroker.SyncWaitingPlayerCount;
        }
    }
}