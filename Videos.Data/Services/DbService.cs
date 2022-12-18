using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Videos.Data.Contexts;
using Videos.Data.Interfaces;

namespace Videos.Data.Services;

public class DbService : IDbService
{
    private readonly VideoContext _db;
    private readonly IMapper _mapper;
    public DbService(VideoContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public async Task<List<TDto>> GetAsync<TEntity, TDto>()
        where TEntity: class, IEntity
        where TDto: class
    {
        var entity = await _db.Set<TEntity>().ToListAsync();
        return _mapper.Map<List<TDto>>(entity);
    }
    private async Task<TEntity?> SingleAsync<TEntity>(
        Expression<Func<TEntity, bool>> expression)
        where TEntity : class, IEntity =>
        await _db.Set<TEntity>().SingleOrDefaultAsync(expression);
    public async Task<TDto> SingleAsync<TEntity, TDto>(
        Expression<Func<TEntity, bool>> expression)
        where TEntity : class, IEntity
        where TDto : class
    {
        var entity = await SingleAsync(expression);
        return _mapper.Map<TDto>(entity);
    }
    public async Task<TEntity> AddAsync<TEntity, TDto>(TDto dto)
        where TEntity: class, IEntity
        where TDto: class
    {
        var entity = _mapper.Map<TEntity>(dto);
        await _db.Set<TEntity>().AddAsync(entity);
        return entity;
    }
    public async Task<TReferenceEntity> AddAsyncRef<TReferenceEntity, TDto>(TDto dto)
    where TReferenceEntity : class, IReferenceEntity
    where TDto : class
    {
        var entity = _mapper.Map<TReferenceEntity>(dto);
        await _db.Set<TReferenceEntity>().AddAsync(entity);
        return entity;
    }
    public async Task<bool> SaveChanges() 
        => await _db.SaveChangesAsync() >= 0;

    public string GetURI<TEntity>(TEntity entity)
        where TEntity: class, IEntity
    {
        return $"{typeof(TEntity).Name.ToLower()}s/{entity.Id}";
    }
    public void Update<TEntity, TDto>(int id, TDto dto)
        where TEntity : class, IEntity
        where TDto : class
    {
        var entity = _mapper.Map<TEntity>(dto);
        entity.Id = id;
        _db.Set<TEntity>().Update(entity);
    }
    public async Task<bool> AnyAsync<TEntity>(
        Expression<Func<TEntity, bool>> expression)
        where TEntity : class, IEntity
    {
        return await _db.Set<TEntity>().AnyAsync(expression);
    }
    public async Task<bool> DeleteAsync<TEntity>(int id)
        where TEntity : class, IEntity
    {
        try
        {
            var entity = await _db.Set<TEntity>().SingleAsync(e => e.Id == id);
            if (entity is null) return false;
            _db.Remove(entity);
        }
        catch (Exception)
        {
            throw;
        }
        return true;
    }

    public async Task<bool> Delete<TReferenceEntity, TDto>(TDto dto)
        where TReferenceEntity : class, IReferenceEntity
        where TDto : class
    {
        try
        {
            var entity = _mapper.Map<TReferenceEntity>(dto);
            if (entity is null) return false;
            _db.Remove(entity);
        }
        catch (Exception)
        {
            throw;
        }
        return true;
    }
}
