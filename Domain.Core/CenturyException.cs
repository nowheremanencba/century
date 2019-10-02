using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Domain.Core
{
    /// <summary>
    /// Representa una excepcion que ocurrió en la aplicacion Century
    /// </summary>
    public class CenturyException : Exception
    {
        public CenturyError CenturyError { get; private set; }
        
        public CenturyException() { }

        public CenturyException(CenturyError centuryError) : base(centuryError.Mensaje)
        {
            CenturyError = centuryError;
        }

        public CenturyException(CenturyError centuryError, Exception innerException)
            : base(centuryError.Mensaje, innerException)
        {
            CenturyError = centuryError;
        }
    }
}
