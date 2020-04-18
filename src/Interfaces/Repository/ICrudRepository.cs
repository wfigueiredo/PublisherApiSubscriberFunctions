using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PublisherApiSubscriberFunctions.src.Interfaces.Repository
{
    public interface ICrudRepository
    {
        Task SaveOrUpdate<T>(T t);
        Task Delete<K, T>(K key);
        Task<T> FindByPartitionKey<K, T>(K key);
    }
}
