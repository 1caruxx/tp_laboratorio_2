using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException:Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase NacionalidadInvalidaException.
        /// </summary>
        public NacionalidadInvalidaException() : base() { }

        /// <summary>
        /// Inicializa una nueva instancia de la clase NacionalidadInvalidaException asignandole el mensaje de error que se le pase como parametro.
        /// </summary>
        /// <param name="message">El mensaje de error.</param>
        public NacionalidadInvalidaException(string message) : base(message) { }
    }
}
