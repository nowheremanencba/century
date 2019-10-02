using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Domain.Core
{
    /// <summary>
    /// Representa un error que ocurrió en la aplicacion Century
    /// </summary>
    public class CenturyError 
    {
        [JsonProperty("codigo")]
        [JsonConverter(typeof(StringEnumConverter)) ]
        public TipoError Codigo { get; private set; }

        public string Mensaje { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Destino { get; private set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<CenturyError> Detalles { get; private set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public CenturyError InnerError { get; private set; }

        public CenturyError(TipoError codigo, string mensaje, string destino, IEnumerable<CenturyError> detalles = null, CenturyError innerError = null) 
        {
            Codigo = codigo;
            Mensaje = mensaje;
            Destino = destino;
            Detalles = detalles;
            InnerError = innerError;
        }

        /// <summary>
        /// Lista de errores posibles para un CenturyError
        /// </summary>
        public enum TipoError
        {
            NoEncontrado ,
            ErrorCommit ,
            ValorIncorrecto ,
            ErrorValidacion,
            NoPermitido,
            NoControlada
        }

    }
}
