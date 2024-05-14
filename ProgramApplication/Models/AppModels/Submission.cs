namespace ProgramApplication;

public class Submission
{
    public Guid Id { get; set; }
    public Guid ProgramId { get; set; }
    public ICollection<Answer> Answers { get; set; }
}


