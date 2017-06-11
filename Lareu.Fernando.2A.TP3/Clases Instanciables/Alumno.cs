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

        public Alumno() : base()
        {
            this._claseQueToma = Universidad.EClases.Laboratorio;
            this._estadoCuenta = EEstadoCuenta.Deudor;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma):base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Metodos

        protected override string MostrarDatos()
        {
            StringBuilder SB = new StringBuilder();

            SB.AppendLine(base.MostrarDatos());
            SB.AppendLine(this.ParticiparEnClase());
            SB.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta);

            return SB.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return string.Format("TOMA CLASE DE " + this._claseQueToma);
        }

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
