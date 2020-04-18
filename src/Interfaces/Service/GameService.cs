using PublisherApiSubscriberFunctions.src.Interfaces.Repository;
using PublisherApiSubscriberFunctions.src.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PublisherApiSubscriberFunctions.src.Interfaces.Service
{
    public class GameService
    {
        private ICrudRepository crudRepository;

        public GameService()
        {
            crudRepository = new DynamoCrudRepository();
        }

        public Task Save(Game game)
        {
            return crudRepository.SaveOrUpdate(game);
        }

        public async Task Delete(string externalId)
        {
            await crudRepository.Delete<string, Game>(externalId);
        }

        public async Task<Game> FindByPartitionKey(string externalId)
        {
            return await crudRepository.FindByPartitionKey<string, Game>(externalId);
        }
    }
}
