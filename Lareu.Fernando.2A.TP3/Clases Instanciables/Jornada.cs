﻿using System;
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

        /// <summary>
        /// Propiedad de lectura y escritura que permite retornar y asignar la instancia de la lista _alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura que permite retornar y asignar el atributo _clase.
        /// </summary>
        public Universidad.EClases Clase
        {
            get { return this._clase; }
            set { this._clase = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura que permite retornar y asignar el atributo _instructor.
        /// </summary>
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

        /// <summary>
        /// Una jornada sera igual a un alumno si ese alumno es igual al atributo _clase de la jornada.
        /// </summary>
        /// <param name="j">Una jornada.</param>
        /// <param name="a">Un alumno.</param>
        /// <returns>Retornara True en caso de que la jornada sea igual al alumno, False en caso contrario.</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return (a == j._clase);
        }

        /// <summary>
        /// La negacion de la igualdad entre una jornada y un alumno.
        /// </summary>
        /// <param name="j">Una jornada.</param>
        /// <param name="a">Un alumno.</param>
        /// <returns>Retornara True en caso de que la jornada y el alumno sean diferentes, False caso contrario.</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return (a != j._clase);
        }

        /// <summary>
        /// Sobrecargar del operador + que permite agregar a un alumno a la lista _alumnos verificando que no este previamente cargado.
        /// </summary>
        /// <param name="j">Una jornada.</param>
        /// <param name="a">Un alumno.</param>
        /// <returns>Retorna la jornada que se le pasa como parametro con el alumno cargado en caso de que se haya podido hacerlo.</returns>
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
