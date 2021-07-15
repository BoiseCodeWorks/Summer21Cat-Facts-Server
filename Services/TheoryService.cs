using System;
using System.Collections.Generic;
using System.Linq;
using catFacts.Models;
using catFacts.Repositories;

namespace catFacts.Services
{
  public class TheoryService
  {
    private readonly TheoryRepository _repo;
    public TheoryService(TheoryRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<CatTheory> getTheories()
    {
      return _repo.getTheories();
    }

    public CatTheory getOne(int id)
    {
      return _repo.getOne(id);
    }

    public CatTheory create(CatTheory theory)
    {
      int id = _repo.create(theory);
      theory.Id = id;
      return theory;
    }

    internal CatTheory update(int id, CatTheory theory)
    {
      theory.Id = id;
      CatTheory original = getOne(id);
      theory.Body = theory.Body != null ? theory.Body : original.Body;
      theory.Result = theory.Result != null ? theory.Result : original.Result;
      theory.ImgUrl = theory.ImgUrl != null ? theory.ImgUrl : original.ImgUrl;

      // NOTE For loop for what is above
      // var props = theory.GetType().GetProperties().ToList();
      // props.ForEach(p =>
      // {
      //   var val = p.GetValue(theory) ?? p.GetValue(original);
      //   p.SetValue(theory, val);
      // });

      int updated = _repo.update(theory);
      if (updated > 0)
      {
        return theory;
      }
      else
      {
        throw new Exception("could not update");
      }
    }

    internal string delete(int id)
    {
      int updated = _repo.delete(id);
      if (updated > 0)
      {
        return "Successfully Deleted";
      }
      else
      {
        throw new Exception("could not delete");
      }
    }
  }
}