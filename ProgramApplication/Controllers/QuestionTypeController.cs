using Microsoft.AspNetCore.Mvc;

namespace ProgramApplication;

[Route("api/[controller]")]
[ApiController]
public class QuestionTypeController : StandardControllerBase
{
    private readonly IQuestionTypeService _questionTypeService;

    public QuestionTypeController(IQuestionTypeService questionTypeService)
    {
        _questionTypeService = questionTypeService;
    }

    [HttpPost("create", Name = nameof(CreateQuestionType))]
    [ProducesResponseType(typeof(StandardResponse<QuestionTypeView>), 200)]
    [ProducesResponseType(typeof(StandardResponse<QuestionTypeView>), 400)]
    [ProducesResponseType(typeof(StandardResponse<QuestionTypeView>), 500)]
    public async Task<ActionResult<StandardResponse<QuestionTypeView>>> CreateQuestionType([FromBody]QuestionTypeModel questionTypeModel)
    {
       return Result (await _questionTypeService.CreateQuestionType(questionTypeModel));
    }

    [HttpGet("list", Name = nameof(GetAllQuestionTypes))]
    [ProducesResponseType(typeof(StandardResponse<IEnumerable<QuestionTypeView>>), 200)]
    [ProducesResponseType(typeof(StandardResponse<IEnumerable<QuestionTypeView>>), 400)]
    [ProducesResponseType(typeof(StandardResponse<IEnumerable<QuestionTypeView>>), 500)]
    public async Task<ActionResult<StandardResponse<IEnumerable<QuestionTypeView>>>> GetAllQuestionTypes()
    {
        return Result(await _questionTypeService.GetAllQuestionTypes());
    }

    [HttpPut("update", Name = nameof(UpdateQuestionType))]
    [ProducesResponseType(typeof(StandardResponse<QuestionTypeView>), 200)]
    [ProducesResponseType(typeof(StandardResponse<QuestionTypeView>), 400)]
    [ProducesResponseType(typeof(StandardResponse<QuestionTypeView>), 500)]
    public async Task<ActionResult<StandardResponse<QuestionTypeView>>> UpdateQuestionType([FromBody]QuestionTypeModel questionTypeModel)
    {
        return Result(await _questionTypeService.UpdateQuestionType(questionTypeModel));
    }
}
