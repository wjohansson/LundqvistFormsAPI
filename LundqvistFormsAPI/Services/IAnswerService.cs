using FormsLibrary.Models;

namespace LundqvistFormsAPI.Services
{
    public interface IAnswerService
    {
        Task<AnswerModel> CreateAnswer(AnswerModel answer);

        Task DeleteAnswer(AnswerModel answer);

        Task<AnswerModel> EditAnswer(AnswerModel answer);

        Task<List<AnswerModel>> CurrentAnswers(Guid? formId);

        Task<AnswerModel> GetAnswer(AnswerModel answer);
    }
}
