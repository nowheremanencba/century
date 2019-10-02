using Domain.Entities;
using Domain.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Interfaces.Repositories
{
    public interface IActivoRepository : IRepositoryBase<Activo>
    {
        Activo GetById(Guid id);
        bool GetDominioIsRequired(int id);
        IEnumerable<Activo> GetActivos();
        Activo GetActivoByDominio(string dominio);
        Activo GetActivoByNumeroInterno(int? numeroInterno);
        void Remove(DocumentacionActivo doc);
        DocumentacionActivo GetDocumentacionById(Guid id);
        IQueryable<DocumentacionActivo> Filter(Expression<Func<DocumentacionActivo, bool>> predicate);
    }
}
