using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AplicatieWebGames.Models;

namespace AplicatieWebGames.Data
{
    public class AplicatieWebGamesContext : DbContext
    {
        public AplicatieWebGamesContext (DbContextOptions<AplicatieWebGamesContext> options)
            : base(options)
        {
        }

        public DbSet<AplicatieWebGames.Models.Game> Game { get; set; }

        public DbSet<AplicatieWebGames.Models.Publisher> Publisher { get; set; }

        public DbSet<AplicatieWebGames.Models.Category> Category { get; set; }
    }
}
