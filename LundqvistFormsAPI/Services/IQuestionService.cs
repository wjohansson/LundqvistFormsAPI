using FormsLibrary.Models;

namespace LundqvistFormsAPI.Services
{
    public interface IQuestionService
    {
        Task<QuestionModel> CreateQuestion(QuestionModel question);

        Task DeleteQuestion(QuestionModel question);

        Task<QuestionModel> EditQuestion(QuestionModel question);

        Task<List<QuestionModel>> CurrentQuestions(SegmentModel segment);

        Task<QuestionModel> GetQuestion(QuestionModel question);
        Task<QuestionModel> GetQuestionById (Guid? questionId);
    }
}
