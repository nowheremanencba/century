using Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ListadoInspeccion : Entity<Guid>, IAggregateRoot
    {
        public string Descripcion { get; private set; }
        public int UnidadPeriodicidad { get; private set; }  
        public string TipoMedidaPeriodicidadId { get; private set; }
        public virtual TipoMedidaPeriodicidad TipoMedidaPeriodicidad { get; private set; }
   
        public virtual List<TipoActivo> TipoActivo { get; private set; }

        public virtual List<ItemControl> ItemControl { get; private set; }
         
        public ListadoInspeccion()
        { }
 
        public void SetDescripcion(string desc)
        {
            this.Descripcion = desc;
        } 
        public void SetUnidadPeriodicidad(int Id)
        {
            this.UnidadPeriodicidad = Id;
        }
        public void SetTipoMedidaPeriodicidadId(string Id)
        {
            this.TipoMedidaPeriodicidadId = Id;
        }
 
        public void AddItemControl(ItemControl itemControl)
        {
            if (this.ItemControl is null)
                this.ItemControl = new List<ItemControl>();
            this.ItemControl.Add(itemControl);
        }

        public void SetItemsControl(List<ItemControl> itemsControl) => ItemControl = itemsControl;
        public void SetTipoActivo(List<TipoActivo> tipoActivo) => TipoActivo = tipoActivo;
    }
}
