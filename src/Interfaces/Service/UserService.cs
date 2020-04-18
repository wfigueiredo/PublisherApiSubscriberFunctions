using PublisherApiSubscriberFunctions.src.Interfaces.Repository;
using PublisherApiSubscriberFunctions.src.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PublisherApiSubscriberFunctions.src.Interfaces.Service
{
    public class UserService
    {
        private ICrudRepository crudRepository;

        public UserService()
        {
            crudRepository = new DynamoCrudRepository();
        }

        public Task Save(User user)
        {
            return crudRepository.SaveOrUpdate(user);
        }

        public async Task Delete(string email)
        {
            await crudRepository.Delete<string, User>(email);
        }

        public async Task<User> FindByPartitionKey(string email)
        {
            return await crudRepository.FindByPartitionKey<string, User>(email);
        }
    }
}
