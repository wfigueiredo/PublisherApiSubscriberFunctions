using PublisherApiSubscriberFunctions.src.Model;
using PublisherApiSubscriberFunctions.src.Util;
using System;
using static Amazon.Lambda.SQSEvents.SQSEvent;

namespace PublisherApiSubscriberFunctions.src.Translators
{
    public static class EntityTranslator
    {
        public static User ToUserDomain(this SQSMessage sqsMessage)
        {
            if (sqsMessage != null)
            {
                return JsonUtil.DeserializeContent<User>(sqsMessage.Body);
            }

            return null;
        }

        public static Game ToGameDomain(this SQSMessage sqsMessage)
        {
            if (sqsMessage != null)
            {
                var Game = JsonUtil.DeserializeContent<Game>(sqsMessage.Body);
                Game.createdAt = DateTime.Now;
                return Game;
            }

            return null;
        }
    }
}
