using FormsLibrary.Models;

namespace LundqvistFormsAPI.Services
{
    public interface ISegmentService
    {
        Task<SegmentModel> CreateSegment(SegmentModel segment);

        Task DeleteSegment(SegmentModel segment);

        Task<SegmentModel> EditSegment(SegmentModel segment);

        Task<List<SegmentModel>> CurrentSegments(FormModel form);

        Task<SegmentModel> GetSegment(SegmentModel segment);
    }
}
