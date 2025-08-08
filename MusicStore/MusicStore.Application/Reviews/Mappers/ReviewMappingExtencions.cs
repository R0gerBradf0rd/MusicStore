using MusicStore.Application.Reviews.Dtos;
using MusicStore.Domain.Entities.Reviews;

namespace MusicStore.Application.Reviews.Mappers
{
    public static class ReviewMappingExtencions
    {
        public static ReviewDto ToDto( this Review review )
        {
            return new ReviewDto
            (
                review.Rating,
                review.Comment
            );
        }
    }
}
