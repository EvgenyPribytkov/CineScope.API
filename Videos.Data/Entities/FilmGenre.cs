﻿namespace Videos.Data.Entities;

public class FilmGenre : IReferenceEntity
{
    [Required]
    public int FilmId { get; set; }
    [Required]
    public int GenreId { get; set; }
}
