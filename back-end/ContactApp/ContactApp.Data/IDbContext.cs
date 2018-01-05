using ContactApp.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ContactApp.Data
{
    /// <summary>
    /// DB context
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// Get DbSet
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>DbSet</returns>
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        /// <summary>
        /// Save changes
        /// </summary>
        /// <returns>Result</returns>
        int SaveChanges();

        void Dispose();

        /// <summary>
        /// Change tracking
        /// </summary>
        /// <returns>The entry.</returns>
        /// <param name="entity">Entity.</param>
        /// <typeparam name="TEntity">The 1st type parameter.</typeparam>
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : BaseEntity;

    }
}

