using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ProgramApplication;

public class ProgramService : IProgramService
{
    private readonly IBaseRepository<Programs> _programRepository;
    private readonly IBaseRepository<QuestionType> _questionTypeRepository;

    public ProgramService(IBaseRepository<Programs> programRepository, IBaseRepository<QuestionType> questionTypeRepository)
    {
        _programRepository = programRepository;
        _questionTypeRepository = questionTypeRepository;
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
        var programs =  _programRepository.Query().Include(p => p.Questions).ToList();
        var programViews = programs.Adapt<IEnumerable<ProgramView>>();

        // add question type view to all the questions in the program
        programViews = programViews.Select(p => 
        {
            p.Questions = p.Questions.Select(q => 
            {
                q.QuestionTypeView = GetQuestionTypeView(q.QuestionTypeId).Result;
                return q;
            }).ToList();
            return p;
        }).ToList();

        return StandardResponse<IEnumerable<ProgramView>>.Ok(programViews);
    }

    public async Task<StandardResponse<ProgramView>> GetProgramById(Guid id)
    {
        var program =  _programRepository.Query().Include(p => p.Questions).FirstOrDefault(x => x.Id == id); 
        var programView = program.Adapt<ProgramView>();

        // add question type view to all the questions in the program
        programView.Questions = programView.Questions.Select(q => 
        {
            q.QuestionTypeView = GetQuestionTypeView(q.QuestionTypeId).Result;
            return q;
        }).ToList();

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

    public async Task<StandardResponse<ProgramView>> UpdateProgramQuestion(QuestionsModel model, Guid programId)
    {
        var program = await _programRepository.GetById(programId);
        var question = program.Questions.FirstOrDefault(q => q.Id == model.Id);

        question = model.Adapt(question);
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


    private async Task<QuestionTypeView> GetQuestionTypeView(Guid questionTypeId)
    {
        var questionType = await _questionTypeRepository.GetById(questionTypeId);
        var questionTypeView = questionType.Adapt<QuestionTypeView>();

        return questionTypeView;
    }
}
