using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException:Exception
    {
        private string mensajeBase;

        /// <summary>
        /// Inicializa una nueva instancia de la clase DniInvalidoException.
        /// </summary>
        public DniInvalidoException() : base() { }

        /// <summary>
        /// Inicializa una nueva instancia de la clase DniInvalidoException asignandole el mensaje de error de la excepcion interna causante de esta excepcion.
        /// </summary>
        /// <param name="e">La excepcion causante de la excepcion actual.</param>
        public DniInvalidoException(Exception e) : base(e.Message)
        {
            this.mensajeBase = e.Message;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase DniInvalidoException asignandole el mensaje de error que se le pase como parametro.
        /// </summary>
        /// <param name="message">El mensaje de error.</param>
        public DniInvalidoException(string message) : base(message) { }

        /// <summary>
        /// Inicializa una nueva instancia de la clase DniInvalidoException asignandole el mensaje de error que se le pase como parametro y una referencia de la excepcion interna causante de esta excepcion.
        /// </summary>
        /// <param name="message">El mensaje de error.</param>
        /// <param name="e">La excepcion causante de la excepcion actual.</param>
        public DniInvalidoException(string message , Exception e) : base(message , e) { }
    }
}
