using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AquaTrack.Models;

namespace AquaTrack.Pages.Condominios
{
    public class DeleteModel : PageModel
    {
        private readonly AquaTrack.Models.BancoCondominio _context;

        public DeleteModel(AquaTrack.Models.BancoCondominio context)
        {
            _context = context;
        }

        [BindProperty]
        public Condominio Condominio { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var condominio = await _context.Condominios.FirstOrDefaultAsync(m => m.Id == id);

            if (condominio == null)
            {
                return NotFound();
            }
            else
            {
                Condominio = condominio;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var condominio = await _context.Condominios.FindAsync(id);
            if (condominio != null)
            {
                Condominio = condominio;
                _context.Condominios.Remove(Condominio);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
