using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AquaTrack.Models;

namespace AquaTrack.Pages.Leituras
{
    public class EditModel : PageModel
    {
        private readonly AquaTrack.Models.BancoDeDados _context;

        public EditModel(AquaTrack.Models.BancoDeDados context)
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

            var leitura =  await _context.Leituras.FirstOrDefaultAsync(m => m.Id == id);
            if (leitura == null)
            {
                return NotFound();
            }
            Leitura = leitura;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // Converte a DataLeitura para Utc
            Leitura.DataLeitura = Leitura.DataLeitura.ToUniversalTime();
            _context.Attach(Leitura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeituraExists(Leitura.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LeituraExists(int id)
        {
            return _context.Leituras.Any(e => e.Id == id);
        }
    }
}
