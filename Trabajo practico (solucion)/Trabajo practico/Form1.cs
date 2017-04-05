using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;

namespace Trabajo_practico
{
    public partial class Form1 : Form
    {
        Numero numero1;
        Numero numero2;
        Calculadora calculadora;
        double resultado;
        string operacion;

        public Form1()
        {
            InitializeComponent();
        }

        private void lblResultado_Click(object sender, EventArgs e)
        {

        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {
            numero1 = new Numero(this.txtNumero1.Text);
        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {
            numero2 = new Numero(this.txtNumero2.Text);
        }

        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            operacion = this.cmbOperacion.Text;
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
          //calculadora = new Calculadora();
            resultado = calculadora.operar(numero1 , numero2 , operacion);
        }
    }
}
