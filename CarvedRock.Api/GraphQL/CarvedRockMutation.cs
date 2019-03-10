using CarvedRock.Api.Data.Entities;
using CarvedRock.Api.GraphQL.Types;
using CarvedRock.Api.Repositories;
using GraphQL.Types;

namespace CarvedRock.Api.GraphQL
{
    public class CarvedRockMutation : ObjectGraphType
    {
        public CarvedRockMutation(ProductReviewRepository reviewRepository, ReviewMessageService messageService)
        {
            FieldAsync<ProductReviewType>(
                "createReview",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProductReviewInputType>>
                {
                    Name = "review"
                }),
                resolve: async context =>
                {
                    var review = context.GetArgument<ProductReview>("review");
                    await reviewRepository.AddReview(review);

                    messageService.AddReviewAddedMessage(review);
                    return review;
                });

            FieldAsync<BooleanGraphType>(
                "deleteReview",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                {
                    Name = "id"
                }),
                resolve: async context =>
                {
                    var id = context.GetArgument<int>("id");
                    return await context.TryAsyncResolve(
                        async c => await reviewRepository.DeleteReview(id));
                });
        }
    }
}
