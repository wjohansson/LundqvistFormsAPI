using FormsLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace LundqvistFormsAPI.Services
{
    public class FormService : IFormService
    {
        private readonly FormsContext _dbContext;

        public FormService(FormsContext context)
        {
            _dbContext = context;
        }

        public async Task<int> CountAnswers(FormModel form)
        {
            List<AnswerModel> formAnswers = _dbContext.Answers.Where(x => x.FormId == form.FormId).ToList();
            int answers = formAnswers
             .Select(x => x.AnswerGroupId)
             .Distinct()
             .ToList().Count;
            return answers;
        }

        public async Task<FormModel> CreateForm(FormModel form)
        {
            form.FormId = Guid.NewGuid();

            foreach (SegmentModel segment in form.Segments)
            {
                segment.SegmentId = Guid.NewGuid();

                foreach (QuestionModel question in segment.Questions)
                {
                    question.QuestionId = Guid.NewGuid();

                    foreach (ChoiceModel choice in question.ChoiceOptions)
                    {
                        choice.ChoiceId = Guid.NewGuid();
                    }

                    question.ScaleOptions.ScaleId = Guid.NewGuid();
                }
            }
            form.FormDate = DateTime.Now;
            await _dbContext.Forms.AddAsync(form);
            await _dbContext.SaveChangesAsync();
            return form;
        }

        public async Task<FormModel> DeleteForm(FormModel form)
        {
            var oldForm = _dbContext.Forms.First(x => x.Equals(form));
            _dbContext.Forms.Remove(oldForm);
            await _dbContext.SaveChangesAsync();
            return oldForm;
        }

        public async Task<FormModel> EditForm(FormModel form)
        {
            FormModel oldForm = _dbContext.Forms
                .Include(x => x.Answers.OrderBy(x => x.AnswerDate)).ThenInclude(x => x.MultipleChoice)
                .Include(x => x.Answers.OrderBy(x => x.AnswerDate)).ThenInclude(x => x.Interval)
                .First(x => x.FormId == form.FormId);

            _dbContext.Forms.Remove(oldForm);
            await _dbContext.SaveChangesAsync();

            foreach (AnswerModel answer in oldForm.Answers.ToList())
            {
                form.Answers.Add(answer);
            }

            await _dbContext.Forms.AddAsync(form);
            await _dbContext.SaveChangesAsync();

            return form;
        }

        public async Task<List<FormModel>> GetAllForms()
        {
            return _dbContext.Forms
                .OrderBy(x => x.FormDate)
                .Include(x => x.Segments.OrderBy(x => x.SegmentOrder)).ThenInclude(x => x.Questions.OrderBy(x => x.QuestionOrder))
                .ToList();
        }

        public async Task<FormModel> GetFormById(Guid? formId)
        {
            FormModel form = _dbContext.Forms
                .Include(x => x.Segments.OrderBy(x => x.SegmentOrder)).ThenInclude(x => x.Questions.OrderBy(x => x.QuestionOrder)).ThenInclude(x => x.ChoiceOptions.OrderBy(x => x.ChoiceOrder))
                .Include(x => x.Segments.OrderBy(x => x.SegmentOrder)).ThenInclude(x => x.Questions.OrderBy(x => x.QuestionOrder)).ThenInclude(x => x.ScaleOptions)
                .First(x => x.FormId == formId);
            return form;
        }
    }
}
