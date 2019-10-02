using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistance.PostgresSQL.Repositories
{
    public class ActivoRepository : BaseRepository<Activo>, IActivoRepository
    {
        public IEnumerable<Activo> GetActivos()
        {
            return base.GetAll();
        }

        protected new Activo GetById(object id) => base.GetById(id);

        public Activo GetById(Guid id)
        {            
            return base.GetById(id);
        }

        public TipoActivo GetTipoActivo(int id)
        {
            return db.Set<TipoActivo>().Find(id);
        }

        public bool GetDominioIsRequired(int idTipoActivo)
        {
            bool requerid =   (from  tipo in db.TipoActivo  
                                 where tipo.Id == idTipoActivo && tipo.DominioObligatorio == true 
                                 select tipo.DominioObligatorio 
                                ).FirstOrDefault();            
            return requerid;
        }

        public Activo GetActivoByDominio(string dominio)
        {
            Activo activo = (from ac in db.Activos 
                             where ac.Dominio.Trim().ToUpper()  == dominio.Trim().ToUpper()
                             select ac
                               ).FirstOrDefault();
            return activo;
        }

        public Activo GetActivoByNumeroInterno(int? numeroInterno)
        {
            Activo activo = (from ac in db.Activos
                             where ac.NumeroInterno == numeroInterno
                             select ac
                               ).FirstOrDefault();

            return activo;
        }

        #region DocumentacionActivo
        
        public DocumentacionActivo GetDocumentacionById(Guid id)
        {
            return db.Set<DocumentacionActivo>().Find(id);
        }

        public void Remove(DocumentacionActivo doc)
        {
             db.DocumentacionActivo.Remove(doc);
        }

        public IQueryable<DocumentacionActivo> Filter(Expression<Func<DocumentacionActivo, bool>> predicate)
        {
            return db.Set<DocumentacionActivo>().Where(predicate);
        }

        #endregion
    }
}
