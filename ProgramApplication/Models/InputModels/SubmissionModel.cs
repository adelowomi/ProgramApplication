namespace ProgramApplication;

public class SubmissionModel
{
    public Guid Id { get; set; }
    public Guid ProgramId { get; set; }
    public Dictionary<QuestionsModel, Answer> Answers { get; set; }
}
