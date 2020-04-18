using Amazon.DynamoDBv2.DataModel;
using System;

namespace PublisherApiSubscriberFunctions.src.Model
{
    [DynamoDBTable("Game")]
    public class Game
    {
        [DynamoDBHashKey]
        public long externalId { get; set; }

        [DynamoDBProperty]
        public string name { get; set; }

        [DynamoDBProperty]
        public string summary { get; set; }

        [DynamoDBProperty]
        public string publisher { get; set; }

        [DynamoDBProperty]
        public DateTime releaseDate { get; set; }

        [DynamoDBProperty]
        public string consoleName { get; set; }

        [DynamoDBProperty]
        public string consoleAbbreviation { get; set; }

        [DynamoDBProperty]
        public DateTime createdAt { get; set; }
    }
}
