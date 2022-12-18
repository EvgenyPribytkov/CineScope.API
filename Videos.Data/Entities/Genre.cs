namespace Videos.Data.Entities;

public class Genre : IEntity
{
    [Required]
    public int Id { get; set; }
    [MaxLength(35), Required]
    public string Name { get; set; }
    public virtual ICollection<Film>? Films { get; set; }
}
