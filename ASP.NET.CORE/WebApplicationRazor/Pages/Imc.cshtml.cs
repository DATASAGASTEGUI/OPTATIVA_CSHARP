using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.Globalization;

namespace WebApplicationRazor.Pages
{
    public class ImcModel : PageModel
    {
        // Entrada
        [BindProperty]
        public string Peso { get; set; }
        [BindProperty]
        public string Altura { get; set; }
        // Salida
        public string Imc { get; set; } = "";
        public string Clasificacion { get; set; } = "";
        public string M { get; set; } = "";

        public void OnGet()
        {
            Peso = Altura = "";
        }

        public void OnPostCalcular()
        {
            if(!ParseDouble(Peso, out double peso) ||
               !ParseDouble(Altura, out double altura))
            {
                M = "Entrada incorrecta";
                return;
            }

            if(peso <= 0)
            {
                M = "El peso debe ser mayor que cero";
                return;
            }

            if (altura <= 0)
            {
                M = "La altura debe ser mayor que cero";
                return;
            }

            double imc = peso / (altura * altura);
            Imc = imc.ToString();
            Clasificacion = Clasificar(imc);
            M = "Ok";
        }

        private string Clasificar(double imc)
        {
            if (imc < 18.5) return "Bajo peso";
            if (imc < 25) return "Peso normal";
            if (imc < 30) return "Sobrepeso";
            if (imc < 35) return "Obesidad de grado I";
            if (imc < 40) return "Obesidad de grado II";
            return "Obesidad de grado III";
        }

        private bool ParseDouble(string texto, out double valor)
        {
            valor = 0;
            if(string.IsNullOrWhiteSpace(texto))
            {
                return false;
            }

            texto = texto.Replace(',', '.');
            return double.TryParse(
                     texto,
                     System.Globalization.NumberStyles.Float,
                     CultureInfo.InvariantCulture,
                     out valor);
        }

    }
}
