using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videos.Common.DTOs;

public class FilmDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime Released { get; set; }
    public int ProducerId { get; set; }
}
