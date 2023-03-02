using System.ComponentModel.DataAnnotations;

namespace CacheService.Models
{
    public class Fruit
    {
        [Required]
        public string Id { get; set; } = $"fruit:{Guid.NewGuid().ToString()}";
        
        [Required]
        public string Name { get; set; } = String.Empty;
    }
}