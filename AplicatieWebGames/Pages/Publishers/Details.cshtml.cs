using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AplicatieWebGames.Data;
using AplicatieWebGames.Models;

namespace AplicatieWebGames.Pages.Publishers
{
    public class DetailsModel : PageModel
    {
        private readonly AplicatieWebGames.Data.AplicatieWebGamesContext _context;

        public DetailsModel(AplicatieWebGames.Data.AplicatieWebGamesContext context)
        {
            _context = context;
        }

        public Publisher Publisher { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Publisher = await _context.Publisher.FirstOrDefaultAsync(m => m.ID == id);

            if (Publisher == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
