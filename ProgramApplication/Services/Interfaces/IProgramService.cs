namespace ProgramApplication;

public interface IProgramService
{
    Task<StandardResponse<ProgramView>> CreateProgram(ProgramModel programModel);
    Task<StandardResponse<IEnumerable<ProgramView>>> GetAllPrograms();
    Task<StandardResponse<ProgramView>> UpdateProgramQuestion(QuestionsModel model, Guid programId);
    Task<StandardResponse<ProgramView>> GetProgramById(Guid id);
    Task<StandardResponse<ProgramView>> AddQuestionToProgram(Guid programId, QuestionsModel questionModel);
    Task<StandardResponse<ProgramView>> RemoveQuestionFromProgram(Guid programId, Guid questionId);
    Task<StandardResponse<SubmissionView>> SubmitProgram(Guid programId, SubmissionModel submissionModel);
}
