namespace Videos.Data.Interfaces;

public interface IDbService
{
    public Task<List<TDto>> GetAsync<TEntity, TDto>()
    where TEntity : class, IEntity
    where TDto : class;
    public Task<TDto> SingleAsync<TEntity, TDto>(
        Expression<Func<TEntity, bool>> expression)
        where TEntity : class, IEntity
        where TDto : class;
    public Task<TEntity> AddAsync<TEntity, TDto>(TDto dto)
    where TEntity : class, IEntity
    where TDto : class;
    public Task<bool> SaveChanges();
    public string GetURI<TEntity>(TEntity entity)
    where TEntity : class, IEntity;
    public void Update<TEntity, TDto>(int id, TDto dto)
    where TEntity : class, IEntity
    where TDto : class;

    public Task<bool> AnyAsync<TEntity>(
    Expression<Func<TEntity, bool>> expression)
    where TEntity : class, IEntity;
    public Task<bool> DeleteAsync<TEntity>(int id)
    where TEntity : class, IEntity;
    public Task<TReferenceEntity> AddAsyncRef<TReferenceEntity, TDto>(TDto dto)
    where TReferenceEntity : class, IReferenceEntity
    where TDto : class;
    public Task<bool> Delete<TReferenceEntity, TDto>(TDto dto)
    where TReferenceEntity : class, IReferenceEntity
    where TDto : class;
}
