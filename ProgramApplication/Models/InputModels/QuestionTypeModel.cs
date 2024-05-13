using System.ComponentModel;

namespace ProgramApplication;

public class QuestionTypeModel
{
    [Description("Unique identifier for the question type. Only required when updating a question type.")]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
