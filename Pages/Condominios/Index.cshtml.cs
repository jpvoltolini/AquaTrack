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
    public class IndexModel : PageModel
    {
        private readonly AquaTrack.Models.BancoCondominio _context;

        public IndexModel(AquaTrack.Models.BancoCondominio context)
        {
            _context = context;
        }

        public IList<Condominio> Condominio { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Condominio = await _context.Condominios.ToListAsync();
        }
    }
}
