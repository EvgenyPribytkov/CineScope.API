namespace Videos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProducerController : ControllerBase
    {
        private readonly IDbService _db;

        public ProducerController(IDbService db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IResult> Get() => await _db.HttpGetAsync<Producer, ProducerDTO>();

        [HttpGet("{id:int}")]
        public async Task<IResult> Get(int id) => await _db.HttpGetAsync<Producer, ProducerDTO>(id);

        [HttpPost]
        public async Task<IResult> Post([FromBody] ProducerDTO dto) => await _db.HttpPostAsync<Producer, ProducerDTO>(dto);

        [HttpPut("{id:int}")]
        public async Task<IResult> Put(int id, [FromBody] ProducerDTO dto) => await _db.HttpPutAsync<Producer, ProducerDTO>(id, dto);

        [HttpDelete("{id:int}")]
        public async Task<IResult> Put(int id) => await _db.HttpDeleteAsync<Producer>(id);
    }
}
