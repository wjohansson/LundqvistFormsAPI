using FormsLibrary.Models;
using LundqvistFormsAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LundqvistFormsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormController : Controller
    {
        private readonly IFormService _formService;

        public FormController(IFormService formService)
        {
            _formService = formService;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<FormModel>> CreateForm()
        {
            try
            {
                FormModel? form = Request.ReadFromJsonAsync<FormModel>().Result;
                var newForm = await _formService.CreateForm(form);

                return Ok(newForm);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong with creating the form");
            }

        }

        [HttpPut("Delete")]
        public async Task<ActionResult<FormModel>> DeleteForm()
        {
            try
            {
                FormModel? form = Request.ReadFromJsonAsync<FormModel>().Result;
                return Ok(await _formService.DeleteForm(form));
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong with deleting the form");
            }
        }

        [HttpPut("Edit")]
        public async Task<ActionResult<FormModel>> EditForm()
        {
            try
            {
                FormModel? form = Request.ReadFromJsonAsync<FormModel>().Result;
                return Ok(await _formService.EditForm(form));
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong with editing the form");
            }
        }

        [HttpGet("All")]
        public async Task<ActionResult<List<FormModel>>> GetAllForms()
        {
            return Ok(await _formService.GetAllForms());
        }

        [HttpPut]
        public async Task<ActionResult<FormModel>> GetForm()
        {
            try
            {
                FormModel? form = Request.ReadFromJsonAsync<FormModel>().Result;
                return Ok(await _formService.GetForm(form));
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong with getting the form");
            }
        }

        [HttpPut($"GetById")]
        public async Task<ActionResult<FormModel>> GetFormById()
        {
            try
            {
                Guid? formId = Request.ReadFromJsonAsync<Guid>().Result;
                return Ok(await _formService.GetFormById(formId));
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong with getting the form");
            }
        }
    }
}
