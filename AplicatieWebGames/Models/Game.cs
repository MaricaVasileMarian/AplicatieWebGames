using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicatieWebGames.Models
{
    public class Game
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Game Title")]
        public string Title { get; set; }
        public string Consola { get; set; }
        [Range(1, 300)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }
        public int PublisherID { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<GameCategory> GameCategories { get; set; }
    }
}
