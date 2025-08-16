using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;

namespace MusicStore.Application.Reviews.Commands.CreateReview
{
    public class CreateReviewCommandValidator : IValidator<CreateReviewCommand>
    {
        public Result Validate( CreateReviewCommand request )
        {
            if ( request.UserId == Guid.Empty )
            {
                return Result.Failure( "Id пользователя не может быть пустым!" );
            }
            if ( request.ProductId == Guid.Empty )
            {
                return Result.Failure( "Id продукта не может быть пустым!" );
            }
            if ( request.Rating < 0 || request.Rating > 5 )
            {
                return Result.Failure( "Рейтинг не может быть больше 5 и меньше 0!" );
            }

            return Result.Success();
        }
    }
}
