using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace AspNetCoreCqrsRedis.API.Query.Repository
{
    public class BaseRepository
    {
        private readonly IConnectionMultiplexer _redisConnection;
        private readonly string _namespace;

        protected BaseRepository(IConnectionMultiplexer redis, string nameSpace)
        {
            _redisConnection = redis;
            _namespace = nameSpace;
        }
        
        public T Get<T>(int id)
        {
            return Get<T>(id.ToString());
        }

        public T Get<T>(string keySuffix)
        {
            var key = MakeKey(keySuffix);
            var database = _redisConnection.GetDatabase();
            var serializedObject = database.StringGet(key);
            if (serializedObject.IsNullOrEmpty) throw new ArgumentNullException(); 
            return JsonConvert.DeserializeObject<T>(serializedObject.ToString());
        }

        public List<T> GetMultiple<T>(List<int> ids)
        {
            var database = _redisConnection.GetDatabase();
            var serializedItems = database.StringGet(ids.Select(MakeKey).Select(dummy => (RedisKey) dummy).ToArray(), CommandFlags.None);
            return serializedItems.Select(item => JsonConvert.DeserializeObject<T>(item.ToString())).ToList();
        }

        public bool Exists(int id)
        {
            return Exists(id.ToString());
        }

        public bool Exists(string keySuffix)
        {
            var key = MakeKey(keySuffix);
            var database = _redisConnection.GetDatabase();
            var serializedObject = database.StringGet(key);
            return !serializedObject.IsNullOrEmpty;
        }

        public void Save(int id, object entity)
        {
            Save(id.ToString(), entity);
        }

        public void Save(string keySuffix, object entity)
        {
            var key = MakeKey(keySuffix);
            var database = _redisConnection.GetDatabase();
            database.StringSet(MakeKey(key), JsonConvert.SerializeObject(entity));
        }

        public string MakeKey(int id)
        {
            return MakeKey(id.ToString());
        }

        public string MakeKey(string keySuffix)
        {
            if (!keySuffix.StartsWith(_namespace + ":"))
            {
                return _namespace + ":" + keySuffix;
            }
            else return keySuffix;
        }
    }
}