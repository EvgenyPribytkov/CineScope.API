namespace Videos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmGenreController : ControllerBase
    {
        private readonly IDbService _db;

        public FilmGenreController(IDbService db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IResult> Post([FromBody] FilmGenreDTO dto) => await _db.HttpPostAsyncRef<FilmGenre, FilmGenreDTO>(dto);

        [HttpDelete]
        public async Task<IResult> Put(FilmGenreDTO dto) => await _db.HttpDeleteAsyncRef<FilmGenre, FilmGenreDTO>(dto);
    }
}
