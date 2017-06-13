using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;

        #region Constructores

        /// <summary>
        /// Inicializa una nueva instantcia del atributo estatico _random.
        /// </summary>
        static Profesor()
        {
            _random = new Random();
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Profesor y su atributo _clasesDelDia asignandole dos clases aleatorias generadas por el metodo _randomClases().
        /// </summary>
        public Profesor()
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        /// <summary>
        /// nicializa una nueva instancia de la clase Profesor y su atributo _clasesDelDia asignandole dos clases aleatorias generadas por el metodo _randomClases(). Asigna a sus atributos los datos que se le pasan como parametro.
        /// </summary>
        /// <param name="id">El legajo del profesor.</param>
        /// <param name="nombre">El nombre del profesor.</param>
        /// <param name="apellido">El apellido del profesor.</param>
        /// <param name="dni">El DNI del profesor.</param>
        /// <param name="nacionalidad">La nacionalidad del profesor.</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id,  nombre,  apellido,  dni,  nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Retorna los datos del profesor.
        /// </summary>
        /// <returns>Un string con todos los datos del profesor.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder SB = new StringBuilder();

            SB.AppendLine(base.MostrarDatos());
            SB.AppendLine(this.ParticiparEnClase());
            return SB.ToString();
        }

        /// <summary>
        /// Genera dos clases aleatorias y las asigna a la lista _clasesDelDia.
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                this._clasesDelDia.Enqueue((Universidad.EClases)_random.Next(0, 4));
            }
        }

        /// <summary>
        /// Retorna un String con las clases que puede dar el profesor.
        /// </summary>
        /// <returns>Un String con el literal "CLASES DEL DIA " al que se le concatena las clases que puede dar el profesor.</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder SB = new StringBuilder();

            SB.AppendLine("CLASES DEL DÍA ");

            foreach (Universidad.EClases item in this._clasesDelDia)
            {
                SB.AppendLine(item.ToString());
            }

            return SB.ToString();
        }

        /// <summary>
        /// Hace publicos los datos del profesor.
        /// </summary>
        /// <returns>El metodo MostrarDatos()</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Un profesor sera igual a una clase si en su lista _clasesDelDia contiene la clase.
        /// </summary>
        /// <param name="i">Un profesor.</param>
        /// <param name="clase">Una clase perteneciente al enumerado Universidad.EClases.</param>
        /// <returns>Retornara True en caso de que el profesor sea igual a la clase, False en caso contrario.</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases item in i._clasesDelDia)
            {
                if(item == clase)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// La negacion de la igualdad entre un profesor y una clase.
        /// </summary>
        /// <param name="i">Un profesor.</param>
        /// <param name="clase">Una clase perteneciente al enumerado Universidad.EClases.</param>
        /// <returns>Retornara True en caso de que el profesor sea diferente a la clase, False caso contrario.</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion
    }
}
