using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using PublisherApiSubscriberFunctions.src.Interfaces.Service;
using PublisherApiSubscriberFunctions.src.Translators;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace PublisherApiSubscriberFunctions
{
    public class Handler
    {
        /// <summary>
        /// Default constructor. This constructor is used by Lambda to construct the instance. When invoked in a Lambda environment
        /// the AWS credentials will come from the IAM role associated with the function and the AWS region will be set to the
        /// region the Lambda function is executed in.
        /// </summary>
        public Handler()
        {
        }

        public async Task UserInsert(SQSEvent sqsEvent, ILambdaContext context)
        {
            var userService = new UserService();
            foreach (var message in sqsEvent.Records)
            {
                await userService.Save(message.ToUserDomain());
                context.Logger.LogLine($"Successfully processed message {message.MessageId}");
            }
        }

        public async Task GameInsert(SQSEvent sqsEvent, ILambdaContext context)
        {
            var gameService = new GameService();
            foreach (var message in sqsEvent.Records)
            {
                await gameService.Save(message.ToGameDomain());
                context.Logger.LogLine($"Successfully processed message {message.MessageId}");
            }
        }
    }
}
