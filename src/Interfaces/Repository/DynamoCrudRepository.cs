using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using System.Threading.Tasks;

namespace PublisherApiSubscriberFunctions.src.Interfaces.Repository
{
    public class DynamoCrudRepository : ICrudRepository
    {
        private IAmazonDynamoDB client;
        private IDynamoDBContext dbContext;

        public DynamoCrudRepository()
        {
            var config = new DynamoDBContextConfig { Conversion = DynamoDBEntryConversion.V2 };
            client = new AmazonDynamoDBClient();
            dbContext = new DynamoDBContext(client, config);
        }
        public async Task SaveOrUpdate<T>(T t)
        {
            await dbContext.SaveAsync(t);
        }

        public async Task Delete<K, T>(K key)
        {
            await dbContext.DeleteAsync<T>(key);
        }

        public async Task<T> FindByPartitionKey<K, T>(K key)
        {
            return await dbContext.LoadAsync<T>(key);
        }
    }
}
