var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<VideoContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("VideoConnection")));

ConfigAutoMapper(builder.Services);
RegisteredServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
void ConfigAutoMapper(IServiceCollection services)
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Film, FilmDTO>().ReverseMap();
        cfg.CreateMap<FilmGenre, FilmGenreDTO>().ReverseMap();
        cfg.CreateMap<Genre, GenreDTO>().ReverseMap();
        cfg.CreateMap<Producer, ProducerDTO>().ReverseMap();
        cfg.CreateMap<Director, DirectorDTO>().ReverseMap();
        cfg.CreateMap<FilmDirector, FilmDirectorDTO>().ReverseMap();
    });
    var mapper = config.CreateMapper();
    services.AddSingleton(mapper);
}
void RegisteredServices(IServiceCollection services)
{
    services.AddScoped<IDbService, DbService>();
}