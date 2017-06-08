using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException:Exception
    {
        private Exception _excepcion;

        public ArchivosException(Exception innerException)
        {
            this._excepcion = innerException.InnerException;
        }
    }
}
