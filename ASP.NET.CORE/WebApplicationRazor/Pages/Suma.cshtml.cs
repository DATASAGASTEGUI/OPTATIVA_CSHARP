using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationRazor.Pages
{
    public class SumaModel : PageModel
    {
        // Entrada
        [BindProperty]
        public string N1 { get; set; }
        [BindProperty]
        public string N2 { get; set; }
        // Salida
        public string R { get; set; } = "";
        public string M { get; set; } = "";
        public void OnGet()
        {
            N1 = N2 = "";
        }

        public void OnPostSumar()
        {
            if (!int.TryParse(N1, out int n1) || !int.TryParse(N2, out int n2))
            {
               M = "Entrada incorrecta";
               return;
            }
            int r = n1 + n2;
            R = r.ToString();
            M = "Ok";
        }
    }
}
