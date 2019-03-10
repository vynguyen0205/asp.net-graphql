using CarvedRock.Api.Data.Entities;
using GraphQL.Types;


namespace CarvedRock.Api.GraphQL.Types
{
    public class ProductReviewType: ObjectGraphType<ProductReview>
    {
        public ProductReviewType()
        {
            Name = "Review";
            Description = "Customer review of a product";

            Field(t => t.Id).Description("Id of the review");
            Field(t => t.Title).Description("Title of the review");
            Field(t => t.Review).Description("Content of the review");
        }
    }
}
