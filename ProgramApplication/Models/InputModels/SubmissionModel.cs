namespace ProgramApplication;

public class SubmissionModel
{
    public Guid Id { get; set; }
    public Guid ProgramId { get; set; }
    public List<Answer> Answers { get; set; }
}
