using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace CarvedRock.Api.GraphQL.Types
{
    public class ProductReviewInputType: InputObjectGraphType
    {
        public ProductReviewInputType()
        {
            Name = "reviewInput";

            Field<NonNullGraphType<StringGraphType>>("title", "Title of the review");
            Field<StringGraphType>("review", "Content of the review");
            Field<NonNullGraphType<IntGraphType>>("productId", "Id of the product");

        }
    }
}
