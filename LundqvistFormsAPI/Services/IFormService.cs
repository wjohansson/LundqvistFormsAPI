﻿using FormsLibrary.Models;

namespace LundqvistFormsAPI.Services
{
    public interface IFormService
    {
        Task<int> CountAnswers(FormModel form);

        Task<FormModel> CreateForm(FormModel form);

        Task<FormModel> DeleteForm(FormModel form);

        Task<FormModel> EditForm(FormModel form);

        Task<List<FormModel>> GetAllForms();

        Task<FormModel> GetFormById(Guid? formId);

    }
}
