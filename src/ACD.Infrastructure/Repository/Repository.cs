using System.Linq.Expressions;
using ACD.Domain.Interfaces;
using ACD.Domain.Models;
using ACD.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;



namespace ACD.Infrastructure.Repository;



/// <summary>
/// Abstract base class representing a generic repository for managing entities.
/// </summary>
/// <typeparam name="TEntity">The type of entity managed by the repository.</typeparam>
public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{


    protected readonly ACDDbContext _db;

    protected readonly DbSet<TEntity> _dbSet;

    protected readonly ILogger<Repository<TEntity>> _logger;
    
    private ACDDbContext context;


    /// <summary>
    /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
    /// </summary>
    /// <param name="db">The database context.</param>
    /// <param name="logger">The logger.</param>
    public Repository(ACDDbContext db, ILogger<Repository<TEntity>> logger)
    {

        _db = db;
        _dbSet = db.Set<TEntity>();
        _logger = logger;

    }

    protected Repository(ACDDbContext context)
    {
        this.context = context;
    }


    /// <summary>
    /// Adds a new entity to the repository.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    public async Task Add(TEntity entity)
    {

        try
        {

            _dbSet.Add(entity);
            await SaveChanges();

        }
        catch (Exception e)
        {   
            _logger.LogError(e, "Error occurred while adding entity");
            throw;
        }

    }
    

    /// <summary>
    /// Retrieves all entities from the repository.
    /// </summary>
    public async Task<List<TEntity>> GetAll()
    {

        try
        {

            return await _dbSet.ToListAsync();

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while retrieving all entities");
            throw;
        }

    }


    /// <summary>
    /// Retrieves an entity by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity to retrieve.</param>
    public virtual async Task<TEntity> GetById(int id)
    {

        try
        {

            return await _dbSet.FindAsync(id);

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while retrieving entity by id");
            throw;
        }

    }


    /// <summary>
    /// Removes an entity from the repository.
    /// </summary>
    /// <param name="entity">The entity to remove.</param>
    public async Task Remove(TEntity entity)
    {

        try
        {
            
            _dbSet.Remove(entity);
            await SaveChanges();

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while removing entity");
            throw;
        }

    }


    /// <summary>
    /// Saves changes made in the repository.
    /// </summary>
    public async Task<int> SaveChanges()
    {

        try
        {

            return await _db.SaveChangesAsync();

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while saving changes");
            throw;
        }

    }


    /// <summary>
    /// Searches for entities in the repository based on a specified predicate.
    /// </summary>
    /// <param name="predicate">The predicate used to filter entities.</param>
    public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
    {

        try
        {
            
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while searching for entities");
            throw;
        }

    }


    /// <summary>
    /// Updates an existing entity in the repository.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    public async Task Update(TEntity entity)
    {
        
        try
        {

            _dbSet.Update(entity);
            await SaveChanges();

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while updating entity");
            throw;
        }

    }


    /// <summary>
    /// Updates a range of existing entities in the repository.
    /// </summary>
    /// <param name="entities">The entities to update.</param>
    public async Task UpdateRange(IEnumerable<TEntity> entities)
    {
        
        try
        {

            _dbSet.UpdateRange(entities);
            await SaveChanges();

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while updating range entities");
            throw;
        }

    }


    /// <summary>
    /// Disposes of the database context.
    /// </summary>
    public void Dispose()
    {
        _db?.Dispose();
    }


}