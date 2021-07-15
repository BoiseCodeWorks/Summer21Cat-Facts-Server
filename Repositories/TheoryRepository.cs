using System;
using System.Collections.Generic;
using System.Data;
using catFacts.Models;
using Dapper;

namespace catFacts.Repositories
{

  public class TheoryRepository
  {

    private readonly IDbConnection _db;

    public TheoryRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<CatTheory> getTheories()
    {
      string sql = "SELECT * FROM Theories;";
      return _db.Query<CatTheory>(sql);
    }

    internal CatTheory getOne(int id)
    {
      string sql = "SELECT * FROM Theories  WHERE id = @id";
      return _db.QueryFirstOrDefault<CatTheory>(sql, new { id });
    }

    public int create(CatTheory theory)
    {
      string sql = @"
      INSERT INTO Theories
      (body, imgUrl, result)
      VALUES
      (@Body, @imgUrl, @result);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, theory);
    }

    internal int update(CatTheory theory)
    {
      string sql = @"
      UPDATE theories
      SET
      body = @Body,
      result = @Result,
      imgUrl = @ImgUrl
      WHERE id = @id;
      ";
      return _db.Execute(sql, theory);
    }

    internal int delete(int id)
    {
      string sql = @"
      DELETE FROM Theories
      WHERE id = @id
      ";
      return _db.Execute(sql, new { id });
    }
  }
}