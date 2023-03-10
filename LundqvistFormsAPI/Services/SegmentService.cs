using FormsLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace LundqvistFormsAPI.Services
{
    public class SegmentService : ISegmentService
    {
        private readonly FormsContext _dbContext;

        public SegmentService(FormsContext context)
        {
            _dbContext = context;
        }

        public async Task<SegmentModel> CreateSegment(SegmentModel segment)
        {
            await _dbContext.Segments.AddAsync(segment);
            await _dbContext.SaveChangesAsync();
            return segment;
        }

        public async Task<List<SegmentModel>> CurrentSegments(FormModel form)
        {
            return _dbContext.Segments.Include(x => x.Questions).ToList();
        }

        public async Task DeleteSegment(SegmentModel segment)
        {
            _dbContext.Segments.Remove(segment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<SegmentModel> EditSegment(SegmentModel segment)
        {
            SegmentModel newForm = _dbContext.Segments.Include(x => x.Questions).First(x => x.SegmentId == segment.SegmentId);

            newForm.SegmentTitle = segment.SegmentTitle ?? newForm.SegmentTitle;
            newForm.SegmentDescription = segment.SegmentDescription ?? newForm.SegmentDescription;

            await _dbContext.SaveChangesAsync();

            return segment;
        }

        public async Task<SegmentModel> GetSegment(SegmentModel segment)
        {
            return _dbContext.Segments.Include(x => x.Questions).First(x => x.SegmentId == segment.SegmentId);
        }
    }
}
