using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FormularioLoginYNomina.Form2;




namespace FormularioLoginYNomina
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }
        public class RegistroEmpleado
        {
            public string Nombre {  get; set; }
            public string Apellido { get; set; }
            public string Codigo { get; set; }
            public double SalarioBase { get; set; }
            public double SalarioBruto { get; set; }
            public double HorasTrabajadas { get; set; }
            public double HorasNormales { get; set; }
            public double HorasExtras { get; set; }
            public double HorasDobles { get; set; }
            public double SalarioExtra {  get; set; }
            public double SalarioDoble { get; set; }
            public double ARS {  get; set; }    
            public double AFP { get; set; }



        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            string nombre = textBox1.Text;
            string apellido = textBox2.Text;
            double salarioBase = double.Parse(textBox3.Text);
            int horasTrabajadas = int.Parse(textBox4.Text);
            string codigo = textBox5.Text;
            
            double salrioHora = salarioBase / 44;
            double horasNormales = horasTrabajadas - 44;
            double horasExtras;
            if(horasTrabajadas>44)
            {
                horasNormales = 44;

            }
            else
            {
                horasNormales = horasTrabajadas;
            }
            if (horasTrabajadas - horasNormales > 24)
            {
                 horasExtras = 24;
            }
            else
            {
                horasExtras = horasTrabajadas - horasNormales;
            }
            double horasDobles = horasTrabajadas - (horasNormales + horasExtras);



            double salarioNormal = horasNormales * salrioHora;
            double salarioExtra = horasExtras * salrioHora * 1.5; 
            double salarioDoble = horasDobles * salrioHora * 2; 

           
            double salarioBruto = salarioNormal + salarioExtra + salarioDoble;

           
            double afp = salarioBruto * 0.287; 
            double ars = salarioBruto * 0.0304; 

            
            double salarioNeto = salarioBruto - afp - ars;

            RegistroEmpleado registro = new RegistroEmpleado
            {
                Nombre = nombre,
                Apellido = apellido,
                Codigo = codigo,
                SalarioBase = salarioBase,
                HorasTrabajadas = horasTrabajadas,
                SalarioBruto = salarioNeto,
                HorasNormales = horasNormales,
                HorasExtras = horasExtras,
                HorasDobles = horasDobles,
                SalarioDoble=salarioDoble,
                SalarioExtra = salarioExtra,
                ARS = ars,
                AFP=afp,


            };
            dataGridView1.Rows.Add(
                registro.Nombre, 
                registro.Apellido,
                registro.Codigo, 
                registro.SalarioBase, 
                registro.HorasTrabajadas,
                registro.SalarioBruto,
                registro.HorasNormales,
                registro.HorasExtras,
                registro.HorasDobles,
                registro.SalarioDoble,
                registro.SalarioExtra,
                registro.ARS,
                registro.AFP);
        



            listBox1.Items.Add($"Salrio por hora: ${salrioHora:0.00}");
            listBox1.Items.Add($"Horas normales: ${horasNormales:0.00}");
            listBox1.Items.Add($"Horas extras: ${horasExtras:0.00}");
            listBox1.Items.Add($"Horas dobles: ${horasDobles:0.00}");
            listBox1.Items.Add($"Salario normal: ${salarioNormal:0.00}");
            listBox1.Items.Add($"Salario extra: ${salarioExtra:0.00}");
            listBox1.Items.Add($"Salario doble: ${salarioDoble:0.00}");
            listBox1.Items.Add($"Salario bruto: ${salarioBruto:0.00}");
            listBox1.Items.Add($"AFP: ${afp:0.00}");
            listBox1.Items.Add($"ARS: ${ars:0.00}");
            listBox1.Items.Add($"Salario neto: ${salarioNeto:0.00}");
        }
    }
}
