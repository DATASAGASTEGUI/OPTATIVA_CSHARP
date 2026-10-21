
using System;
using System.IO;

namespace AppConsolaLinq.CSV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ruta del archivo CSV junto al ejecutable
            string ruta = Path.Combine(
                AppContext.BaseDirectory,
                "CSV",
                "Alumno.csv"
            );
            Console.WriteLine(ruta);

            // Comprobar que el archivo existe
            if (!File.Exists(ruta))
            {
                Console.WriteLine("No se encuentra el archivo CSV.");
                return;
            }

            // Leer todas las líneas del archivo
            string[] lineas = File.ReadAllLines(ruta);

            // Recorrer las líneas, ignorando la cabecera
            for (int i = 1; i < lineas.Length; i++)
            {
                // Separar los campos utilizando la coma
                string[] datos = lineas[i].Split(',');

                int id = int.Parse(datos[0]);
                string nombre = datos[1];
                int edad = int.Parse(datos[2]);
                double nota = double.Parse(
                    datos[3],
                    System.Globalization.CultureInfo.InvariantCulture
                );

                Console.WriteLine(
                    $"ID: {id} | Nombre: {nombre} | " +
                    $"Edad: {edad} | Nota: {nota:F2}"
                );
            }
        }
    }
}

