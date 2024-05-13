namespace ProgramApplication;

public class SubmissionView
{
    public Guid Id { get; set; }
    public Guid ProgramId { get; set; }
    public Dictionary<QuestionView, AnswerView> Answers { get; set; }
}
