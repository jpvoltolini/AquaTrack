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
    public class DetailsModel : PageModel
    {
        private readonly AquaTrack.Models.BancoDeDados _context;

        public DetailsModel(AquaTrack.Models.BancoDeDados context)
        {
            _context = context;
        }

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
    }
}
