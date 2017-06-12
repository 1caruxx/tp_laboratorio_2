using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException:Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase SinProfesorException asignandole el mensaje de error "No hay profesor para la clase.".
        /// </summary>
        public SinProfesorException() : base("No hay profesor para la clase.") { }
    }
}
