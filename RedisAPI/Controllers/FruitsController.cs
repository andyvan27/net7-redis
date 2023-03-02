using CacheService.Data;
using CacheService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CacheService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsController : ControllerBase
    {
        private readonly IFruitRepo _repository;

        public FruitsController(IFruitRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Fruit>> GetFruits()
        {
            return Ok(_repository.GetAllFruits());
        }

        [HttpGet("{id}", Name="GetFruitById")]
        public ActionResult<IEnumerable<Fruit>> GetFruitById(string id)
        {
            
            var fruit = _repository.GetFruitById(id);
            
            if (fruit != null)
            {
                return Ok(fruit);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult <Fruit> CreateFruit(Fruit fruit)
        {
            _repository.CreateFruit(fruit);

            return CreatedAtRoute(nameof(GetFruitById), new {Id = fruit.Id}, fruit);
        }
    }
}