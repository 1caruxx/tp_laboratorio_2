using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Becado,
            Deudor
        }

        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de la clase Alumno.
        /// </summary>
        public Alumno() : base()
        {
            this._claseQueToma = Universidad.EClases.Laboratorio;
            this._estadoCuenta = EEstadoCuenta.Deudor;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Alumno asignando a sus atributos, los datos que se le pasan como parametro.
        /// </summary>
        /// <param name="id">El legajo del alumno.</param>
        /// <param name="nombre">El nombre del alumon.</param>
        /// <param name="apellido">El apellido del alumno.</param>
        /// <param name="dni">El DNI del alumno.</param>
        /// <param name="nacionalidad">La nacionalidad del alumno.</param>
        /// <param name="claseQueToma">La clase a la cual concurre.</param>
        /// <param name="estadoCuenta">Su estado de la cuenta.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma):base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Alumno asignando a sus atributos, los datos que se le pasan como parametro.
        /// </summary>
        /// <param name="id">El legajo del alumno.</param>
        /// <param name="nombre">El nombre del alumon.</param>
        /// <param name="apellido">El apellido del alumno.</param>
        /// <param name="dni">El DNI del alumno.</param>
        /// <param name="nacionalidad">La nacionalidad del alumno.</param>
        /// <param name="claseQueToma">La clase a la cual concurre.</param>
        /// <param name="estadoCuenta">Su estado de la cuenta.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Retorna los datos del alumno.
        /// </summary>
        /// <returns>Un string con todos los datos del alumno.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder SB = new StringBuilder();

            SB.AppendLine(base.MostrarDatos());
            SB.AppendLine(this.ParticiparEnClase());
            SB.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta);

            return SB.ToString();
        }

        /// <summary>
        /// Retorna un String con la clase a la cual concurre el alumno.
        /// </summary>
        /// <returns>Un String con el literal "TOMA CLASE DE " al que se le concatena la clase que toma el alumno.</returns>
        protected override string ParticiparEnClase()
        {
            return string.Format("TOMA CLASE DE " + this._claseQueToma);
        }

        /// <summary>
        /// Hace publicos los datos del alumno.
        /// </summary>
        /// <returns>El metodo MostrarDatos()</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Operadores

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (a._estadoCuenta != EEstadoCuenta.Deudor && a._claseQueToma==clase);
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (a._claseQueToma != clase);
        }

        #endregion
    }
}
