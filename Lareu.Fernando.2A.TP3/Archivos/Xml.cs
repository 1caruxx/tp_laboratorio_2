using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Excepciones;
using System.IO;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool guardar(string archivo, T datos)
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

        public bool leer(string archivo, out T datos)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(int));

            try
            {
                using (StreamReader lector = new StreamReader(archivo))
                {
                    datos = (T)serializador.Deserialize(lector);
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
