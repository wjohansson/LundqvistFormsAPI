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

        [HttpPut("Delete")]
        public async Task<ActionResult> DeleteAnswer()
        {
            try
            {
                AnswerModel? answer = await Request.ReadFromJsonAsync<AnswerModel>();
                await _answerService.DeleteAnswer(answer);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong with deleting the answer");
            }
        }

        [HttpPut("Edit")]
        public async Task<ActionResult<FormModel>> EditAnswer()
        {
            try
            {
                AnswerModel? answer = Request.ReadFromJsonAsync<AnswerModel>().Result;
                return Ok(await _answerService.EditAnswer(answer));
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong with editing the answer");
            }
        }

        [HttpPut]
        public async Task<ActionResult<AnswerModel>> GetAnswer()
        {
            try
            {
                AnswerModel? answer = Request.ReadFromJsonAsync<AnswerModel>().Result;
                return Ok(await _answerService.GetAnswer(answer));
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong with getting the answer");
            }
        }
    }
}
