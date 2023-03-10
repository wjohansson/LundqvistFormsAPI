using FormsLibrary.Models;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;

namespace LundqvistFormsAPI.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly FormsContext _dbContext;

        public QuestionService(FormsContext context)
        {
            _dbContext = context;
        }

        public async Task<QuestionModel> CreateQuestion(QuestionModel question)
        {
            await _dbContext.Questions.AddAsync(question);
            await _dbContext.SaveChangesAsync();
            return question;
        }

        public async Task<List<QuestionModel>> CurrentQuestions(SegmentModel segment)
        {
            return _dbContext.Questions
                .Include(x => x.Answers.OrderBy(x => x.AnswerDate)).ThenInclude(x => x.MultipleChoice)
                .Include(x => x.Answers.OrderBy(x => x.AnswerDate)).ThenInclude(x => x.Interval)
                .Include(x => x.ScaleOptions)
                .Include(x => x.ChoiceOptions.OrderBy(x => x.ChoiceOrder))
                .ToList();
        }

        public async Task DeleteQuestion(QuestionModel question)
        {
            _dbContext.Questions.Remove(question);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<QuestionModel> EditQuestion(QuestionModel question)
        {
            QuestionModel newQuestion = _dbContext.Questions.Include(x => x.Answers).First(x => x.QuestionId == question.QuestionId);

            newQuestion.QuestionTitle = question.QuestionTitle ?? newQuestion.QuestionTitle;
            newQuestion.QuestionOption = question.QuestionOption;

            await _dbContext.SaveChangesAsync();

            return question;
        }

        public async Task<QuestionModel> GetQuestion(QuestionModel question)
        {
            return _dbContext.Questions
                .Include(x => x.Answers.OrderBy(x => x.AnswerDate)).ThenInclude(x => x.MultipleChoice)
                .Include(x => x.Answers.OrderBy(x => x.AnswerDate)).ThenInclude(x => x.Interval)
                .Include(x => x.ScaleOptions)
                .Include(x => x.ChoiceOptions.OrderBy(x => x.ChoiceOrder))
                .First(x => x.QuestionId == question.QuestionId);
        }

        public async Task<QuestionModel> GetQuestionById(Guid? questionId)
        {
            return _dbContext.Questions
                .Include(x => x.Answers.OrderBy(x => x.AnswerDate)).ThenInclude(x => x.MultipleChoice)
                .Include(x => x.Answers.OrderBy(x => x.AnswerDate)).ThenInclude(x => x.Interval)
                .Include(x => x.ScaleOptions)
                .Include(x => x.ChoiceOptions.OrderBy(x => x.ChoiceOrder))
                .First(x => x.QuestionId == questionId);
        }
    }
}
