namespace ProgramApplication;

public class QuestionsModel
{
    public Guid QuestionTypeId { get; set; }
    public string Question { get; set; }
    public bool IsRequired { get; set; }
    public bool IsInternal { get; set; }
    public bool IsHidden { get; set; }
    public List<string>? Options { get; set; }
    public bool OtherOptionsAllowed { get; set; }
}
