using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{
  public class Drink : MenuItem
  {

    public Drink(string name, string desc, float price) : base(name, desc, price)
    {

    }
  }
}