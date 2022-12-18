namespace Videos.API.Extensions;

public static class HttpExtensions
{
    public static async Task<IResult> HttpGetAsync<TEntity, TDto>(this IDbService db)
        where TEntity : class, IEntity
        where TDto : class
    {
        return Results.Ok(await db.GetAsync<TEntity, TDto>());
    }

    public static async Task<IResult> HttpGetAsync<TEntity, TDto>(this IDbService db, int id)
        where TEntity : class, IEntity
        where TDto : class
    {
        return Results.Ok(await db.SingleAsync<TEntity, TDto>(e => e.Id == id));
    }
    public static async Task<IResult> HttpPostAsync<TEntity, TDto>(this IDbService db, TDto dto)
        where TEntity : class, IEntity
        where TDto : class
    {
        if (dto is null) return Results.BadRequest();
        var entity = await db.AddAsync<TEntity, TDto>(dto);
        if(await db.SaveChanges())
        {
            var uri = db.GetURI<TEntity>(entity);
            return Results.Created(uri, entity);
        }
        return Results.BadRequest();
    }
    public static async Task<IResult> HttpPostAsyncRef<TReferenceEntity, TDto>(this IDbService db, TDto dto)
    where TReferenceEntity : class, IReferenceEntity
    where TDto : class
    {
        if (dto is null) return Results.BadRequest();
        var entity = await db.AddAsyncRef<TReferenceEntity, TDto>(dto);
        if (await db.SaveChanges())
            return Results.NoContent();

        return Results.BadRequest();
    }
    public static async Task<IResult> HttpPutAsync<TEntity, TDto>(this IDbService db, int id, TDto dto)
        where TEntity : class, IEntity
        where TDto : class
    {
        if(dto is null) return Results.BadRequest();
        if(!await db.AnyAsync<TEntity>(e => e.Id == id))
            return Results.NotFound();

        db.Update<TEntity, TDto>(id, dto);

        if(await db.SaveChanges())
            return Results.NoContent();

        return Results.BadRequest();
    }

    public static async Task<IResult> HttpDeleteAsync<TEntity>(this IDbService db, int id)
        where TEntity : class, IEntity
    {
        try
        {
            var success = await db.DeleteAsync<TEntity>(id);
            if (await db.SaveChanges())
                return Results.NoContent();
        }
        catch (Exception)
        {
            throw;
        }
        return Results.BadRequest();
    }

    public static async Task<IResult> HttpDeleteAsyncRef<TReferenceEntity, TDto>(this IDbService db, TDto dto)
    where TReferenceEntity : class, IReferenceEntity
    where TDto : class
    {
        try
        {
            var success = await db.Delete<TReferenceEntity, TDto>(dto);
            if (await db.SaveChanges())
                return Results.NoContent();
        }
        catch (Exception)
        {
            throw;
        }
        return Results.BadRequest();
    }
}
