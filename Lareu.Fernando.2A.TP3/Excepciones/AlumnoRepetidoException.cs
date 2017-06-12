using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException:Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase AlumnoRepetidoException asignandole el mensaje de error "Alumno repetido.".
        /// </summary>
        public AlumnoRepetidoException() : base("Alumno repetido.") { }
    }
}
