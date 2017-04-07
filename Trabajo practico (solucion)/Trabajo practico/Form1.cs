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

        public Form1()
        {
            InitializeComponent();
        }

        private void lblResultado_Click(object sender, EventArgs e)
        {  
        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {
        }

        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNumero1.Text = "0";
            this.txtNumero2.Text = "0";
            this.lblResultado.Text = "Resultado: ";
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            numero1 = new Numero(this.txtNumero1.Text);
            numero2 = new Numero(this.txtNumero2.Text);
            calculadora = new Calculadora();
            resultado = calculadora.operar(numero1 , numero2 , this.cmbOperacion.Text);
            this.lblResultado.Text = "Resultado: " + resultado.ToString();
        }
    }
}
