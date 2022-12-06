using System.ComponentModel.DataAnnotations;

namespace Videos.Data.Entities
{
    public class Producer
    {
        public int Id { get; set; }
        [MaxLength(35), Required]
        public string Name { get; set; }
    }
}
