namespace Videos.Data.Entities
{
    public class Film
    {
        public int Id { get; set; }
        public DateTime Released { get; set; }
        public int ProducerId { get; set; }
        public Producer? Producer { get; set; }
        public virtual ICollection<Genre>? Genres { get; set; }
    }
}
