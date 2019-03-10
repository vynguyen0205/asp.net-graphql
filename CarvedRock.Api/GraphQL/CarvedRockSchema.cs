using GraphQL;
using GraphQL.Types;

namespace CarvedRock.Api.GraphQL
{
    public class CarvedRockSchema : Schema
    {
        public CarvedRockSchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<CarvedRockQuery>();
            Subscription = resolver.Resolve<CarvedRockSubscription>();
            Mutation = resolver.Resolve<CarvedRockMutation>();
        }
    }
}
