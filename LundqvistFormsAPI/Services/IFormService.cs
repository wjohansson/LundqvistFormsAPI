using FormsLibrary.Models;

namespace LundqvistFormsAPI.Services
{
    public interface IFormService
    {
        Task<FormModel> CreateForm(FormModel form);

        Task<FormModel> DeleteForm(FormModel form);

        Task<FormModel> EditForm(FormModel form);

        Task<List<FormModel>> GetAllForms();

        Task<FormModel> GetForm(FormModel form);

        Task<FormModel> GetFormById(Guid? formId);

    }
}
