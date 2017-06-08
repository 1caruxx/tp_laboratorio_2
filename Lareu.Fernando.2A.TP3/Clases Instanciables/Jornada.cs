using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;

namespace Clases_Instanciables
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

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

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
                    throw new AlumnoRepetidoException("Alumno repetido.");
                }
            }

            j._alumnos.Add(a);

            return j;
        }

        #endregion

        #region Metodos

        public override string ToString()
        {
            StringBuilder SB = new StringBuilder();

            SB.AppendLine("JORNADA:");
            SB.Append("CLASE DE: " + this._clase);
            SB.AppendLine(this._instructor.ToString());

            foreach (Alumno item in this._alumnos)
            {
                SB.AppendLine(item.ToString());
            }

            SB.AppendLine("<------------------------------------------------->");

            return base.ToString();
        }

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
