using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using catFacts.Models;
using Dapper;

namespace catFacts.Repositories
{

  public class StudyRepository
  {

    private readonly IDbConnection _db;

    public StudyRepository(IDbConnection db)
    {
      _db = db;
    }

    internal int Create(CatStudy study)
    {
      string sql = @"
      INSERT INTO Studies
      (theoryId, test, body, imgUrl)
      VALUES
      (@TheoryId, @Test, @Body, @ImgUrl);
      SELECT LAST_INSERT_ID();
      ";
      return _db.ExecuteScalar<int>(sql, study);
    }

    internal List<CatStudy> GetStudiesByTheoryId(int theoryId)
    {
      string sql = @"
      SELECT * FROM Studies
      WHERE theoryId = @TheoryId;
      ";
      return _db.Query<CatStudy>(sql, new { theoryId }).ToList();
    }
  }
}