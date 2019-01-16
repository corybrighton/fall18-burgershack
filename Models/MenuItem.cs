using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{
  public class MenuItem
  {
    [Required]
    public int id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    [Range(.99f, 25f)]
    public float Price { get; set; }

  }
}