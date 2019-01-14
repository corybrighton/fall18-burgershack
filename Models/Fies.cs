using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{
  public class Fries : MenuItem
  {

    public Fries(string name, string desc, float price) : base(name, desc, price)
    {

    }
  }
}