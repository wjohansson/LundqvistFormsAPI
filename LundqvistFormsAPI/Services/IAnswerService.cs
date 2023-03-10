using FormsLibrary.Models;

namespace LundqvistFormsAPI.Services
{
    public interface IAnswerService
    {
        Task<AnswerModel> CreateAnswer(AnswerModel answer);

        Task DeleteAnswer(AnswerModel answer);

        Task<AnswerModel> EditAnswer(AnswerModel answer);

        Task<List<AnswerModel>> CurrentAnswers(QuestionModel question);

        Task<AnswerModel> GetAnswer(AnswerModel answer);
    }
}
