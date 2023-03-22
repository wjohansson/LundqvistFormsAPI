using FormsLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace LundqvistFormsAPI.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly FormsContext _dbContext;

        public AnswerService(FormsContext context)
        {
            _dbContext = context;
        }

        public async Task<AnswerModel> CreateAnswer(AnswerModel answer)
        {
            answer.AnswerDate = DateTime.Now;
            await _dbContext.Answers.AddAsync(answer);
            await _dbContext.SaveChangesAsync();
            return answer;
        }

        public async Task<List<AnswerModel>> CurrentAnswers(Guid? formId)
        {
            return _dbContext.Answers.Where(x => x.FormId == formId)
                .Include(x => x.MultipleChoice)
                .Include(x => x.Interval)
                .ToList();
        }
    }
}
