using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AppConsolaLinq.CSV
{
    public class Program1
    {
        public static void Main(string[] args)
        {
            try
            {
                string rutaRelativa = "data/Alumno.csv";
                string rutaAbsoluta = Path.GetFullPath(rutaRelativa);
                Console.WriteLine("RUTA ABSOLUTA: " + rutaAbsoluta);
                string fila = "";
                //string rutaAbsoluta = "C:\\Users\\CampusFP\\VisualStudioProject\\AppConsolaLinq\bin\\Debug\net10.0\\CSV\\Alumno.csv";

                using (StreamReader sr = new StreamReader(rutaAbsoluta))
                {
                    while ((fila = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(fila);
                    }
                    Console.WriteLine("FIN DE LECTURA");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: LECTURA " + e.Message);
            }
        }
    }
}
