using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        #region Propiedades

        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return this._clase; }
            set { this._clase = value; }
        }

        public Profesor Instructor
        {
            get { return this._instructor; }
            set { this._instructor = value; }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Incializa una nueva instancia de la clase Jornada y su atributo _alumnos.
        /// </summary>
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Jornada asignando a sus atributos, los datos que se le pasan como parametro.
        /// </summary>
        /// <param name="clase">La clase de esa jornada.</param>
        /// <param name="instructor">El profesor de esa jornada.</param>
        public Jornada(Universidad.EClases clase, Profesor instructor) :this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        #endregion

        #region Operadores

        public static bool operator ==(Jornada j, Alumno a)
        {
            return (a == j._clase);
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return (a != j._clase);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            foreach (Alumno item in j._alumnos)
            {
                if(j == a)
                {
                    throw new AlumnoRepetidoException();
                }
            }

            j._alumnos.Add(a);

            return j;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Retorna los datos del alumno.
        /// </summary>
        /// <returns>Un string con todos los datos de la jornada.</returns>
        public override string ToString()
        {
            StringBuilder SB = new StringBuilder();

            SB.AppendLine("JORNADA:");
            SB.Append("CLASE DE: " + this._clase);
            SB.AppendLine(" " + this._instructor.ToString());
            SB.AppendLine("ALUMNOS:");

            foreach (Alumno item in this._alumnos)
            {
                SB.AppendLine(item.ToString());
            }

            SB.AppendLine("<------------------------------------------------->");

            return SB.ToString();
        }

        /// <summary>
        /// Guarda en un archivo de texto los datos de la jornada.
        /// </summary>
        /// <param name="jornada">Una jornada cuyos datos se desean guardar.</param>
        /// <returns>True si no se produjo ninguna excepcion.</returns>
        public static bool Guardar(Jornada jornada)
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter("Jornada.txt"))
                {
                    escritor.WriteLine(jornada.ToString());
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }

            return true;
        }

        /// <summary>
        /// Lee desde un archivo de texto los datos y los retorna en forma de String.
        /// </summary>
        /// <returns>El String con los datos del archivo de texto.</returns>
        public static string Leer()
        {
            StringBuilder SB = new StringBuilder();
            string linea;

            try
            {
                using (StreamReader lector = new StreamReader("Jornada.txt"))
                {
                    while ((linea = lector.ReadLine()) != null)
                    {
                        SB.AppendLine(linea);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }

            return SB.ToString();
        }

        #endregion
    }
}
