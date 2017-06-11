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

        static Profesor()
        {
            _random = new Random();
        }

        public Profesor()
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id,  nombre,  apellido,  dni,  nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        #endregion

        #region Metodos

        protected override string MostrarDatos()
        {
            StringBuilder SB = new StringBuilder();

            SB.AppendLine(base.MostrarDatos());
            SB.AppendLine(this.ParticiparEnClase());
            return base.MostrarDatos();
        }

        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                this._clasesDelDia.Enqueue((Universidad.EClases)_random.Next(0, 2));
            }
        }

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

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Operadores

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

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion
    }
}
