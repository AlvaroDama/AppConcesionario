using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConcesionario
{
    class Coche
    {
        public string Matricula { get; set; }
        public string Modelo { get; set; }
        public int AFabricacion { get; set; }

        public override string ToString()
        {
            return $"{Matricula} --> {Modelo} ({AFabricacion})";
        }
    }
}
