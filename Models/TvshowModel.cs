using FavTVShow2.Enums;
using System.ComponentModel.DataAnnotations;

namespace FavTVShow2.Models
{
    public class TvshowModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Required]
        public decimal Rating { get; set; }

        [Required]
        [DataType(DataType.Url)]
        [Display(Name = "Imdb Link")]
        public string? ImdbUrl { get; set; }
    }
}
