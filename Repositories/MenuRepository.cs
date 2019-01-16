using System;
using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Repositories
{
  public class MenuRepository
  {

    private readonly IDbConnection _db;
    public MenuRepository(IDbConnection db)
    {
      _db = db;
    }


    // Read
    public IEnumerable<MenuItem> GetAll()
    {
      IEnumerable<Burger> burgers = GetAllBurgers();
      IEnumerable<Drink> drinks = GetAllDrinks();
      IEnumerable<Side> sides = GetAllSides();
      List<MenuItem> menu = new List<MenuItem>();
      menu.AddRange(burgers);
      menu.AddRange(drinks);
      menu.AddRange(sides);
      return menu;
    }
    public IEnumerable<Burger> GetAllBurgers()
    {
      return _db.Query<Burger>("SELECT * FROM Burgers");
    }
    public IEnumerable<Drink> GetAllDrinks()
    {
      return _db.Query<Drink>("SELECT * FROM Drinks");
    }
    public IEnumerable<Side> GetAllSides()
    {
      return _db.Query<Side>("SELECT * FROM Sides");
    }
  }
}