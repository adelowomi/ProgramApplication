using System.ComponentModel.DataAnnotations.Schema;

namespace ProgramApplication;

public class Question
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Description { get; set; }
    public string DateCreated { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    public string DateModified { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    public bool IsRequired { get; set; }
    public bool IsInternal { get; set; }
    public bool IsHidden { get; set; }
    public List<string>? Options { get; set; }
    public bool OtherOptionsAllowed { get; set; }
    public Guid ProgramId { get; set; }
    [ForeignKey(nameof(ProgramId))]
    public Programs Program { get; set; }
    public Guid QuestionTypeId { get; set; }
    [ForeignKey(nameof(QuestionTypeId))]
    public QuestionType QuestionType { get; set; }
}
