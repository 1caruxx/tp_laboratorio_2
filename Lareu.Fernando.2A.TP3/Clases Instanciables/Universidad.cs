using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Laboratorio,
            Programacion,
            Legislacion
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

    }
}
