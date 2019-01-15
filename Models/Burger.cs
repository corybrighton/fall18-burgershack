using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{
  public class Burger : MenuItem
  {
    public List<string> Ingredince { get; set; }
    public Burger(string name, string desc, float price = 2.15f) : base(name, desc, price)
    {
      Ingredince = new List<string>();
      Ingredince.Add("Lettuce");
      Ingredince.Add("Tomato");
      Ingredince.Add("Pickels");
    }
  }
}