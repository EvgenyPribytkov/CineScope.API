namespace Videos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly IDbService _db;

        public GenreController(IDbService db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IResult> Get() => await _db.HttpGetAsync<Genre, GenreDTO>();

        [HttpGet("{id:int}")]
        public async Task<IResult> Get(int id) => await _db.HttpGetAsync<Genre, GenreDTO>(id);

        [HttpPost]
        public async Task<IResult> Post([FromBody] GenreDTO dto) => await _db.HttpPostAsync<Genre, GenreDTO>(dto);

        [HttpPut("{id:int}")]
        public async Task<IResult> Put(int id, [FromBody] GenreDTO dto) => await _db.HttpPutAsync<Genre, GenreDTO>(id, dto);

        [HttpDelete("{id:int}")]
        public async Task<IResult> Put(int id) => await _db.HttpDeleteAsync<Genre>(id);
    }
}
