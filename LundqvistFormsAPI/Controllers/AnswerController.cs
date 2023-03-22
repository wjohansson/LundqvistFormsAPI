using FormsLibrary.Models;
using LundqvistFormsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LundqvistFormsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnswerController : Controller
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<AnswerModel>> CreateAnswer()
        {
            try
            {
                AnswerModel? answer = await Request.ReadFromJsonAsync<AnswerModel>();
                var newForm = await _answerService.CreateAnswer(answer);

                return Ok(newForm);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong with creating the answer");
            }

        }

        [HttpPut("Current")]
        public async Task<ActionResult<List<AnswerModel>>> CurrentAnswers()
        {
            try
            {
                Guid? formId = Request.ReadFromJsonAsync<Guid>().Result;
                return Ok(await _answerService.CurrentAnswers(formId));
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong with getting the answers");
            }
        }
    }
}
