using Credit.Library;
using Credit.Library.CommunicationInfrastructure;
using Credit.Protocol;
using Credit.Protocol.Communication.EventCodes;
using Credit.Protocol.Communication.OperationCodes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credit.PhotonServerEnvironment
{
    class PhotonServerCommunicationInterface : CommunicationInterface
    {
        private PhotonServerPeer peer;

        public PhotonServerCommunicationInterface(PhotonServerPeer peer)
        {
            this.peer = peer;
        }

        public override void SendEvent(EndPointEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EventData eventData = new EventData
            {
                Code = (byte)eventCode,
                Parameters = parameters
            };
            peer.SendEvent(eventData, new SendParameters());
        }

        public override void SendOperation(EndPointOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            LogService.Fatal($"PhotonServer SendOperation from : {peer.ServerEndPoint.LastConnectedIPAddress}");
        }

        public override void SendResponse(EndPointOperationCode operationCode, ReturnCode returnCode, string debugMessage, Dictionary<byte, object> parameters)
        {
            OperationResponse response = new OperationResponse((byte)operationCode, parameters)
            {
                ReturnCode = (short)returnCode,
                DebugMessage = debugMessage
            };
            peer.SendOperationResponse(response, new SendParameters());
        }
    }
}
