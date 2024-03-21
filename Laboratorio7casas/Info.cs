using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio7casas
{
    internal class Info
    {
        string nombre;
        string apellido;
        string num_casa;
        int cuota_casa;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Num_casa { get => num_casa; set => num_casa = value; }
        public int Cuota_casa { get => cuota_casa; set => cuota_casa = value; }
    }
}
