using Microsoft.AspNetCore.Mvc;

namespace ProgramApplication;

[ApiController]
[Route("api/[controller]")]
public class ProgramController : StandardControllerBase
{
    private readonly IProgramService _programService;

    public ProgramController(IProgramService programService)
    {
        _programService = programService;
    }


    [HttpPost("create", Name = nameof(CreateProgram))]
    [ProducesResponseType(typeof(StandardResponse<ProgramView>), 200)]
    [ProducesResponseType(typeof(StandardResponse<ProgramView>), 400)]
    [ProducesResponseType(typeof(StandardResponse<ProgramView>), 500)]
    public async Task<ActionResult<StandardResponse<ProgramView>>> CreateProgram([FromBody]ProgramModel programModel)
    {
        return Result(await _programService.CreateProgram(programModel));
    }

    [HttpGet("list", Name = nameof(GetAllPrograms))]
    [ProducesResponseType(typeof(StandardResponse<IEnumerable<ProgramView>>), 200)]
    [ProducesResponseType(typeof(StandardResponse<IEnumerable<ProgramView>>), 400)]
    [ProducesResponseType(typeof(StandardResponse<IEnumerable<ProgramView>>), 500)]
    public async Task<ActionResult<StandardResponse<IEnumerable<ProgramView>>>> GetAllPrograms()
    {
        return Result(await _programService.GetAllPrograms());
    }

    [HttpGet("get/{id}", Name = nameof(GetProgramById))]
    [ProducesResponseType(typeof(StandardResponse<ProgramView>), 200)]
    [ProducesResponseType(typeof(StandardResponse<ProgramView>), 400)]
    [ProducesResponseType(typeof(StandardResponse<ProgramView>), 500)]
    public async Task<ActionResult<StandardResponse<ProgramView>>> GetProgramById(Guid id)
    {
        return Result(await _programService.GetProgramById(id));
    }


    [HttpPost("addQuestion/{programId}", Name = nameof(AddQuestionToProgram))]
    [ProducesResponseType(typeof(StandardResponse<ProgramView>), 200)]
    [ProducesResponseType(typeof(StandardResponse<ProgramView>), 400)]
    [ProducesResponseType(typeof(StandardResponse<ProgramView>), 500)]
    public async Task<ActionResult<StandardResponse<ProgramView>>> AddQuestionToProgram(Guid programId, [FromBody]QuestionsModel questionModel)
    {
        return Result(await _programService.AddQuestionToProgram(programId, questionModel));
    }

    [HttpDelete("removeQuestion/{programId}/{questionId}", Name = nameof(RemoveQuestionFromProgram))]
    [ProducesResponseType(typeof(StandardResponse<ProgramView>), 200)]
    [ProducesResponseType(typeof(StandardResponse<ProgramView>), 400)]
    [ProducesResponseType(typeof(StandardResponse<ProgramView>), 500)]
    public async Task<ActionResult<StandardResponse<ProgramView>>> RemoveQuestionFromProgram(Guid programId, Guid questionId)
    {
        return Result(await _programService.RemoveQuestionFromProgram(programId, questionId));
    }

    [HttpPost("submit/{programId}", Name = nameof(SubmitProgram))]
    [ProducesResponseType(typeof(StandardResponse<SubmissionView>), 200)]
    [ProducesResponseType(typeof(StandardResponse<SubmissionView>), 400)]
    [ProducesResponseType(typeof(StandardResponse<SubmissionView>), 500)]
    public async Task<ActionResult<StandardResponse<SubmissionView>>> SubmitProgram(Guid programId, [FromBody]SubmissionModel submissionModel)
    {
        return Result(await _programService.SubmitProgram(programId, submissionModel));
    }
}
