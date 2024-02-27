using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AquaTrack.Models;

namespace AquaTrack.Pages.Condominios
{
    public class CreateModel : PageModel
    {
        private readonly AquaTrack.Models.BancoCondominio _context;

        public CreateModel(AquaTrack.Models.BancoCondominio context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Condominio Condominio { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Condominios.Add(Condominio);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
