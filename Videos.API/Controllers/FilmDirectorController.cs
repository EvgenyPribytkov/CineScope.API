namespace Videos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmDirectorController : ControllerBase
    {
        private readonly IDbService _db;

        public FilmDirectorController(IDbService db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IResult> Post([FromBody] FilmDirectorDTO dto) => await _db.HttpPostAsyncRef<FilmDirector, FilmDirectorDTO>(dto);

        [HttpDelete]
        public async Task<IResult> Put(FilmDirectorDTO dto) => await _db.HttpDeleteAsyncRef<FilmDirector, FilmDirectorDTO>(dto);
    }
}
