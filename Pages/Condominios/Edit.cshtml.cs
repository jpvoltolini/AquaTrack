using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AquaTrack.Models;

namespace AquaTrack.Pages.Condominios
{
    public class EditModel : PageModel
    {
        private readonly AquaTrack.Models.BancoCondominio _context;

        public EditModel(AquaTrack.Models.BancoCondominio context)
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

            var condominio =  await _context.Condominios.FirstOrDefaultAsync(m => m.Id == id);
            if (condominio == null)
            {
                return NotFound();
            }
            Condominio = condominio;
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

            _context.Attach(Condominio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CondominioExists(Condominio.Id))
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

        private bool CondominioExists(int id)
        {
            return _context.Condominios.Any(e => e.Id == id);
        }
    }
}
