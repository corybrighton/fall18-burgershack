using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{
  public class Side : MenuItem
  {

    public Side(string name, string desc, float price) : base(name, desc, price)
    {

    }
  }
}