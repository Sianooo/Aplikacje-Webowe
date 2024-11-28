using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using cw8.Models;
using System.Collections.Generic;
using System.IO;

namespace cw8.Pages
{
    public class PrimesModel : PageModel
    {
        [BindProperty]
        public int? Ilosc { get; set; }
        public List<int> PrimeNumbers { get; private set; }

        private string filePath = "wwwroot/wynik.txt";

        public void OnPost()
        {
            if (Ilosc.HasValue && Ilosc > 0)
            {
                PrimeNumbers = Primes.GetPrimes(Ilosc.Value);
                SavePrimesToFile(PrimeNumbers);
            }
        }

        private void SavePrimesToFile(List<int> primes)
        {
            using (var writer = new StreamWriter(filePath, append: false))
            {
                foreach (var prime in primes)
                {
                    writer.WriteLine(prime);
                }
            }
        }
    }
}
