
using catFacts.Models;
using catFacts.Services;
using Microsoft.AspNetCore.Mvc;

namespace catFacts.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class StudyController : ControllerBase
  {
    private readonly StudyService _studyService;

    public StudyController(StudyService studyService)
    {
      _studyService = studyService;
    }

    [HttpPost]
    public ActionResult<CatStudy> create([FromBody] CatStudy study)
    {
      try
      {
        return Ok(_studyService.Create(study));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}