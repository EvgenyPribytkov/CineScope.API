namespace Videos.Data.Entities;

public class FilmDirector : IReferenceEntity
{
    [Required]
    public int FilmId { get; set; }
    [Required]
    public int DirectorId { get; set; }
}
