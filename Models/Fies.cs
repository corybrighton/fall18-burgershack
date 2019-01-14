using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{
  public class Fries
  {
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Range(4f, 12f)]
    public float Price { get; set; }
    public Fries(string name, string desc, float price)
    {
      Name = name;
      Description = desc;
      Price = price;
    }
  }
}