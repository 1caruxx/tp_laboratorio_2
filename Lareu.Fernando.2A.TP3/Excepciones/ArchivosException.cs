using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException:Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase ArchivosException asignandole el mensaje de error de la excepcion interna causante de esta excepcion.
        /// </summary>
        /// <param name="innerException">La excepcion causante de la excepcion actual.</param>
        public ArchivosException(Exception innerException) : base(innerException.InnerException.Message) { }
    }
}
