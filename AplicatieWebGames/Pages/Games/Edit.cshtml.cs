using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AplicatieWebGames.Data;
using AplicatieWebGames.Models;

namespace AplicatieWebGames.Pages.Games
{
    public class EditModel : GameCategoriesPageModel
    {
        private readonly AplicatieWebGames.Data.AplicatieWebGamesContext _context;

        public EditModel(AplicatieWebGames.Data.AplicatieWebGamesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Game Game { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Game = await _context.Game
            .Include(b => b.Publisher)
            .Include(b => b.GameCategories).ThenInclude(b => b.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);

            if (Game == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Game);
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var gameToUpdate = await _context.Game
            .Include(i => i.Publisher)
            .Include(i => i.GameCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (gameToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Game>(
            gameToUpdate,
            "Game",
            i => i.Title, i => i.Consola,
            i => i.Price, i => i.PublishingDate, i => i.Publisher))
            {
                UpdateGameCategories(_context, selectedCategories, gameToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateGameCategories(_context, selectedCategories, gameToUpdate);
            PopulateAssignedCategoryData(_context, gameToUpdate);
            return Page();
        }
    }

}
