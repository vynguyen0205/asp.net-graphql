using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.Api.GraphQL.Types
{
    public class ProductReviewDeleteInputType : InputObjectGraphType
    {
        public ProductReviewDeleteInputType()
        {
            Name = "reviewDeleteInput";

            Field<NonNullGraphType<IntGraphType>>("productId", "Id of the product");
        }
    }
}
