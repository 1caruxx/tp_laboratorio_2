using System;
using System.Collections.Generic;
using System.Text;

namespace Clases
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Constructor por defecto de el objeto de tipo Numero.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor del objeto de tipo Numero que setea el atributo numero segun el flotante que se le pase como parametro.
        /// </summary>
        /// <param name="numero">El numero que se desea asignar (flotante).</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor del objeto de tipo Numero que setea el atributo numero segun el string que se le pase como parametro.
        /// </summary>
        /// <param name="numero">El numero que se desea asignar (string).</param>
        public Numero(string numero)
        {
            this.setNumero(numero);
        }

        /// <summary>
        /// Valida que el string que se le pasa como parametro sea un numero. Si no es validado se retorna un cero (0) de forma arbitraria.
        /// </summary>
        /// <param name="numeroString">El numero a validar.</param>
        /// <returns>El numero validado (flotante).</returns>
        private double validarNumero(string numeroString)
        {
            double numero;

            if (double.TryParse(numeroString, out numero))
            {
                return numero;
            }
            else
            {
                numero = 0;
                return numero;
            }
        }

        /// <summary>
        /// Retorna el valor que contiene el atributo privado numero del objeto de tipo Numero.
        /// </summary>
        /// <returns></returns>
        public double getNumero()
        {
            return this.numero;
        }

        /// <summary>
        /// Parsea el string que se le pasa como parametro y se lo asigna al atributo numero del objeto de tipo Numero.
        /// </summary>
        /// <param name="numero">El string a asignar.</param>
        private void setNumero(string numero)
        {
            if (validarNumero(numero) != 0)
            {
                this.numero = double.Parse(numero);
            }
        }
    }
}