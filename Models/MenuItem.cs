using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{
  public class MenuItem
  {
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Range(.99f, 25f)]
    public float Price { get; set; }
    public MenuItem(string name, string desc, float price = .99f)
    {
      Name = name;
      Description = desc;
      Price = price;
    }
  }
}