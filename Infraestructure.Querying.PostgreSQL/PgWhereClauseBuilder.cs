using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Querying;

namespace Infraestructure.Querying.PostgreSQL
{
    internal sealed class PgWhereClauseBuilder<TTableObject> : WhereClauseBuilder<TTableObject>
        where TTableObject : class, new()
    {
        protected override char ParameterChar => '@';
    }
}
