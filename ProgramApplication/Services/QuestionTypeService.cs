using Mapster;

namespace ProgramApplication;

public class QuestionTypeService : IQuestionTypeService
{
    private readonly IBaseRepository<QuestionType> _questionTypeRepository;

    public QuestionTypeService(IBaseRepository<QuestionType> questionTypeRepository)
    {
        _questionTypeRepository = questionTypeRepository;
    }

    public async Task<StandardResponse<QuestionTypeView>> CreateQuestionType(QuestionTypeModel questionTypeModel)
    {
        var questionType = questionTypeModel.Adapt<QuestionType>();

        questionType = await _questionTypeRepository.CreateAndReturn(questionType);
        var questionTypeView = questionType.Adapt<QuestionTypeView>();

        return StandardResponse<QuestionTypeView>.Ok(questionTypeView);
    }

    public async Task<StandardResponse<IEnumerable<QuestionTypeView>>> GetAllQuestionTypes()
    {
        var questionTypes = await _questionTypeRepository.GetAll();
        var questionTypeViews = questionTypes.Adapt<IEnumerable<QuestionTypeView>>();

        return StandardResponse<IEnumerable<QuestionTypeView>>.Ok(questionTypeViews);
    }

    public async Task<StandardResponse<QuestionTypeView>> UpdateQuestionType(QuestionTypeModel questionTypeModel)
    {
        var questionType = questionTypeModel.Adapt<QuestionType>();

        questionType = await _questionTypeRepository.Update(questionType);
        var questionTypeView = questionType.Adapt<QuestionTypeView>();

        return StandardResponse<QuestionTypeView>.Ok(questionTypeView);
    }
}
