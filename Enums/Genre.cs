using System.ComponentModel.DataAnnotations;

namespace FavTVShow2.Enums
{
    public enum Genre
    {
        Drama,
        Comedy,
        Action,
        Romance,
        [Display(Name = "Romantic Comedy")]
        RomCom,
        Crime,
        Mystery
    }
}
