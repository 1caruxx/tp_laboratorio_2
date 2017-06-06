using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        #region Propiedades

        public string Apellido
        {
            get { return this._apellido; }
            set
            {
                if (Persona.ValidarNombreApellido(value) != "Invalido")
                {
                    this._apellido = value;
                }
            }
        }

        public int DNI
        {
            get { return this._dni; }
            set
            {
                if(Persona.ValidarDNI(this._nacionalidad , value) == 0)
                {
                    
                    throw new DniInvalidoException("DNI introducido invalido.");
                }
                else
                {
                    this._dni = value;
                }
            }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }

        public string Nombre
        {
            get { return this._nombre; }
            set
            {
                if(Persona.ValidarNombreApellido(value) != "Invalido")
                {
                    this._nombre = value;
                }
            }
        }

        public string StringToDNI
        {
            set
            {
                int datoValidado;

                if((datoValidado = Persona.ValidarDNI(this._nacionalidad , value)) == 0)
                {
                    
                    throw new DniInvalidoException("DNI introducido invalido.");
                }
                else
                {
                    this._dni = datoValidado; 
                }
            }
        }

        #endregion

        #region Constructores

        public Persona()
        {
            this._apellido = "Sin asignar";
            this._nacionalidad = ENacionalidad.Extranjero;
            this._nombre = "Sin asignar";
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Apellido = apellido;
            this._nacionalidad = nacionalidad;
            this.Nombre = nombre;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad):this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Validacion

        static int ValidarDNI(ENacionalidad nacionalidad , int dato)
        {
            if((nacionalidad == ENacionalidad.Argentino) && (dato < 1 || dato > 89999999))
            {
                return 0;
            }

            return dato;
        }

        static int ValidarDNI(ENacionalidad nacionalidad, string dato)
        {
            int entrada;

            if(int.TryParse(dato , out entrada))
            {
                return ValidarDNI(nacionalidad, entrada);
            }

            return 0;
        }

        static string ValidarNombreApellido(string dato)
        {
            bool esValido = true;

            foreach (char item in dato)
            {
                if ((item < 'a' || item > 'z') && (item < 'A' || item > 'Z'))
                {
                    esValido = false;
                    break;
                }
            }

            if (esValido)
            {
                return dato;
            }

            return "Invalido";
        }

        #endregion

        public override string ToString()
        {
            StringBuilder SB = new StringBuilder();

            SB.Append("NOMBRE COMPLETO: " + this._apellido);
            SB.AppendLine(", " + this._nombre);
            SB.AppendLine("DNI: " + this._dni);
            SB.AppendLine("NACIONALIDAD: " + this._nacionalidad);

            return SB.ToString();
        }
    }
}
