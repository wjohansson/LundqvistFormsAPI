using FormsLibrary.Models;

namespace LundqvistFormsAPI.Services
{
    public interface IAnswerService
    {
        Task<AnswerModel> CreateAnswer(AnswerModel answer);

        Task<List<AnswerModel>> CurrentAnswers(Guid? formId);
    }
}
