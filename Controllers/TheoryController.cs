using System.Collections.Generic;
using catFacts.Models;
using catFacts.Services;
using Microsoft.AspNetCore.Mvc;

namespace catFacts.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TheoryController : ControllerBase
  {
    private readonly TheoryService _theoryService;

    private readonly StudyService _studyService;

    public TheoryController(TheoryService theoryService, StudyService studyService)
    {
      _theoryService = theoryService;
      _studyService = studyService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CatTheory>> getTheories()
    {
      try
      {
        return Ok(_theoryService.getTheories());
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<CatTheory>> getOneTheory(int id)
    {
      try
      {
        return Ok(_theoryService.getOne(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/studies")]
    public ActionResult<IEnumerable<CatTheory>> getStudies(int id)
    {
      try
      {
        return Ok(_studyService.GetStudiesByTheoryId(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }



    [HttpPost]
    public ActionResult<CatTheory> create([FromBody] CatTheory theory)
    {
      try
      {
        return Ok(_theoryService.create(theory));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<CatTheory> update(int id, [FromBody] CatTheory theory)
    {
      try
      {
        theory.Result = null;
        return Ok(_theoryService.update(id, theory));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<CatTheory> delete(int id)
    {
      try
      {
        return Ok(_theoryService.delete(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}