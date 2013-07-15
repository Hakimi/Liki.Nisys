using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Design.PluralizationServices;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using Liki.Domain.Enums;
using Liki.Domain.Seedwork;
using Liki.Infrastructure.Data;





namespace Liki.Infrastructure.Data.Seedwork
{
    public class Repository<TEntity> : IRepository <TEntity>
        where TEntity:Entity
    {
        #region Members
        private LikiDbContext _context;
        private IUnitOfWork unitOfWork;
        #endregion
        
        private readonly PluralizationService _pluralizer = PluralizationService.CreateService(CultureInfo.GetCultureInfo("en"));

        #region Constructors
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Repository&lt;TEntity&gt;"/> class.
        /// </summary>
        /// 
        public Repository()
            : this(DependencyResolver.Current.GetService<LikiDbContext>())
        {

        }
        //public GenericRepository()
        //    : this(string.Empty)
        //{
        //}

        
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository&lt;TEntity&gt;"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public Repository(LikiDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            _context = context;
        }

        #endregion
        
        #region Property
        public LikiDbContext DbContext
        {
            get
            {
                if (this._context == null)
                {
                    //if (this._connectionStringName == string.Empty)
                    //    this._context = DbContextManager.Current;
                    //else
                    //    this._context = DbContextManager.CurrentFor(this._connectionStringName);
                }
                return this._context;
            }
        }

        #endregion

        #region Method
        
        public TEntity GetByKey(object keyValue) 
        {
            EntityKey key = GetEntityKey(keyValue);

            object originalItem;
            if (((IObjectContextAdapter)DbContext).ObjectContext.TryGetObjectByKey(key, out originalItem))
            {
                return (TEntity)originalItem;
            }
            return default(TEntity);
        }

        private IQueryable<TEntity> GetQuery()
        {
            /* 
             * From CTP4, I could always safely call this to return an IQueryable on DbContext 
             * then performed any with it without any problem:
             */
            // return DbContext.Set<TEntity>();

            /*
             * but with 4.1 release, when I call GetQuery<TEntity>().AsEnumerable(), there is an exception:
             * ... System.ObjectDisposedException : The ObjectContext instance has been disposed and can no longer be used for operations that require a connection.
             */

            // here is a work around: 
            // - cast DbContext to IObjectContextAdapter then get ObjectContext from it
            // - call CreateQuery<TEntity>(entityName) method on the ObjectContext
            // - perform querying on the returning IQueryable, and it works!
            var entityName = GetEntityName();
            return ((IObjectContextAdapter)DbContext).ObjectContext.CreateQuery<TEntity>(entityName);
        }


        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            DbContext.Set<TEntity>().Add(entity);
        }

        public void Attach(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            DbContext.Set<TEntity>().Attach(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return GetQuery().AsEnumerable();
        }

        public TEntity Save(TEntity entity)
        {
            Add(entity);
            DbContext. SaveChanges();
            return entity;
        }

        public void Update(TEntity entity) 
        {
            var fqen = GetEntityName();

            object originalItem;
            EntityKey key = ((IObjectContextAdapter)DbContext).ObjectContext.CreateEntityKey(fqen, entity);
            if (((IObjectContextAdapter)DbContext).ObjectContext.TryGetObjectByKey(key, out originalItem))
            {
                ((IObjectContextAdapter)DbContext).ObjectContext.ApplyCurrentValues(key.EntitySetName, entity);
            }
        }

        public TEntity FindOne(Expression<Func<TEntity, bool>> criteria)
        {
            return GetQuery().Where(criteria).FirstOrDefault();
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                if (unitOfWork == null)
                {
                    unitOfWork = new UnitOfWork(this.DbContext);
                }
                return unitOfWork;
            }
        }

        private EntityKey GetEntityKey(object keyValue)
        {
            var entitySetName = GetEntityName();
            var objectSet = ((IObjectContextAdapter)DbContext).ObjectContext.CreateObjectSet<TEntity>();
            var keyPropertyName = objectSet.EntitySet.ElementType.KeyMembers[0].ToString();
            var entityKey = new EntityKey(entitySetName, new[] { new EntityKeyMember(keyPropertyName, keyValue) });
            return entityKey;
        }

        private string GetEntityName() 
        {
            return string.Format("{0}.{1}", ((IObjectContextAdapter)DbContext).ObjectContext.DefaultContainerName, _pluralizer.Pluralize(typeof(TEntity).Name));
        }
        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion


     
    }
}
