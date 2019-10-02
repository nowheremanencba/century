﻿using System;
using System.Linq.Expressions;

namespace Domain.Core.Querying
{
    /// <summary>
    /// Represents that the implemented classes are where clause builders that
    /// build the WHERE clause for the SQL syntax for relational database systems.
    /// </summary>
    /// <typeparam name="TTableObject">The type of the data object which would be mapped to
    /// a certain table in the relational database.</typeparam>
    public interface IWhereClauseBuilder<TTableObject>
        where TTableObject : class, new()
    {
        /// <summary>
        /// Builds the WHERE clause from the given expression object.
        /// </summary>
        /// <param name="expression">The expression object.</param>
        /// <returns>The <c>Apworks.Storage.Builders.WhereClauseBuildResult</c> instance
        /// which contains the build result.</returns>
        WhereClauseBuildResult BuildWhereClause(Expression<Func<TTableObject, bool>> expression);
    }
}
