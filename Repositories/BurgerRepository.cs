using System;
using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Repositories
{
  public class BurgerRepository
  {
    private readonly IDbConnection _db;
    public BurgerRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Burger> GetAll()
    {
      return _db.Query<Burger>("SELECT * FROM Burgers;");
    }

    public Burger GetBurgerById(int id)
    {
      return _db.QueryFirstOrDefault<Burger>($"SELECT * FROM Burgers WHERE id = @id", new { id });
    }

    // Create
    public Burger AddBurger(Burger burger)
    {
      int id = _db.ExecuteScalar<int>(@"
 	INSERT INTO Burgers (name, description, price) VALUES (@Name, @Description, @Price); 
 	SELECT LAST_INSERT_ID()", new
      {
        burger.Name,
        burger.Description,
        burger.Price
      });
      burger.id = id;
      return burger;
    }

    // Update
    public Burger UpdateBurger(int id, Burger burger)
    {
      _db.ExecuteScalar<int>(@"
 	UPDATE Burgers SET 
   Name = @Name,
   Description = @Description,
   Price = @Price
   WHERE id = @id; 
 	SELECT LAST_INSERT_ID()", new
      {
        burger.Name,
        burger.Description,
        burger.Price,
        id
      });
      burger.id = id;
      return burger;
    }

    public bool DeleteBurger(int id)
    {
      _db.Query<Burger>($"DELETE FROM Burgers WHERE id = @id", new { id });
      return true;
    }
  }
}