namespace ProgramApplication;

public class Submission
{
    public Guid Id { get; set; }
    public Guid ProgramId { get; set; }
    public Dictionary<Question, Answer> Answers { get; set; }
}


