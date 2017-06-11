using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Excepciones;
using System.IO;
using ClasesInstanciables;

namespace Archivos
{
    public class Xml<T> : IArchivo<Jornada>
    {
        /// <summary>
        /// Serializa y guarda en un archivo con extension .xml los datos que se le pasan como parametro.
        /// </summary>
        /// <param name="archivo">La ruta o el nombre del archivo en donde se desea serializar.</param>
        /// <param name="datos">Los datos que se desean serializar.</param>
        /// <returns>True si no se produjo ninguna excepcion.</returns>
        public bool guardar(string archivo, Jornada datos)
        {
            XmlSerializer serializador = new XmlSerializer(datos.GetType());

            try
            {
                using (StreamWriter escritor = new StreamWriter(archivo))
                {
                    serializador.Serialize(escritor , datos);
                }
            }
            catch (Exception excepcion)
            {
                throw new ArchivosException(excepcion);
            }

            return true;
        }

        /// <summary>
        /// Lee y desserializa los datos de un archivo de extension .xml que se le pasa como parametro y los retorna en forma de un objeto.
        /// </summary>
        /// <param name="archivo">La ruta o el nombre del archivo que se desea desserializar.</param>
        /// <param name="datos">La referencia en donde se guardaran los datos desserializados.</param>
        /// <returns></returns>
        public bool leer(string archivo, out Jornada datos)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(Jornada));

            try
            {
                using (StreamReader lector = new StreamReader(archivo))
                {
                    datos = (Jornada)serializador.Deserialize(lector);
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
