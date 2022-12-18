namespace Videos.Data.Entities
{
    public class Film : IEntity
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(35), Required]
        public string Title { get; set; }
        [Required]
        public DateTime Released { get; set; }
        [Required]
        public int ProducerId { get; set; }
        public Producer? Producer { get; set; }
        public virtual ICollection<Genre>? Genres { get; set; }
        public virtual ICollection<Director>? Directors { get; set; }
    }
}
