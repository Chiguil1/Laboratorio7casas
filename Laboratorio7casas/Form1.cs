using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio7casas
{
    public partial class Form1 : Form
    {
        List<Propietarios> pro = new List<Propietarios>();
        List<Casas> casas = new List<Casas>();
        List<Info> info = new List<Info>(); 

        public Form1()
        {
            InitializeComponent();
        }

        private void cargar_propietarios() {
            string fileName = "Propietarios.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Propietarios propietario = new Propietarios();
                propietario.Dpi = Convert.ToInt16(reader.ReadLine());
                propietario.Nombre = reader.ReadLine();
                propietario.Apellido = reader.ReadLine();

                pro.Add(propietario);

            }
            reader.Close();
        }

        private void cargar_propiedades() {
            string fileName = "Propiedades.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Casas propiedad = new Casas();
                propiedad.Num_casa = reader.ReadLine();
                propiedad.Dpi = Convert.ToInt16(reader.ReadLine());
                propiedad.Cuota = Convert.ToInt16(reader.ReadLine());

                casas.Add(propiedad);

            }
            reader.Close();
        }

        private void mostrar_propietarios() {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = pro;
            dataGridView1.Refresh();
        }

        private void mostrar_info() {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = info;
            dataGridView2.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar_propietarios();
            mostrar_propietarios();
            cargar_propiedades();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (info.Count == 0)
            {
                foreach (var propietarios in pro)
                {
                    Casas casa = casas.FirstOrDefault(c => c.Dpi == propietarios.Dpi);
                    if (casa != null)
                    {
                        Info datos = new Info();
                        datos.Nombre = propietarios.Nombre;
                        datos.Apellido = propietarios.Apellido;
                        datos.Num_casa = casa.Num_casa;
                        datos.Cuota_casa = casa.Cuota;
                        info.Add(datos);
                    }

                }
            }
            mostrar_info();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            info = info.OrderByDescending(a => a.Cuota_casa).ToList();
            mostrar_info();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
