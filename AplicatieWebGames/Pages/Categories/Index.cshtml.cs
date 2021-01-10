using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AplicatieWebGames.Data;
using AplicatieWebGames.Models;

namespace AplicatieWebGames.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly AplicatieWebGames.Data.AplicatieWebGamesContext _context;

        public IndexModel(AplicatieWebGames.Data.AplicatieWebGamesContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
