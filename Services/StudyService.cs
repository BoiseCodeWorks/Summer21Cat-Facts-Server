using System;
using System.Linq;
using System.Collections.Generic;
using catFacts.Models;
using catFacts.Repositories;

namespace catFacts.Services
{
  public class StudyService
  {

    private readonly StudyRepository _repo;

    private readonly TheoryService _theoryService;

    public StudyService(StudyRepository repo, TheoryService theoryService)
    {
      _repo = repo;
      _theoryService = theoryService;
    }

    public CatStudy Create(CatStudy study)
    {
      int id = _repo.Create(study);
      study.Id = id;
      List<CatStudy> studies = new List<CatStudy>();
      studies = GetStudiesByTheoryId(study.TheoryId);

      if (studies.Count > 8)
      {
        int trues = studies.FindAll(s => s.Test == true).Count;
        CatTheory newResult = new CatTheory();
        if (trues > (studies.Count / 2))
        {
          newResult.Result = "This is a Fact";
        }
        else if (trues == (studies.Count / 2))
        {
          newResult.Result = "Data is inconclusive";

        }
        else
        {
          newResult.Result = "This is Bogus";
        }
        _theoryService.update(study.TheoryId, newResult);
      }
      return study;
    }
    public List<CatStudy> GetStudiesByTheoryId(int theoryId)
    {
      return _repo.GetStudiesByTheoryId(theoryId);
    }
  }
}