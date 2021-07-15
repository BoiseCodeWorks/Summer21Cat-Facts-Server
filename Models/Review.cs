namespace catFacts.Models
{
  public class Review
  {
    public int Id { get; private set; }
    public int FactId { get; private set; }
    public string Body { get; private set; }
  }
}