using System;
using Amazon.Lambda.Core;

[assembly: LambdaSerializer(typeof(WellBehavedJsonSerializer))]

namespace AwsLambdaJsonSerializationDoneRight
{
    public enum Volume
    {
        Low,
        Normal,
        High,
    }

    public class EchoRequest
    {
        public string Message { get; set; }
        public Volume Volume { get; set; }
        public DateTime RequestTime { get; set; }
        public DateTime? ResponseTime { get; set; }
    }

    public class Function
    {
        public EchoRequest FunctionHandler(EchoRequest request)
        {
            var echoedMessage = request.Message;
            switch (request.Volume)
            {
                case Volume.Low: echoedMessage = echoedMessage.ToLower(); break;
                case Volume.High: echoedMessage = echoedMessage.ToUpper(); break;
            }

            var output = new EchoRequest
            {
                Message = echoedMessage,
                Volume = request.Volume,
                RequestTime = request.RequestTime,
                ResponseTime = DateTime.Now,
            };

            return output;
        }
    }
}
