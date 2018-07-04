using Credit.Protocol;
using Credit.Protocol.Communication.EventCodes;
using Credit.Protocol.Communication.OperationCodes;
using System.Collections.Generic;

namespace Credit.Library.CommunicationInfrastructure
{
    public abstract class CommunicationInterface
    {
        public EndPoint Endpoint { get; private set; }
        public virtual void BindEndPoint(EndPoint endpoint)
        {
            Endpoint = endpoint;
        }
        public abstract void SendEvent(EndPointEventCode eventCode, Dictionary<byte, object> parameters);
        public abstract void SendOperation(EndPointOperationCode operationCode, Dictionary<byte, object> parameters);
        public abstract void SendResponse(EndPointOperationCode operationCode, ReturnCode returnCode, string debugMessage, Dictionary<byte, object> parameters);
    }
}
