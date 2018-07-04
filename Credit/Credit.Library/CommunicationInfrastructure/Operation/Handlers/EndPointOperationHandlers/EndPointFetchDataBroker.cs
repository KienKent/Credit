using Credit.Protocol;
using Credit.Protocol.Communication.FetchDataCodes;
using Credit.Protocol.Communication.OperationCodes;
using System.Collections.Generic;

namespace Credit.Library.CommunicationInfrastructure.Operation.Handlers.EndPointOperationHandlers
{
    public class EndPointFetchDataBroker : FetchDataBroker<EndPoint, EndPointOperationCode, EndPointFetchDataCode>
    {
        internal EndPointFetchDataBroker(EndPoint subject) : base(subject)
        {

        }

        internal override void SendResponse(EndPointOperationCode operationCode, ReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameter)
        {
            subject.ResponseManager.SendResponse(operationCode, returnCode, operationMessage, parameter);
        }

        internal void SendOperation(EndPointFetchDataCode fetchCode, Dictionary<byte, object> parameters)
        {
            subject.OperationManager.SendFetchDataOperation(fetchCode, parameters);
        }
    }
}