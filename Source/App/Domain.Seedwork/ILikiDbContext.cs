﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Liki.Domain.Seedwork
{
    /// <summary>
    /// Stores object context
    /// </summary>
    public interface ILikiDbContext
    {
        #region Method
        
        /// <summary>
        /// Gets the db context for key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        DbContext GetDbContextForKey(string key);

        /// <summary>
        /// Sets the db context for key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="objectContext">The object context.</param>
        void SetDbContextForKey(string key, DbContext objectContext);

        /// <summary>
        /// Gets all db contexts.
        /// </summary>
        /// <returns></returns>
        IEnumerable<DbContext> GetAllDbContexts();
        #endregion
    }
}
