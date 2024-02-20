using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AquaTrack.Models;

namespace AquaTrack.Pages.Leituras
{
    public class DeleteModel : PageModel
    {
        private readonly AquaTrack.Models.BancoDeDados _context;

        public DeleteModel(AquaTrack.Models.BancoDeDados context)
        {
            _context = context;
        }

        [BindProperty]
        public Leitura Leitura { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leitura = await _context.Leituras.FirstOrDefaultAsync(m => m.Id == id);

            if (leitura == null)
            {
                return NotFound();
            }
            else
            {
                Leitura = leitura;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leitura = await _context.Leituras.FindAsync(id);
            if (leitura != null)
            {
                Leitura = leitura;
                _context.Leituras.Remove(Leitura);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
