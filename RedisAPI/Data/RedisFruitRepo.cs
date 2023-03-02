using System.Text.Json;
using CacheService.Models;
using StackExchange.Redis;

namespace CacheService.Data
{
    public class RedisFruitRepo : IFruitRepo
    {
        private readonly IConnectionMultiplexer _redis;

        public RedisFruitRepo(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        public void CreateFruit(Fruit fruit)
        {
            if (fruit == null)
            {
                throw new ArgumentOutOfRangeException(nameof(fruit));
            }

            var db = _redis.GetDatabase();

            var serialPlat = JsonSerializer.Serialize(fruit);

            //db.StringSet(plat.Id, serialPlat);
            db.HashSet($"hashfruit", new HashEntry[] 
                {new HashEntry(fruit.Id, serialPlat)});
        }

        public Fruit? GetFruitById(string id)
        {
            var db = _redis.GetDatabase();

            //var plat = db.StringGet(id);

            var plat = db.HashGet("hashfruit", id);

            if (!string.IsNullOrEmpty(plat))
            {
                return JsonSerializer.Deserialize<Fruit>(plat);
            }
            return null;
        }

        public IEnumerable<Fruit?>? GetAllFruits()
        {
            var db = _redis.GetDatabase();

            var completeSet = db.HashGetAll("hashfruit");
            
            if (completeSet.Length > 0)
            {
                var obj = Array.ConvertAll(completeSet, val => 
                    JsonSerializer.Deserialize<Fruit>(val.Value)).ToList();
                return obj;   
            }
            
            return null;
        }
    }
}