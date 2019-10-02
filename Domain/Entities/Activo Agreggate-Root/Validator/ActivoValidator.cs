using System;
using System.Collections.Generic;
using System.Text;
using Domain.Core.Specifications;
using Domain.Entities;
using Domain.Core;
using System.Linq;
using Domain.Entities.Persona_Raiz_Agregada;
using Domain.Interfaces.Repositories;

namespace Domain.Specifications
{
    public class ActivoValidator : IValidator<Activo>
    { 
        private readonly bool EsDominioRequerido; 

        protected List<Specification<Activo>> Rules
        {
            get { return new List<Specification<Activo>>
                {
                new ActivoSpecification.DominioOkSpecification(this.EsDominioRequerido),
                new ActivoSpecification.UbicacionSpecification(),
                new ActivoSpecification.FechaCompraSpecification(),
                new ActivoSpecification.TipoActivoSpecification(),
                new ActivoSpecification.TipoModeloSpecification()
            };  } 
        }

        public ActivoValidator(bool dominioRequerido)
        {
            EsDominioRequerido = dominioRequerido; 
        } 

        public bool IsValid(Activo activo)
        {            
            return (BrokenRules(activo).Count() == 0);
        }

        public IEnumerable<CenturyError> BrokenRules(Activo activo)
        {
            return Rules.Where(rule => !rule.IsSatisfiedBy(activo)) 
                        .Select(rule => GetErrorsForBrokenRule(rule));
        }
       
        protected CenturyError GetErrorsForBrokenRule(Specification<Activo> specActivo)
        {
            switch (specActivo.GetType().Name)
            {
                case nameof(ActivoSpecification.DominioOkSpecification):
                    return new CenturyError(CenturyError.TipoError.ValorIncorrecto, "El dominio es requerido por el tipo de activo ingresado", "Activo");
                case nameof(ActivoSpecification.UbicacionSpecification):
                    return new CenturyError(CenturyError.TipoError.ValorIncorrecto, "La ubicacion no puede estar vacio o nulo", "Ubicacion");
                case nameof(ActivoSpecification.FechaCompraSpecification):
                    return new CenturyError(CenturyError.TipoError.ValorIncorrecto, "La fecha de compra no puede ser mayor a hoy", "FechaCompra");
                case nameof(ActivoSpecification.TipoActivoSpecification):
                    return new CenturyError(CenturyError.TipoError.ValorIncorrecto, "El tipo de activo no puede ser cero, vacio o nulo", "Tipo de Activo");
                case nameof(ActivoSpecification.TipoModeloSpecification):
                    return new CenturyError(CenturyError.TipoError.ValorIncorrecto, "El tipo de modelo no puede ser cero, vacio o nulo", "Tipo de Modelo");
                default:
                    break;
            }
            return null;
        }
    }
}
