using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Specifications
{
    public interface IValidator<T>
    {
        bool IsValid(T entity);
        IEnumerable<CenturyError> BrokenRules(T entity);
    }
}
