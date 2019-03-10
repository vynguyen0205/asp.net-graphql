using CarvedRock.Api.Data.Entities;
using CarvedRock.Api.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;

namespace CarvedRock.Api.GraphQL.Types
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType(ProductReviewRepository reviewRepository, IDataLoaderContextAccessor dataLoaderContextAccessor)
        {
            Name = "Product";
            Description = "A representation a product";

            Field(t => t.Id).Description("Unique Id of the product");
            Field(t => t.Name).Description("Name of the product");
            Field(t => t.Description).Description("Description of the product");
            Field(t => t.IntroducedAt).Description("When the product was first introduced");
            Field(t => t.PhotoFileName).Description("File name of the product photo");
            Field(t => t.Price).Description("Price of the product");
            Field(t => t.Rating).Description("Customer average rating of the product");
            Field(t => t.Stock).Description("Number of the products left in stock");
            Field<ProductTypeEnumType>("Type", "Type of the product");

            ////Will result in N+1 query issue, avoid this approach
            //Field<ListGraphType<ProductReviewType>>(
            //    "reviews",
            //    resolve: context => reviewRepository.GetForProduct(context.Source.Id));

            Field<ListGraphType<ProductReviewType>>(
                "reviews",
                resolve: context =>
                {
                    var loader = dataLoaderContextAccessor.Context.GetOrAddCollectionBatchLoader<int, ProductReview>(
                        "GetReviewsByProductId", reviewRepository.GetForProducts);
                    return loader.LoadAsync(context.Source.Id);
                }
            );
        }
    }
}
