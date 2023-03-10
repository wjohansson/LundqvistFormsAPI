using FormsLibrary.Models;
using LundqvistFormsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LundqvistFormsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<QuestionModel>> CreateQuestion()
        {
            try
            {
                QuestionModel? question = Request.ReadFromJsonAsync<QuestionModel>().Result;
                var newForm = await _questionService.CreateQuestion(question);

                return Ok(newForm);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong with creating the question");
            }

        }

        [HttpGet("Current")]
        public async Task<ActionResult<List<QuestionModel>>> CurrentQuestions()
        {
            try
            {
                SegmentModel? segment = Request.ReadFromJsonAsync<SegmentModel>().Result;
                return Ok(await _questionService.CurrentQuestions(segment));
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong with getting the questions");
            }
        }

        [HttpPut("Delete")]
        public async Task<ActionResult> DeleteQuestion()
        {
            try
            {
                QuestionModel? question =  Request.ReadFromJsonAsync<QuestionModel>().Result;
                await _questionService.DeleteQuestion(question);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong with deleting the question");
            }
        }

        [HttpPut("Edit")]
        public async Task<ActionResult<FormModel>> EditQuestion()
        {
            try
            {
                QuestionModel? question = Request.ReadFromJsonAsync<QuestionModel>().Result;
                return Ok(await _questionService.EditQuestion(question));
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong with editing the question");
            }
        }

        [HttpPut]
        public async Task<ActionResult<QuestionModel>> GetQuestion()
        {
            try
            {
                QuestionModel? question = Request.ReadFromJsonAsync<QuestionModel>().Result;
                return Ok(await _questionService.GetQuestion(question));
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong with getting the question");
            }
        }

        [HttpPut($"GetById")]
        public async Task<ActionResult<QuestionModel>> GetQuestionById()
        {
            try
            {
                Guid? questionId = Request.ReadFromJsonAsync<Guid>().Result;
                return Ok(await _questionService.GetQuestionById(questionId));
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong with getting the question");
            }
        }
    }
}
