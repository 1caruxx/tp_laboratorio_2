using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
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
                if(Persona.ValidarDNI(this._nacionalidad, value) == 0)
                {
                    throw new DniInvalidoException("DNI introducido invalido.");
                }
                else
                {
                    if (Persona.ValidarDNI(this._nacionalidad, value) == -1)
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se concide con el numero de DNI.");
                    }
                    else
                    {
                        this._dni = value;
                    }
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
                int datoValidado = Persona.ValidarDNI(this._nacionalidad, value);

                if(datoValidado == 0)
                {
                    throw new DniInvalidoException("DNI introducido invalido.");
                }
                else
                {
                    if (datoValidado == -1)
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se concide con el numero de DNI.");
                    }
                    else
                    {
                        this._dni = datoValidado;
                    }
                }
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de la clase Persona.
        /// </summary>
        public Persona()
        {
            this._apellido = "Sin asignar";
            //this._nacionalidad = ENacionalidad.Extranjero;
            this._nombre = "Sin asignar";
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Persona asignando a sus atributos, los datos que se le pasan como parametro.
        /// </summary>
        /// <param name="nombre">El nombre de la persona.</param>
        /// <param name="apellido">El apellido de la persona.</param>
        /// <param name="nacionalidad">La nacionalidad de la persona.</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Apellido = apellido;
            this._nacionalidad = nacionalidad;
            this.Nombre = nombre;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Persona asignando a sus atributos, los datos que se le pasan como parametro.
        /// </summary>
        /// <param name="nombre">El nombre de la persona.</param>
        /// <param name="apellido">El apellido de la persona.</param>
        /// <param name="dni">El DNI de la persona.</param>
        /// <param name="nacionalidad">La nacionalidad de la persona.</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad):this(nombre, apellido, nacionalidad)
        {
            try
            {
                this.DNI = dni;
            }
            catch (DniInvalidoException excepcion)
            {
                throw new DniInvalidoException(excepcion);
            }
            catch (NacionalidadInvalidaException excepcion)
            {
                throw excepcion;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Persona asignando a sus atributos, los datos que se le pasan como parametro.
        /// </summary>
        /// <param name="nombre">El nombre de la persona.</param>
        /// <param name="apellido">El apellido de la persona.</param>
        /// <param name="dni">El DNI de la persona.</param>
        /// <param name="nacionalidad">La nacionalidad de la persona.</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            try
            {
                this.StringToDNI = dni;
            }
            catch (DniInvalidoException excepcion)
            {
                throw new DniInvalidoException(excepcion);
            }
            catch (NacionalidadInvalidaException excepcion)
            {
                throw excepcion;
            }
        }

        #endregion

        #region Validacion

        /// <summary>
        /// Valida que el numero que se le pasa como parametro sea mayor a 0 y menor a 90000000 en caso de que la nacionalidad sea argentina o que sea mayor a 89999999 si es extranjera.
        /// </summary>
        /// <param name="nacionalidad">La nacionalidad.</param>
        /// <param name="dato">El DNI.</param>
        /// <returns>0 si la nacionalidad es argentina y esta fuera de rango, -1 si la nacionalidad es extranjera y esta fuera de rango o el dato si esta dentro del rango.</returns>
        static int ValidarDNI(ENacionalidad nacionalidad , int dato)
        {
            if((nacionalidad == ENacionalidad.Argentino) && (dato < 1 || dato > 89999999))
            {
                return 0;
            }
            else
            {
                if (nacionalidad == ENacionalidad.Extranjero && dato < 89999999)
                {
                    return -1;
                }
            }

            return dato;
        }

        /// <summary>
        /// Valida que el literal que se le pasa como parametro sea valido como numero y que sea mayor a 0 y menor a 90000000 en caso de que la nacionalidad sea argentina o que sea mayor a 89999999 si es extranjera.
        /// </summary>
        /// <param name="nacionalidad">La nacionalidad.</param>
        /// <param name="dato">El DNI.</param>
        /// <returns>El metodo ValidarDNI.</returns>
        static int ValidarDNI(ENacionalidad nacionalidad, string dato)
        {
            int datoValidado;

            if(int.TryParse(dato , out datoValidado))
            {
                return ValidarDNI(nacionalidad, datoValidado);
            }

            return 0;
        }

        /// <summary>
        /// Valida que el String que se le pasa como parametro contenga caracteres validos para nombres y apellidos.
        /// </summary>
        /// <param name="dato">Un nombre o apellido.</param>
        /// <returns>El String validado o la cadena "Invalido" en caso de que contenga caracteres no validos.</returns>
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

        /// <summary>
        /// Retorna los datos de la persona.
        /// </summary>
        /// <returns>Un String con todos los datos de la persona.</returns>
        public override string ToString()
        {
            StringBuilder SB = new StringBuilder();

            SB.Append("NOMBRE COMPLETO: " + this._apellido);
            SB.AppendLine(", " + this._nombre);
            SB.AppendLine("NACIONALIDAD: " + this._nacionalidad);
            SB.AppendLine("DNI: " + this._dni);
            
            return SB.ToString();
        }
    }
}
