using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda en un archivo de texto los datos que se le pasan como parametro.
        /// </summary>
        /// <param name="archivo">La ruta o el nombre del archivo.</param>
        /// <param name="datos">Los datos que se desean guardar.</param>
        /// <returns>True si no se produjo ninguna excepcion.</returns>
        public bool guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter(archivo))
                {
                    escritor.WriteLine(datos);
                }
            }
            catch (Exception excepcion)
            {
                throw new ArchivosException(excepcion);
            }

            return true;
        }

        /// <summary>
        /// Lee desde un archivo de texto los datos y los asigna a la referencia datos que se le pasa como parametro.
        /// </summary>
        /// <param name="archivo">La ruta o el nombre del archivo.</param>
        /// <param name="datos">La referencia en donde se guaradan los datos leidos.</param>
        /// <returns>True si no se produjo ninguna excepcion.</returns>
        public bool leer(string archivo, out string datos)
        {
            StringBuilder SB = new StringBuilder();
            string linea;

            try
            {
                using (StreamReader lector = new StreamReader(archivo))
                {
                    while((linea = lector.ReadLine()) != null)
                    {
                        SB.AppendLine(linea);
                    }

                    datos = SB.ToString();
                }
            }
            catch (Exception excepcion)
            {
                throw new ArchivosException(excepcion);
            }

            return true;
        }
    }
}
