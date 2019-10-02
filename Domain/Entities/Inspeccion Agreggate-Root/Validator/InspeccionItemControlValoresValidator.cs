using Domain.Core;
using Domain.Core.Specifications;
using Domain.Entities.Inspeccion_Agreggate_Root.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities.Inspeccion_Agreggate_Root.Validator
{
    public class InspeccionItemControlValoresValidator
    {
        private readonly bool lecturaItemControl;

        public InspeccionItemControlValoresValidator(bool lecturaItemControl)
        {
            this.lecturaItemControl = lecturaItemControl;
        }

        protected List<Specification<Inspeccion_ItemControl_Valores>> Rules
        {
            get
            {
                return new List<Specification<Inspeccion_ItemControl_Valores>>
                {
                    new InspeccionItemControlValoresSpecification.TipoLecturaItemInspeccionIdSpecification(),
                    new InspeccionItemControlValoresSpecification.TipoAccionRecomendadaIdSpecification(),
                    new InspeccionItemControlValoresSpecification.RequireLecturaItemControlSpecification(this.lecturaItemControl)
                };
            }
        }
        public bool IsValid(Inspeccion_ItemControl_Valores inspeccionICV)
        {
            return (BrokenRules(inspeccionICV).Count() == 0);
        }

        public IEnumerable<CenturyError> BrokenRules(Inspeccion_ItemControl_Valores inspeccionItemControlValores)
        {
            return Rules.Where(rule => !rule.IsSatisfiedBy(inspeccionItemControlValores))
                        .Select(rule => GetErrorsForBrokenRule(rule));
        }

        protected CenturyError GetErrorsForBrokenRule(Specification<Inspeccion_ItemControl_Valores> specInspeccionItemControlValores)
        {
            switch (specInspeccionItemControlValores.GetType().Name)
            {
                case nameof(InspeccionItemControlValoresSpecification.TipoLecturaItemInspeccionIdSpecification):
                    return new CenturyError(CenturyError.TipoError.ValorIncorrecto, "El TipoLecturaItemInspeccion Id es requerido", "TipoLecturaItemInspeccion");
                case nameof(InspeccionItemControlValoresSpecification.TipoAccionRecomendadaIdSpecification):
                    return new CenturyError(CenturyError.TipoError.ValorIncorrecto, "El TipoAccionRecomendada Id es requerido", "TipoAccionRecomendada"); 
                case nameof(InspeccionItemControlValoresSpecification.RequireLecturaItemControlSpecification):
                    return new CenturyError(CenturyError.TipoError.ValorIncorrecto, "El valorLectura es requerido por el ItemControl", "ItemControl");
                default:
                    break;
            }
            return null;
        }
    }
}
