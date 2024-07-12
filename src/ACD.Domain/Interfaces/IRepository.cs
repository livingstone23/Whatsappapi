using System.Linq.Expressions;
using ACD.Domain.Models;



namespace ACD.Domain.Interfaces;



/// <summary>
/// Generic repository interface for data access operations.
/// </summary>
/// <typeparam name="TEntity">The type of entity.</typeparam>
public interface IRepository<TEntity> : IDisposable where TEntity : Entity
{
    
    /// <summary>
    /// Adds a new entity to the repository.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    Task Add(TEntity entity);

    /// <summary>
    /// Retrieves all entities from the repository.
    /// </summary>
    /// <returns>A list of entities.</returns>
    Task<List<TEntity>> GetAll();

    /// <summary>
    /// Retrieves an entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity.</param>
    /// <returns>The entity with the specified identifier.</returns>
    Task<TEntity> GetById(int id);

    /// <summary>
    /// Updates an existing entity in the repository.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    Task Update(TEntity entity);

    /// <summary>
    /// Updates a range of entities in the repository.
    /// </summary>
    /// <param name="entities">The entities to update.</param>
    Task UpdateRange(IEnumerable<TEntity> entities);

    /// <summary>
    /// Removes an entity from the repository.
    /// </summary>
    /// <param name="entity">The entity to remove.</param>
    Task Remove(TEntity entity);

    /// <summary>
    /// Searches for entities based on a specified predicate.
    /// </summary>
    /// <param name="predicate">The predicate to filter entities.</param>
    /// <returns>A collection of entities matching the predicate.</returns>
    Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);

    /// <summary>
    /// Saves changes made to the repository.
    /// </summary>
    /// <returns>The number of entities affected.</returns>
    Task<int> SaveChanges();

}
