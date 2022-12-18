namespace Videos.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class FilmsController : ControllerBase
{
    private readonly IDbService _db;

    public FilmsController(IDbService db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IResult> Get() => await _db.HttpGetAsync<Film, FilmDTO>();

    [HttpGet("{id:int}")]
    public async Task<IResult> Get(int id) => await _db.HttpGetAsync<Film, FilmDTO>(id);

    [HttpPost]
    public async Task<IResult> Post([FromBody] FilmDTO dto) => await _db.HttpPostAsync<Film, FilmDTO>(dto);

    [HttpPut("{id:int}")]
    public async Task<IResult> Put(int id, [FromBody] FilmDTO dto) => await _db.HttpPutAsync<Film, FilmDTO>(id, dto);

    [HttpDelete("{id:int}")]
    public async Task<IResult> Put(int id) => await _db.HttpDeleteAsync<Film>(id);
}
