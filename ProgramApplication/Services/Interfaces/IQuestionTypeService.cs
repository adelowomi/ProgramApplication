namespace ProgramApplication;

public interface IQuestionTypeService
{
    Task<StandardResponse<QuestionTypeView>> CreateQuestionType(QuestionTypeModel questionTypeModel);
    Task<StandardResponse<IEnumerable<QuestionTypeView>>> GetAllQuestionTypes();
    Task<StandardResponse<QuestionTypeView>> UpdateQuestionType(QuestionTypeModel questionTypeModel);
}
