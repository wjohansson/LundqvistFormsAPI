using FormsLibrary.Models;
using LundqvistFormsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Collections.Specialized.BitVector32;

namespace LundqvistFormsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SegmentController : Controller
    {
        private readonly ISegmentService _segmentService;

        public SegmentController(ISegmentService segmentService)
        {
            _segmentService = segmentService;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<SegmentModel>> CreateSegment()
        {
            try
            {
                SegmentModel? segment = Request.ReadFromJsonAsync<SegmentModel>().Result;
                var newForm = await _segmentService.CreateSegment(segment);

                return Ok(newForm);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong with creating the segment");
            }
        }

        [HttpGet("Current")]
        public async Task<ActionResult<List<SegmentModel>>> GetAllSegments()
        {
            try
            {
                FormModel? form = Request.ReadFromJsonAsync<FormModel>().Result;
                return Ok(await _segmentService.CurrentSegments(form));
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong with editing the segment");
            }
        }

        [HttpPut("Delete")]
        public async Task<ActionResult> DeleteSegment()
        {
            try
            {
                SegmentModel? segment = Request.ReadFromJsonAsync<SegmentModel>().Result;
                await _segmentService.DeleteSegment(segment);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong with deleting the segment");
            }
        }

        [HttpPut("Edit")]
        public async Task<ActionResult<FormModel>> EditSegment()
        {
            try
            {
                SegmentModel? segment = Request.ReadFromJsonAsync<SegmentModel>().Result;
                return Ok(await _segmentService.EditSegment(segment));
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong with editing the segment");
            }
        }

        [HttpPut]
        public async Task<ActionResult<SegmentModel>> GetSegment()
        {
            try
            {
                SegmentModel? segment = Request.ReadFromJsonAsync<SegmentModel>().Result;
                return Ok(await _segmentService.GetSegment(segment));
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong with getting the segment");
            }
        }
    }
}
