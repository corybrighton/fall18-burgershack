using System;
using System.Collections.Generic;
using BurgerShack.Models;

namespace BurgerShack.Repositories
{
  public class MenuRepository
  {
    // Create
    public MenuItem AddItem(MenuItem newItem)
    {
      FakeDB.Menu.Add(newItem);
      return newItem;
    }
    // Update
    public MenuItem EditMenu(int id, MenuItem newItem)
    {
      try
      {
        FakeDB.Menu[id] = newItem;
        return newItem;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }
    // Read
    public IEnumerable<MenuItem> GetAll()
    {
      return FakeDB.Menu;
    }
    public MenuItem GetItem(int id)
    {
      try
      {
        return FakeDB.Menu[id];
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }

    // Delete
    public bool DeleteMenuItem(int id)
    {
      try
      {
        FakeDB.Menu.Remove(FakeDB.Menu[id]);
        return true;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return false;
      }
    }
  }
}