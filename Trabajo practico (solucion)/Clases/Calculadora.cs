using System;
using System.Collections.Generic;
using System.Text;

namespace Clases
{
    public class Calculadora
    {
        public double operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado = 0;

            operador = this.validarOperador(operador);

            switch (operador)
            {
                case "+":
                    resultado = numero1.getNumero() + numero2.getNumero();
                    break;
                case "-":
                    resultado = numero1.getNumero() - numero2.getNumero();
                    break;
                case "*":
                    resultado = numero1.getNumero() * numero2.getNumero();
                    break;
                case "/":
                    resultado = numero1.getNumero() / numero2.getNumero();
                    break;
            }

            return resultado;
        }

        public string validarOperador(string operador)
        {
            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
            {
                operador = "+";
            }

            return operador;
        }
    }
}