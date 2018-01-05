using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ContactApp.Core;
using ContactApp.Core.Domain.Customers;
using ContactApp.Core.Domain.Enquiries;
using System.Reflection;

namespace ContactApp.Data
{
    /// <summary>
    /// Object context
    /// </summary>
    public class ContactAppContext : DbContext, IDbContext
    {
        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="options">use to create instance of this class</param>
        public ContactAppContext(DbContextOptions options) : base(options) { }

        #endregion


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Enquiry> Enquiries { get; set; }

        /// <summary>
        /// On model creating, configure mapping.
        /// </summary>
        /// <param name="modelBuilder">Model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().
                     SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Cascade;
            }

            //dynamically load all configurations.
            var typesToRegister = Assembly.GetExecutingAssembly()
                                          .GetTypes()
                                          .Where(type => !string.IsNullOrEmpty(type.Namespace))
                                          .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                                                 && type.BaseType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>));

            //Add loaded configurations.
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
            //...or do it manually below. For example,
            //modelBuilder.ApplyConfiguration(new CustomerConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        #region Methods

        /// <summary>
        /// Get DbSet
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>DbSet</returns>
        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        /// <summary>
        /// Entry for status tracking.
        /// </summary>
        public new EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            return base.Entry(entity);
        }

        //public new int SaveChanges()
        //{
        //    base.SaveChanges();
        //}

        /// <summary>
        /// Releases all resource used.
        /// </summary>
        public new void Dispose()
        {
            base.Dispose();
        }

        #endregion
    }
}