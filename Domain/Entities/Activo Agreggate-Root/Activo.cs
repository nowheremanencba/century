using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core;
using Domain.Core.Events;
using Domain.Specifications;
using Domain.Core.Specifications;
using System.Collections.ObjectModel;

namespace Domain.Entities
{
    public class Activo : Entity<Guid>, IAggregateRoot
    {
        public string Dominio { get; private set; }
        public int NumeroInterno { get; private set; }
        public string Año { get; private set; }   
        public Guid EmpleadoResponsableID { get; private set; }  // Se obtiene desde el microservicio de Clientes y Personas
        public string Chasis { get; private set; }
        public string Motor { get; private set; }
        public string Ubicacion { get; private set; }
        public DateTime FechaCompra { get; private set; }
        public int TipoModeloId { get; private set; }
        public virtual TipoModelo TipoModelo { get; private set; } 
        public int TipoActivoId { get; private set; }
        public virtual TipoActivo TipoActivo { get; private set; } 

        public virtual List<DocumentacionActivo> Documentos { get; private set; }

        public Activo()
        {}

        public Activo(Guid id, string dominio,int numeroInterno, int tipoModeloId,
                    int tipoActivoId,int tipoMarcaId, Guid empleadoResponsableId, 
                    string ubicacion, string chasis, string motor,
                    string año, DateTime fechaCompra, bool DomnioIsRequired)
        {
            this.Id = id;
            this.NumeroInterno = numeroInterno;
            this.Dominio = dominio; 
            this.TipoModeloId = tipoModeloId;
            this.TipoActivoId = tipoActivoId; 
            this.EmpleadoResponsableID = empleadoResponsableId;
            this.Ubicacion = ubicacion;
            this.Chasis = chasis;
            this.Motor = motor;
            this.Año = año;
            this.FechaCompra = fechaCompra; 
        }
               
        public void setDominio(string dominio)
        {
            this.Dominio = dominio;
        }

        public void AgregarDocumento(DocumentacionActivo doc)
        {
            if (this.Documentos is null)
                this.Documentos = new List<DocumentacionActivo>(); 
            this.Documentos.Add(doc);
        }

    }
}
