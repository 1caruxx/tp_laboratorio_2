using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using EntidadesAbstractas;
using System.Xml.Serialization;
using System.IO;

namespace ClasesInstanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Laboratorio,
            Programacion,
            Legislacion,
            SPD
        }

        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;

        #region Propiedades e Indexadores

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this.jornadas; }
            set { this.jornadas = value; }
        }

        public List<Profesor> Profesores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        public Jornada this[int indice]
        {
            get
            {
                if (indice < 0)
                {
                    return this.jornadas[0];
                }
                else
                {
                    if (indice >= 0 && indice < this.jornadas.Count)
                    {
                        return this.jornadas[indice];
                    }
                    else
                    {
                        return this.jornadas[(this.jornadas.Count) - 1];
                    }
                }
            }
            set
            {
                if(indice<0)
                {
                    this.jornadas[0] = value;
                }
                else
                {
                    if(indice>=0 && indice<this.jornadas.Count)
                    {
                        this.jornadas[indice] = value;
                    }
                    else
                    {
                        this.jornadas[(this.jornadas.Count)-1] = value;
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// Inicializa una nueva instancia de la clase Universidad asi como de sus atributos.
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornadas = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        #region Operadores

        /// <summary>
        /// Una universidad sera igual a un alumno si en su lista alumnos ya esta cargado.
        /// </summary>
        /// <param name="g">Una universidad.</param>
        /// <param name="a">Un alumno.</param>
        /// <returns>Retornara True en caso de que la universidad y el alumno sean iguales, False caso contrario.</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Universitario item in g.alumnos)
            {
                if(item == (Universitario)a)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Una universidad sera igual a un profesor si ese profesor da clases en alguna jornada.
        /// </summary>
        /// <param name="g">Una universidad.</param>
        /// <param name="i">Un profesor.</param>
        /// <returns>Retornara True en caso de que la universidad y el profesor sean iguales, False caso contrario.</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Jornada item in g.jornadas)
            {
                if (i == item.Clase)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Permite agregar una clase a la universidad, generando una Jornada con un profesor capaz de dar esa clase y una lista de alumnos que participen en ella.
        /// </summary>
        /// <param name="g">Una universidad.</param>
        /// <param name="clase">Una clase.</param>
        /// <returns>La universidad con la jornada aniadida.</returns>
        public static Universidad operator+(Universidad g, EClases clase)
        {
            Jornada jornada;
            Profesor profesorAuxiliar;

            try
            {
                profesorAuxiliar = g == clase;
            }
            catch (SinProfesorException excepcion)
            {
                throw excepcion;
            }

            jornada = new Jornada(clase, profesorAuxiliar);

            foreach (Alumno item in g.alumnos)
            {
                if(item == clase)
                {
                    jornada.Alumnos.Add(item);
                }
            }

            g.jornadas.Add(jornada);

            return g;
        }

        /// <summary>
        /// Sobrecarga del operador + que permite agregar un alumno a la lista alumnos en caso de que no haya sido previamente cargado.
        /// </summary>
        /// <param name="g">Una universidad.</param>
        /// <param name="a">Un alumno.</param>
        /// <returns>Retornara la universidad con el alumno cargado.</returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if(g == a)
            {
                throw new AlumnoRepetidoException();
            }
            else
            {
                g.alumnos.Add(a);
            }

            return g;
        }

        /// <summary>
        /// Sobrecargar del operador + que permite aniadir un profesor a la lista profesores en caso de que no haya sido prevviamente cargado.
        /// </summary>
        /// <param name="g">Una universidad.</param>
        /// <param name="i">Un profesor.</param>
        /// <returns>Retornara la universidad con el profesor cargado en caso de que se haya podido hacerlo.</returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            foreach (Universitario item in g.profesores)
            {
                if(item == (Universitario) i)
                {
                    return g;
                }
            }

            g.profesores.Add(i);

            return g;
        }

        /// <summary>
        /// Sobrecarga del operador == que retornara el primer profesor de la lista profesores capaz de dar la clase que se le pase como parametro.
        /// </summary>
        /// <param name="g">Una universidad.</param>
        /// <param name="clase">Una clase.</param>
        /// <returns>Retorna un profesor capaz de dar dicha clase.</returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            Profesor profesorAuxiliar = new Profesor();
            int contador = 0;

            foreach (Profesor item in g.profesores)
            {
                if (item == clase)
                {
                    profesorAuxiliar = item;
                    contador = -1;
                    break;
                }

                contador++;
            }

            if (contador == g.profesores.Count)
            {
                throw new SinProfesorException();
            }

            return profesorAuxiliar;
        }

        /// <summary>
        /// Negacion de la igualdad entre una universidad y un alumno.
        /// </summary>
        /// <param name="g">Una universidad.</param>
        /// <param name="a">Un alumno.</param>
        /// <returns>Retornara True en caso de que la universidad y el alumno sean diferentes, True caso contrario.</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Negacion de la igualdad entre una universidad y un alumno.
        /// </summary>
        /// <param name="g">Una universidad.</param>
        /// <param name="i">Un profesor.</param>
        /// <returns>Retornara True en caso de que la universidad y el profesor sean diferentes, True caso contrario.</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Sobrecargar del operador != que retornara el primer profesor de la lista profesores que no sea capaz de dar la clase que se pasa como parametro.
        /// </summary>
        /// <param name="g">Una universidad.</param>
        /// <param name="clase">Una clase.</param>
        /// <returns>Retornara un profesor que no sea capaz de dar dicha clase.</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            Profesor profesorAuxiliar = new Profesor();
            int contador = 0;

            foreach (Profesor item in g.profesores)
            {
                if (item != clase)
                {
                    profesorAuxiliar = item;
                    contador = -1;
                    break;
                }

                contador++;
            }

            if (contador == g.profesores.Count)
            {
                throw new SinProfesorException();
            }

            return profesorAuxiliar;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Retorna los datos de las jornadas de la universidad que se le pasa como parametro.
        /// </summary>
        /// <param name="gim">La universidad de la cual se quieren mostrar los datos.</param>
        /// <returns>Un string con todos los datos de las jornadas de la universidad.</returns>
        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder SB = new StringBuilder();

            foreach (Jornada item in gim.jornadas)
            {
                SB.AppendLine(item.ToString());
            }

            return SB.ToString();
        }

        /// <summary>
        /// Hace publicos los datos de las jornadas de la universidad.
        /// </summary>
        /// <returns>El metodo MostrarDatos()</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Serializa y guarda en un archivo con extension .xml los datos de una universidad que se le pasan como parametro.
        /// </summary>
        /// <param name="gim">La universidad de la cual se quieren serializar los datos.</param>
        /// <returns>True si no se produjo ninguna excepcion.</returns>
        public static bool Guardar(Universidad gim)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(Universidad));

            try
            {
                using (StreamWriter escritor = new StreamWriter("universidad.xml"))
                {
                    serializador.Serialize(escritor, gim);
                }
            }
            catch (Exception excepcion)
            {
                throw new ArchivosException(excepcion);
            }

            return true;
        }

        /// <summary>
        /// Lee y desserializa los datos de un archivo de extension .xml y los retorna en forma de un objeto de tipo Univesidad.
        /// </summary>
        /// <returns>Un objeto de tipo Universidad con los datos extraidos del archivo .xml.</returns>
        public static Universidad Leer()
        {
            Universidad universidadAuxiliar;
            XmlSerializer serializador = new XmlSerializer(typeof(Universidad));

            try
            {
                using (StreamReader lector = new StreamReader("universidad.xml"))
                {
                    universidadAuxiliar = (Universidad)serializador.Deserialize(lector);
                }
            }
            catch (Exception excepcion)
            {
                throw new ArchivosException(excepcion);
            }

            return universidadAuxiliar;
        }

        #endregion
    }
}
