using System.Collections.Generic;

namespace BurgerShack.Models
{
  static class FakeDB
  {
    public static List<Burger> Burgers = new List<Burger>(){
      new Burger("Mark Burger", "A delicious burger with bacon and stuff", 7.56f),
      new Burger("Jake Burger", "Now with fries!", 8.54f),
      new Burger("D$ Burger", "It's Mostly Foraged", 6.24f)
    };

    public static List<MenuItem> Menu = new List<MenuItem>() {
      new Burger("D$ Burger","It's Mostly Foraged", 6.24f),
      new Side("Porter Tots","Now Made of Potatoes", 4.23f),
      new Drink("Brittney Cola","Don't drink it to fast", 2.50f)
    };
  }
}