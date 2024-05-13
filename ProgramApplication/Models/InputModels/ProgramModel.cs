using System.ComponentModel;

namespace ProgramApplication;

public class ProgramModel
{
    [Description("The unique identifier for the program. Only required when updating a program.")]
    public Guid Id { get; set; }
    public string Title  { get; set; }
    public string Description { get; set; }
    public string DateCreated { get; set; }
    public string DateModified { get; set; }
    public List<QuestionsModel> Questions { get; set; }
}
