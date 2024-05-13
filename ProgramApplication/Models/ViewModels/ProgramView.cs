namespace ProgramApplication;

public class ProgramView
{  
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string DateCreated { get; set; }
    public string DateModified { get; set; }
    public List<QuestionView>? Questions { get; set; }
}
