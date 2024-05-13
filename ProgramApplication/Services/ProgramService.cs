using Mapster;

namespace ProgramApplication;

public class ProgramService : IProgramService
{
    private readonly IBaseRepository<Programs> _programRepository;

    public ProgramService(IBaseRepository<Programs> programRepository)
    {
        _programRepository = programRepository;
    }


    public async Task<StandardResponse<ProgramView>> CreateProgram(ProgramModel programModel)
    {
        var program = programModel.Adapt<Programs>();

        program = await _programRepository.CreateAndReturn(program);
        var programView = program.Adapt<ProgramView>();

        return StandardResponse<ProgramView>.Ok(programView);
    }

    public async Task<StandardResponse<IEnumerable<ProgramView>>> GetAllPrograms()
    {
        var programs = await _programRepository.GetAll();
        var programViews = programs.Adapt<IEnumerable<ProgramView>>();

        return StandardResponse<IEnumerable<ProgramView>>.Ok(programViews);
    }

    public async Task<StandardResponse<ProgramView>> GetProgramById(Guid id)
    {
        var program = await _programRepository.GetById(id); 
        var programView = program.Adapt<ProgramView>();

        return StandardResponse<ProgramView>.Ok(programView);
    }

    public async Task<StandardResponse<ProgramView>> AddQuestionToProgram(Guid programId, QuestionsModel questionModel)
    {
        var program = await _programRepository.GetById(programId);
        var question = questionModel.Adapt<Question>();

        program.Questions.Add(question);
        program = await _programRepository.Update(program);
        var programView = program.Adapt<ProgramView>();

        return StandardResponse<ProgramView>.Ok(programView);
    }

    public async Task<StandardResponse<ProgramView>> RemoveQuestionFromProgram(Guid programId, Guid questionId)
    {
        var program = await _programRepository.GetById(programId);

        program.Questions = program.Questions.Where(q => q.Id != questionId).ToList();

        program = await _programRepository.Update(program);
        var programView = program.Adapt<ProgramView>();

        return StandardResponse<ProgramView>.Ok(programView);
    }

    public async Task<StandardResponse<ProgramView>> UpdateProgram(ProgramModel programModel)
    {
        var program = programModel.Adapt<Programs>();

        program = await _programRepository.Update(program);
        var programView = program.Adapt<ProgramView>();

        return StandardResponse<ProgramView>.Ok(programView);
    }

    public async Task<StandardResponse<SubmissionView>> SubmitProgram(Guid programId, SubmissionModel submissionModel)
    {
        var program = await _programRepository.GetById(programId);
        var submission = submissionModel.Adapt<Submission>();

        program.Submissions.Add(submission);
        program = await _programRepository.Update(program);
        var submissionView = submission.Adapt<SubmissionView>();

        return StandardResponse<SubmissionView>.Ok(submissionView);
    }
}
