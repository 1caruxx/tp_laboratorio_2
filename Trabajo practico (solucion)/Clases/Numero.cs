using System;
using System.Collections.Generic;
using System.Text;

namespace Clases
{
    public class Numero
    {
        private double numero;

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string numero)
        {
            this.setNumero(numero);
        }

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

        public double getNumero()
        {
            return this.numero;
        }

        private void setNumero(string numero)
        {
            if (validarNumero(numero) != 0)
            {
                this.numero = double.Parse(numero);
            }
        }
    }
}