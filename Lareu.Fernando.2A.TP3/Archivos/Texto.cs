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
