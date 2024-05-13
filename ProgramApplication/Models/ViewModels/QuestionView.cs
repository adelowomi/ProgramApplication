namespace ProgramApplication;

public class QuestionView
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string DateCreated { get; set; }
    public string DateModified { get; set; }
    public bool IsRequired { get; set; }
    public bool IsInternal { get; set; }
    public bool IsHidden { get; set; }
    public List<string>? Options { get; set; }
    public bool OtherOptionsAllowed { get; set; }
}
