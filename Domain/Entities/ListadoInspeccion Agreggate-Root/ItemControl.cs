using Domain.Core; 
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain.Entities
{
    public class ItemControl : Entity<int>
    {
        public string Nombre { get; private set; }
        public bool RealizarLectura { get; private set; }
        public string TipoRubroItemControlId { get; private set; }
        public virtual TipoRubroItemControl TipoRubroItemControl { get; private set; } 

        public ItemControl(int id, string nombre, bool realizarLectura, string tipoRubroItemControlId)
        {
            this.Id = id;
            this.Nombre = nombre; 
            this.RealizarLectura = realizarLectura;
            this.TipoRubroItemControlId = tipoRubroItemControlId;
        }
        public ItemControl(){}

 
        public void SetNombre(string nombre)
        {
            this.Nombre = nombre;
        }
        public void SetRealizarLectura(bool realizarLectura)
        {
            this.RealizarLectura = realizarLectura;
        }
        public void SetTipoRubroItemControlId(string TipoRubroItemControlId)
        {
            this.TipoRubroItemControlId = TipoRubroItemControlId;
        }
        

    }
}
