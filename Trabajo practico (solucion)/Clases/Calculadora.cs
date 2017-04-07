using System;
using System.Collections.Generic;
using System.Text;

namespace Clases
{
    public class Calculadora
    {
        /// <summary>
        /// Realiza la operacion correspondiente segun el operador que se le pase como parametro.
        /// </summary>
        /// <param name="numero1">El numero con el que se realizara la operacion.</param>
        /// <param name="numero2">El numero con el que se realizara la operacion.</param>
        /// <param name="operador">El operador que determinara que tipo de operacion se realizara.</param>
        /// <returns>El resultado de la operacion (flotante).</returns>
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
                    if(numero2.getNumero() == 0)
                    {
                        resultado = 0;
                    }
                    else
                    {
                        resultado = numero1.getNumero() / numero2.getNumero();
                    }
                    
                    break;
            }

            return resultado;
        }

        /// <summary>
        /// Valida que el operador que se le pasa como parametro corresponda a los signos convencionales de la aritmetica basica. En caso de no serlo, asigna un "+" de forma arbitraria.
        /// </summary>
        /// <param name="operador">El operador a validar.</param>
        /// <returns>El operador validado (string).</returns>
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