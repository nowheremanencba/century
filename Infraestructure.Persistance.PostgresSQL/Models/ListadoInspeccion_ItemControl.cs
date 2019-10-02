using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Persistance.PostgresSQL.Models
{
    public class ListadoInspeccion_ItemControl
    {
        public int Orden { get;  set; }
        public Guid ListadoInspeccionId { get; set; }
        public int ItemControlId { get; set; }
    }
}
