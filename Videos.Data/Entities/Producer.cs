﻿namespace Videos.Data.Entities
{
    public class Producer : IEntity
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(35), Required]
        public string Name { get; set; }
    }
}
