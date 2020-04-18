using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublisherApiSubscriberFunctions.src.Model
{
    [DynamoDBTable("User")]
    public class User
    {
        [DynamoDBProperty]
        public string name { get; set; }

        [DynamoDBHashKey]
        public string emailAddress { get; set; }

        [DynamoDBProperty]
        public string phoneNumber { get; set; }
    }
}
