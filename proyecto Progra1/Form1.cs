using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_Progra1
{
    public partial class Form1 : Form
    {
        public Form1 ( )
        {
            InitializeComponent ( );
        }

        private void button1_Click ( object sender, EventArgs e )
        {

            
            //declaramos variables
        
            double dato1, dato2,resultado;

            
            //condicionamos excepciones para que no queden campos vacios
            if (string.IsNullOrEmpty ( txtDato1.Text ) || (string.IsNullOrEmpty ( txtDato2.Text )))
            {
                MessageBox.Show ( "ingrese datos en los campos","Error",MessageBoxButtons.OK,MessageBoxIcon.Error );
                return;
            }
            //asignamos valores a las variables

            dato1 = Convert.ToDouble ( txtDato1.Text );
            dato2 = Convert.ToDouble ( txtDato2.Text );



            //condicional para elegir la operacion a realizar
            
            int indice = lstOperacion.SelectedIndex;
            if (indice == 0)
            {
                resultado = dato1 + dato2;
                lblResultado.Text = (Convert.ToString ( "el Resultado es :" + resultado ));
            }else if (indice == 1)
            {
                resultado = dato1 - dato2;
                lblResultado.Text = (Convert.ToString ( "el Resultado es :" + resultado ));
            }else if (indice == 2)
            {
                resultado = dato1 * dato2;
                lblResultado.Text = (Convert.ToString ( "el Resultado es :" + resultado ));
            }else if (indice == 3)
            {
                resultado = dato1 / dato2;
                lblResultado.Text = (Convert.ToString ( "el Resultado es :" + resultado ));
            }
            else //este else nos envia un mensaje para no generar una excepcion por no haber marcado ningun operador en el listbox
            {
                MessageBox.Show ( "seleccione la operacion a realizar","Error",MessageBoxButtons.OK,MessageBoxIcon.Error );
            }
           
       

        }


        
        private void Form1_Load ( object sender, EventArgs e )
        {
            //asignamos texto a los label para hacer mas dinamico el programa
            lblResultado.Text = "En espera de datos";
            lblOperacion.Text = "Asigne Una Operacion de La Lista";
        }

        private void btnLimpiar_Click ( object sender, EventArgs e )
        {
            // con este metodo vamos a reiniciar los valores para un nuevo registro
            txtDato1.Clear ( );
            txtDato2.Clear ( );
            lblResultado.Text = "En espera de datos";
            lstOperacion.ClearSelected();

        }

       
        private void btnCerrar_Click ( object sender, EventArgs e )
        {
            // co esto mandamos a terminar el programa y cerrarlo
            Close ( );
        }

        private void lblOperacion_Click(object sender, EventArgs e)
        {

        }
        //este metodo es creado para que en los campos de numeros no se permita letras y ningun otro simbolo, tampoco permite que se escriba el punto decimal mas de una vez
        //con esto evitamos que se generen excepciones
        public void UnPunto(KeyPressEventArgs e, String cadena)
        {
            bool bandera;
            int contador = 0;
            string caracter = "";
            for (int n = 0; n < cadena.Length; n++)
            {
                caracter = cadena.Substring(n, 1);
                if (caracter == ".")
                {
                    contador++;
                }
            }
            if (contador == 0)
            {
                bandera = true;
                if (e.KeyChar == '.' && bandera)
                {
                    bandera = false; //ya no acepta otro punto
                    e.Handled = false;
                }
                else if (char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                bandera = false;
                e.Handled = true;
                if (char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
        //el evento keypress lo usamos para llamar el metodo un punto para que se ejecute en el campo txt
        private void txtDato1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //desde el evento keypress vamos a llamar el codigo UnPunto que usaremos para evitar
            //excepciones por digitar letras o valores no numericos en el textbox
            UnPunto(e, txtDato1.Text);
        }
        //llamamos al mismo metod para este evento y que no genere excepciones
        private void txtDato2_KeyPress(object sender, KeyPressEventArgs e)
        {
            UnPunto(e, txtDato2.Text);
        }
    }
}
