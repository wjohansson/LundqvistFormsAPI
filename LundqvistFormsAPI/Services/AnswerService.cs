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

        public async Task<List<AnswerModel>> CurrentAnswers(QuestionModel question)
        {
            return _dbContext.Answers.ToList();
        }

        public async Task DeleteAnswer(AnswerModel answer)
        {
            _dbContext.Answers.Remove(answer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<AnswerModel> EditAnswer(AnswerModel answer)
        {
            AnswerModel newAnswer = _dbContext.Answers.First(x => x.AnswerId == answer.AnswerId);

            newAnswer.MultipleChoice = answer.MultipleChoice;
            newAnswer.SingleChoice = answer.SingleChoice;
            newAnswer.DropdownChoice = answer.DropdownChoice;
            newAnswer.Scale = answer.Scale;
            newAnswer.Date = answer.Date;
            newAnswer.Interval.StartDate = answer.Interval.StartDate;
            newAnswer.Interval.EndDate = answer.Interval.EndDate;
            newAnswer.Time = answer.Time;
            newAnswer.ShortAnswer = answer.ShortAnswer;
            newAnswer.LongAnswer = answer.LongAnswer;

            await _dbContext.SaveChangesAsync();

            return answer;
        }

        public async Task<AnswerModel> GetAnswer(AnswerModel answer)
        {
            return _dbContext.Answers.First(x => x.AnswerId == answer.AnswerId);

        }
    }
}
