using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conversiones
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int numero, octal = 0, res, cos;
        double residuo = 0, ND  ;
        String resultado = "";
        String numeros, NB;
        char[] CharNum;
        double total = 0;
        int aux, Base;

        private void cmbBase_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Limpiar()
        {
            txtBaseEspecial.Clear();
            txtBinario.Clear();
            txtDecimal.Clear();
            txtHexa.Clear();
            txtNumero.Clear();
            txtOctal.Clear();
            cmbBase.Text = "Decimal";

        }

        private void BinarioDecimal()
        {
            //ESTE YA LO HICIERON 
        }

        private void DecimalBinario()
        {
            if (numero > 0)
            {
                String cadena = "";
                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    {
                        cadena = "0" + cadena;
                    }
                    else
                    {
                        cadena = "1" + cadena;
                    }
                    numero = (int)(numero / 2);
                }
                txtBinario.Text = Convert.ToString(cadena);
            }
        }

        private void DecimalOctal()
        {
            numero = int.Parse(txtNumero.Text);
            do
            {
                residuo = ((double)(numero)) / 8;
                numero = numero / 8;
                residuo = (residuo - numero) * 8;
                resultado = residuo + resultado;
            }
            while (numero != 0);
            txtOctal.Text = resultado;

        }

        private void DecimalHexa()
        {
            numero = int.Parse(txtNumero.Text);
            do
            {
                residuo = ((double)(numero)) / 16;
                numero = numero / 16;
                residuo = (residuo - numero) * 16;
                if (residuo == 10)
                    resultado = "A" + resultado;
                else if (residuo == 11)
                    resultado = "B" + resultado;
                else if (residuo == 12)
                    resultado = "C" + resultado;
                else if (residuo == 13)
                    resultado = "D" + resultado;
                else if (residuo == 14)
                    resultado = "E" + resultado;
                else if (residuo == 15)
                    resultado = "F" + resultado;
                else
                    resultado = residuo + resultado;
            }
            while (numero != 0);
            txtHexa.Text = resultado;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        public static void BloqueaNum(KeyPressEventArgs pE)
        {
            //Para obligar a que sólo se introduzcan números

            if (Char.IsDigit(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else if (Char.IsControl(pE.KeyChar)) //permitir teclas de control como retroceso
            {
                pE.Handled = false;
            }
            else if (Char.IsWhiteSpace(pE.KeyChar)) //no permitir teclas de control como espacio
            {
                pE.Handled = true;
            }
            else if (pE.KeyChar == '-')//no permitir tecla -
            {
                pE.Handled = true;
            }
            else if (pE.KeyChar == '2')//no permitir tecla -
            {
                pE.Handled = false;
            }
            else if (pE.KeyChar == '3')//no permitir tecla -
            {
                pE.Handled = true;
            }
            else if (pE.KeyChar == '4')//no permitir tecla -
            {
                pE.Handled = true;
            }
            else if (pE.KeyChar == '5')//no permitir tecla -
            {
                pE.Handled = true;
            }
            else if (pE.KeyChar == '6')//no permitir tecla -
            {
                pE.Handled = true;
            }
            else if (pE.KeyChar == '7')//no permitir tecla -
            {
                pE.Handled = true;
            }
            else if (pE.KeyChar == '8')//no permitir tecla -
            {
                pE.Handled = true;
            }
            else if (pE.KeyChar == '9')//no permitir tecla -
            {
                pE.Handled = true;
            }
            else if (Char.IsPunctuation(pE.KeyChar))// no permitir teclas de puntuacion
            {
                pE.Handled = true;
            }
            else //el resto de teclas pulsadas se desactivan
            {
                pE.Handled = true;
            }
        }
        private void btnMini_Click(object sender, EventArgs e)
        {
            lblConver.Visible = true;
            btnApagarInicio.Visible = true;
            ptbNe.Visible = true;
            btnQuitar.Visible = true;
            txtNumero.Focus();
        }

        private void btnCerra_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            if (MessageBox.Show("¿Desea Apagar el Teléfono?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
            else
            {
                this.txtNumero.Focus();
            }
        }

        private void btnConvertir_Click_1(object sender, EventArgs e)
        {
            try
            {
                numero = Convert.ToInt32(txtNumero.Text);
                int j = numero;
                if (cmbBase.Text == "Decimal")
                {
                    DecimalBinario();
                    DecimalOctal();
                    DecimalHexa();
                    txtBaseEspecial.Text = Convert.ToString("Sin base Especial");
                    txtDecimal.Text = Convert.ToString(j);
                }
                else if (cmbBase.Text == "Octal")
                {
                    OctalHexadecimal();
                    ConvertirABinario();

                }
                else if (cmbBase.Text != "Decimal")
                {
                    CualquierDecimal();
                }
                
                else
                {
                    MessageBox.Show("Ingresa una Base valida",
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Ingresa un número a combertir",
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Examen de Métodos Númericos, Lunes de 7pm a 9pm",
                "Recordatorio!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            BloqueaNum(e);
        }

        private void OctalHexadecimal()
        {    
               // int num = n;
                int dec_value = 0;

                // Initializing base value 
                // to 1, i.e 8^0
                int b_ase = 1;
                int temp = numero;
                while (temp > 0)
                {
                    // Extracting last digit
                    int last_digit = temp % 10;
                    temp = temp / 10;

                    // Multiplying last digit 
                    // with appropriate base 
                    // value and adding it to 
                    // dec_value
                    dec_value += last_digit * b_ase;

                    b_ase = b_ase * 8;
                txtHexa.Text = Convert.ToString(dec_value);
            }
        }

        private void btnApagarInicio_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void ptbNe_Click(object sender, EventArgs e)
        {

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            lblConver.Visible = false;
            btnApagarInicio.Visible = false;
            ptbNe.Visible = false;
            btnQuitar.Visible = false;
            txtNumero.Focus();
        }
        private void btnInicio_Click(object sender, EventArgs e)
        {
            lblConver.Visible = true;
            btnApagarInicio.Visible = true;
            ptbNe.Visible = true;
            btnQuitar.Visible = true;
            txtNumero.Focus();
        }

        private void ObtenerChars()
        {
            CharNum = numeros.ToCharArray();
        }
        private void CualquierDecimal() {
            total = 0;
            numeros = txtNumero.Text;
            Base = Convert.ToInt32(cmbBase.Text);
            ObtenerChars();
            for (int i = 0; i < numeros.Length; i++)
            {
                switch (CharNum[numeros.Length - (i + 1)])
                {
                    case '0': aux = 0; break;
                    case '1': aux = 1; break;
                    case '2': aux = 2; break;
                    case '3': aux = 3; break;
                    case '4': aux = 4; break;
                    case '5': aux = 5; break;
                    case '6': aux = 6; break;
                    case '7': aux = 7; break;
                    case '8': aux = 8; break;
                    case '9': aux = 9; break;
                    case 'A': aux = 10; break;
                    case 'B': aux = 11; break;
                    case 'C': aux = 12; break;
                    case 'D': aux = 13; break;
                    case 'E': aux = 14; break;
                    case 'F': aux = 15; break;
                    case 'G': aux = 16; break;
                    case 'H': aux = 17; break;
                    case 'I': aux = 18; break;
                    case 'J': aux = 19; break;
                }
                total = total + (aux * Math.Pow(Base, i));
            }
            txtBaseEspecial.Text = total.ToString();
        }

        private void ConvertirABinario()
        {
           // numero = String.Empty;

            cos = Convert.ToInt32(ND);
            res = 0;

            do
            {
                res = cos % 2;
                cos /= 2;
                NB += Convert.ToString(res);

            } while (cos != 0);

            NB = cambiar(NB);
            txtBinario.Text = Convert.ToString(NB);
        }
        private static String cambiar(String numero)
        {
            char[] arregloChars = numero.ToCharArray();
            Array.Reverse(arregloChars);
            return new String(arregloChars);
        }




    }
}
