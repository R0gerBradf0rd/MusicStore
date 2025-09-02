using MusicStore.Application.Results;
using MusicStore.Presentation.Contracts.Reviews.CreateReview;

namespace MusicStore.Presentation.Mappers.ReviewMappingExtensions.CreateReview
{
    public static class CreateReviewResultToResponse
    {
        public static CreateReviewResponse ToCreateReviewResponse( this Result<Guid> result )
        {
            return new CreateReviewResponse( result.Value );
        }
    }
}
