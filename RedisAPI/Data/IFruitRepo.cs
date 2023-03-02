using CacheService.Models;

namespace CacheService.Data
{
    public interface IFruitRepo
    {
        void CreateFruit(Fruit fruit);
        Fruit? GetFruitById(string id);
        IEnumerable<Fruit?>? GetAllFruits();
    }
}