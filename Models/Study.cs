using System.ComponentModel.DataAnnotations;

namespace catFacts.Models
{
  public class CatStudy
  {
    public int Id { get; set; }

    [Required]
    public int TheoryId { get; set; }

    [Required]
    public bool Test { get; set; }
    public string Body { get; set; }
    public string ImgUrl { get; set; }
  }
}