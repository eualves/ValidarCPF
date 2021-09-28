using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValidarCPF
{
    public partial class validadorCPF : Form
    {
        public validadorCPF()
        {
            InitializeComponent();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {

            string cpfdigitado = maskedTextBox1.Text.Replace(".","").Replace("-","").Replace(" ","");


            if (string.IsNullOrWhiteSpace(cpfdigitado))
            {
                lblResul.Text = "Digite o CPF";
                maskedTextBox1.Focus();
                maskedTextBox1.SelectAll();
                return;
            }

            if (cpfdigitado.Length != 11)
            {
                lblResul.Text = "Informe um CPF com 11 caracteres";
                lblResul.ForeColor= Color.Red;
                return;
            }

            //Separar os números em grupos

            string cpf = cpfdigitado.Substring(0, 9);

            int soma = 0;
            int valorRef = 10;

            for(int i = 0; i <= 8; i++)
            {
                soma += Convert.ToInt32(cpf[i].ToString()) * valorRef--;
            }

            int div1 = (int)soma % 11;

            if (div1 < 2)
            {
                div1 = 0;
            }
            else
            {
                div1 = 11 - div1;
            }

            if (!cpfdigitado.Substring(9, 1).Equals(div1.ToString()))
            {
                lblResul.Text = "Informe um CPF válido";
                lblResul.ForeColor = Color.Red;
                return;
            }

            //Calcular o segundo digito verificador

            soma = 0;
            valorRef = 11;

            cpf = cpf + div1;

            for (int i=0;i<=9; i++)
            {
                soma += Convert.ToInt32(cpf[i].ToString()) *valorRef--;
            }

            int div2 = (int)(soma % 11);

            if(div2 < 2)
            {
                div2 = 0;
            }
            else
            {
                div2 = 11 - div2;
            }

            if (!cpfdigitado.Substring(10, 1).Equals(div2.ToString()))
            {
                lblResul.Text = "CPF válido";
                lblResul.ForeColor = Color.Green;
                return;
            }
            lblResul.Text = "CPF válido";
            lblResul.ForeColor = Color.Green;
            return;
        }

        private void btnValidar_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnValidar.Enabled.ToString();
        }
    }
}
