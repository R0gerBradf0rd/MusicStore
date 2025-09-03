using MusicStore.Application.Reviews.Commands.CreateReview;
using MusicStore.Presentation.Contracts.Reviews.CreateReview;

namespace MusicStore.Presentation.Mappers.ReviewMappingExtensions.CreateReview
{
    public static class CreateReviewRequestToCommandMappingExtension
    {
        public static CreateReviewCommand ToCreateReviewCommand( this CreateReviewRequest request )
        {
            return new CreateReviewCommand( request.ProductId, request.UserId, request.Rating, request.Comment );
        }
    }
}
