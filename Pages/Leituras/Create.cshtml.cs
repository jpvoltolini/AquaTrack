using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AquaTrack.Models;

namespace AquaTrack.Pages.Leituras
{
    public class CreateModel : PageModel
    {
        private readonly AquaTrack.Models.BancoDeDados _context;

        public CreateModel(AquaTrack.Models.BancoDeDados context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Leitura Leitura { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Converte a DataLeitura para Utc
            Leitura.DataLeitura = Leitura.DataLeitura.ToUniversalTime();

            _context.Leituras.Add(Leitura);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
