using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;
using System.Windows.Forms;

namespace Hilo
{
    public delegate void ActualizadorDeProgreso(int progreso);
    public delegate void OperacionFinalizada(string dato);

    public class Descargador
    {
        public event ActualizadorDeProgreso porcentageEvento;
        public event OperacionFinalizada resultadoEvento;
        private string html;
        private Uri direccion;

        public Descargador(Uri direccion)
        {
            this.html = direccion.ToString();
            this.direccion = direccion;
        }

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += new DownloadProgressChangedEventHandler(WebClientDownloadProgressChanged);
                cliente.DownloadStringCompleted += new DownloadStringCompletedEventHandler(WebClientDownloadCompleted);

                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.porcentageEvento(e.ProgressPercentage);
        }
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)
            {
                this.resultadoEvento(e.Result);
            }
        }
    }
}
