using System;
using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Repositories
{
  public class DrinkRepository
  {
    private readonly IDbConnection _db;
    public DrinkRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Drink> GetAll()
    {
      return _db.Query<Drink>("SELECT * FROM Drinks;");
    }

    public Drink GetDrinkById(int id)
    {
      return _db.QueryFirstOrDefault<Drink>($"SELECT * FROM Drinks WHERE id = @id", new { id });
    }

    // Create
    public Drink AddDrink(Drink drink)
    {
      int id = _db.ExecuteScalar<int>(@"
 	INSERT INTO Drinks (name, description, price) VALUES (@Name, @Description, @Price); 
 	SELECT LAST_INSERT_ID()", new
      {
        drink.Name,
        drink.Description,
        drink.Price
      });
      drink.id = id;
      return drink;
    }

    // Update
    public Drink UpdateDrink(int id, Drink drink)
    {
      _db.ExecuteScalar<int>(@"
 	UPDATE Drinks SET 
   Name = @Name,
   Description = @Description,
   Price = @Price
   WHERE id = @id; 
 	SELECT LAST_INSERT_ID()", new
      {
        drink.Name,
        drink.Description,
        drink.Price,
        id
      });
      drink.id = id;
      return drink;
    }

    public bool DeleteDrink(int id)
    {
      _db.Query<Drink>($"DELETE FROM Drinks WHERE id = @id", new { id });
      return true;
    }
  }
}