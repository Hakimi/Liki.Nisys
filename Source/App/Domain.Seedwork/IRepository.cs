using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Liki.Domain.Enums;
using Liki.Domain.Seedwork;


namespace Liki.Domain.Seedwork
{
    public interface IRepository<TEntity> : IDisposable
      where TEntity : Entity
    {
        #region Members
        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <value>The unit of work.</value>
        IUnitOfWork UnitOfWork { get; }
        #endregion

        #region Method

        /// <summary>
        /// Gets entity by key.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="keyValue">The key value.</param>
        /// <returns></returns>
        TEntity GetByKey(object keyValue);


        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        void Add(TEntity entity);

        /// <summary>
        /// Attaches the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        void Attach(TEntity entity);


        /// <summary>
        /// Updates changes of the existing entity. 
        /// The caller must later call SaveChanges() on the repository explicitly to save the entity to database
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Find  data
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        TEntity FindOne(Expression<Func<TEntity, bool>> criteria);
        #endregion
        
        
    }
}
