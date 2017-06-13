using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario:Persona
    {
        private int legajo;

        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de la clase Universitario.
        /// </summary>
        public Universitario() : base() { }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Universitario asignando a sus atributos, los datos que se le pasan como parametro.
        /// </summary>
        /// <param name="legajo">El legajo del universitario.</param>
        /// <param name="nombre">El nombre del universitario.</param>
        /// <param name="apellido">El apellido del universitario.</param>
        /// <param name="dni">El DNI del universitario.</param>
        /// <param name="nacionalidad">La nacionalidad del universitario.</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Retorna los datos del universitario.
        /// </summary>
        /// <returns>Un string con todos los datos del universitario.</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder SB = new StringBuilder();

            SB.AppendLine(base.ToString());
            SB.AppendLine("LEGAJO NUMERO: " + this.legajo);

            return SB.ToString();
        }

        /// <summary>
        /// Verifica que el objeto que se le pasa como parametro sea del tipo universitario.
        /// </summary>
        /// <param name="obj">Un objeto de cualquier tipo.</param>
        /// <returns>True en caso de que sea de tipo universitario o False en caso contrario.</returns>
        public override bool Equals(object obj)
        {
            return (obj is Universitario);
        }

        protected abstract string ParticiparEnClase();

        #endregion

        #region Operadores

        /// <summary>
        /// Dos universitarios seran iguales si son del mismo tipo y si algunos de sus atributos _dni o legajo tambien lo son.
        /// </summary>
        /// <param name="pg1">Un universitario.</param>
        /// <param name="pg2">Otro universitario distinto.</param>
        /// <returns>Retornara True en caso de que los universitarios sean iguales, False caso contrario.</returns>
        public static bool operator ==(Universitario pg1 , Universitario pg2)
        {
            return (pg1.Equals(pg2) && (pg1.DNI==pg2.DNI || pg1.legajo==pg2.legajo));
        }

        /// <summary>
        /// La negacion de la igualdad entre dos universitarios.
        /// </summary>
        /// <param name="pg1">Un universitario.</param>
        /// <param name="pg2">Otro universitario distinto.</param>
        /// <returns>Retornara True en caso de que los universitarios sean diferentes, False caso contrario.</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion
    }
}
