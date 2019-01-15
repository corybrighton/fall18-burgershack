using System;
using System.Collections.Generic;
using BurgerShack.Models;

namespace BurgerShack.Repositories
{
  public class BurgerRepository
  {
    public IEnumerable<Burger> GetAll()
    {
      return FakeDB.Burgers;
    }

    public Burger GetBurgerById(int id)
    {
      try
      {
        return FakeDB.Burgers[id];
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }

    public IEnumerable<Burger> AddBurger(Burger newBurger)
    {
      FakeDB.Burgers.Add(newBurger);
      return FakeDB.Burgers;
    }
  }
}