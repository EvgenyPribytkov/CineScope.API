namespace Videos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectorController : ControllerBase
    {
        private readonly IDbService _db;

        public DirectorController(IDbService db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IResult> Get() => await _db.HttpGetAsync<Director, DirectorDTO>();

        [HttpGet("{id:int}")]
        public async Task<IResult> Get(int id) => await _db.HttpGetAsync<Director, DirectorDTO>(id);

        [HttpPost]
        public async Task<IResult> Post([FromBody] DirectorDTO dto) => await _db.HttpPostAsync<Director, DirectorDTO>(dto);

        [HttpPut("{id:int}")]
        public async Task<IResult> Put(int id, [FromBody] DirectorDTO dto) => await _db.HttpPutAsync<Director, DirectorDTO>(id, dto);

        [HttpDelete("{id:int}")]
        public async Task<IResult> Put(int id) => await _db.HttpDeleteAsync<Director>(id);
    }
}
