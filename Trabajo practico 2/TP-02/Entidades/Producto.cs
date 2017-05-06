using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    /// <summary>
    /// La clase Producto será abstracta, evitando que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        public enum EMarca
        {
            Serenisima,
            Campagnola,
            Arcor,
            Ilolay,
            Sancor,
            Pepsico
        }

        EMarca _marca;
        string _codigoDeBarras;
        ConsoleColor _colorPrimarioEmpaque;

        public Producto(EMarca marca, string codigoDeBarras, ConsoleColor color)
        {
            this._marca = marca;
            this._codigoDeBarras = codigoDeBarras;
            this._colorPrimarioEmpaque = color;
        }

        /// <summary>
        /// ReadOnly: Retornará la cantidad de calorias del producto.
        /// </summary>
        public abstract short CantidadCalorias { get; }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public abstract string Mostrar();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CODIGO DE BARRAS: " + this._codigoDeBarras + "\r\n");
            sb.AppendLine("MARCA           : " + this._marca.ToString() + "\r\n");
            sb.AppendLine("COLOR EMPAQUE   : " + this._colorPrimarioEmpaque.ToString() + "\r\n");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /*protected static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CODIGO DE BARRAS:  {0}\r\n", p._codigoDeBarras);
            sb.AppendLine("MARCA          : {0}\r\n", p._marca.ToString());
            sb.AppendLine("COLOR EMPAQUE  : {0}\r\n", p._colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }*/

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (v1._codigoDeBarras == v2._codigoDeBarras);
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1 == v2);
        }
    }
}
