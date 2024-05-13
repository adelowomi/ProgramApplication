namespace ProgramApplication;

public class QuestionType
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Description { get; set; }
    public string DateCreated { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    public string DateModified { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
}
