using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConcesionario
{
    class Program
    {

        #region Concesionario
        public static List<Coche> Concesionario = new List<Coche>()
        {
            new Coche() {AFabricacion = 1999, Matricula = "5362HGD", Modelo = "Seat Panda"},
            new Coche() {AFabricacion = 2010, Matricula = "1662JHK", Modelo = "Renault Megane"},
            new Coche() {AFabricacion = 2006, Matricula = "3110OIU", Modelo = "Toyota Yaris"},
            new Coche() {AFabricacion = 1996, Matricula = "1948PLI", Modelo = "Citroen Xsara"},
            new Coche() {AFabricacion = 2014, Matricula = "1536ABH", Modelo = "Citroen C4"},
            new Coche() {AFabricacion = 2003, Matricula = "9524XSC", Modelo = "Mini Cooper"},
            new Coche() {AFabricacion = 2005, Matricula = "0525XXV", Modelo = "Volkswagen Beetle"},
            new Coche() {AFabricacion = 1997, Matricula = "2000ZER", Modelo = "Citroen Xsara"},
            new Coche() {AFabricacion = 1996, Matricula = "1988PFI", Modelo = "Mini"},
            new Coche() {AFabricacion = 1996, Matricula = "3564PLI", Modelo = "Citroen C4"},
            new Coche() {AFabricacion = 1996, Matricula = "5842PDI", Modelo = "Cactus"},
            new Coche() {AFabricacion = 2001, Matricula = "1948FJS", Modelo = "Peugeot 307"},
            new Coche() {AFabricacion = 1999, Matricula = "5128PJY", Modelo = "Citroen Xsara"},
            new Coche() {AFabricacion = 1996, Matricula = "1348ODE", Modelo = "Toyota Avensis"},
            new Coche() {AFabricacion = 1996, Matricula = "1878PLI", Modelo = "Citroen Xsara"},
            new Coche() {AFabricacion = 1950, Matricula = "0838PLI", Modelo = "Peugeot 306"},
            new Coche() {AFabricacion = 1996, Matricula = "9567DFJ", Modelo = "Citroen Xsara"},
            new Coche() {AFabricacion = 2005, Matricula = "1948TRK", Modelo = "Citroen C3"},
            new Coche() {AFabricacion = 3001, Matricula = "1948FKD", Modelo = "Citroen Xsara"},
            new Coche() {AFabricacion = -150, Matricula = "1948MFJ", Modelo = "Peugeot 306"},

        };

        #endregion

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                var menu = Menu();
                Console.Clear();

                switch (menu)
                {
                    case 1:
                        Buscar(Console.ReadLine(), true);
                        break;
                    case 2:
                        Buscar(Console.ReadLine(), false);
                        break;
                    case 3:
                        Console.Write("Modelo: ");
                        var mod = Console.ReadLine();
                        int a;

                        do
                        {
                            Console.Write("Año de fabricación: ");
                        } while (!int.TryParse(Console.ReadLine(), out a));
                        
                        Buscar(mod, a);
                        break;
                }

            } while (true);
        }

        #region Methods

        public static int Menu()
        {
            do
            {
                Console.WriteLine("Elija una opción: \n" +
                                  "1) Por matrícula\n" +
                                  "2) Por modelo.\n" +
                                  "3) Modelo y Año de Fabricación.");
                int res;
                if (int.TryParse(Console.ReadLine(), out res))
                    if ((res != 1) || (res != 2) || (res != 3))
                        return res;

                Console.Clear();

            } while (true);
        }

        public static void Buscar(string m, bool isMatricula)
        {
            if (isMatricula)
            {
                var p = Concesionario.FirstOrDefault(o => o.Matricula.ToUpper() == m.ToUpper());
                if (p != null)
                    Console.WriteLine(p);
                else
                    Console.WriteLine("Vehículo no encontrado.");

            }
            else
            {
                var p = Concesionario.Where(o => o.Modelo.ToUpper().Contains(m.ToUpper()))
                    .OrderByDescending(o => o.AFabricacion);

                if (!p.Any())
                    Console.WriteLine("Vehículo no encontrado.");

                foreach (var elem in p)
                {
                    Console.WriteLine(elem);
                }

            }

            Console.Write("\nPulse ENTER para continuar.");
            Console.Read();
        }

        public static void Buscar(string m, int aFabric)
        {
            var p = Concesionario.Where(o => o.Modelo.ToUpper().Contains(m.ToUpper())
                                             && o.AFabricacion == aFabric).OrderBy(o => o.Matricula);

            if (!p.Any())
                Console.WriteLine("Vehículo no encontrado.");

            foreach (var elem in p)
            {
                Console.WriteLine(elem);
            }

            Console.Write("\nPulse ENTER para continuar.");
            Console.Read();
        }

        #endregion

    }
}
