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
    public class IndexModel : PageModel
    {
        private readonly AquaTrack.Models.BancoDeDados _context;

        public IndexModel(AquaTrack.Models.BancoDeDados context)
        {
            _context = context;
        }

        public IList<Leitura> Leitura { get;set; } = default!;



        public async Task OnGetAsync()
        {
            Leitura = await _context.Leituras.ToListAsync();
        }
    }
}
