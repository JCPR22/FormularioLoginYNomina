using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormularioLoginYNomina
{
    public partial class Form1 : Form
    {

         int intentos = 3;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string usuario = textBox1.Text;
            string cont = textBox2.Text;

            while (intentos > 0)
            {
                if (usuario == "Jean" && cont == "1234")
                {

                    FormularioLoginYNomina.Form2 n1  = new FormularioLoginYNomina.Form2();
                    n1.ShowDialog();
                    //Form2.Show();
                    return;
                    

                }

                else
                {
                    
                    
                    MessageBox.Show($"Tines {intentos}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    textBox1.Clear();
                    textBox2.Clear();
                    intentos--;
                    return;
                     
                    
                }
            }
            MessageBox.Show("Has agotado tus intentos. La aplicación se cerrará.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();



        }
    }
}
