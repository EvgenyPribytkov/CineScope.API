namespace Videos.Data.Entities
{
    public class Director : IEntity
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(35), Required]
        public string Name { get; set; }
        public virtual ICollection<Film>? Films { get; set; }
    }
}
