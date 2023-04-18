using MediatR;

namespace TestApp_Money.UseCases.Features.Categories.Queries.GetAllCategoriesForUser
{
    public class GetAllCategoriesForUserQuery : IRequest<IEnumerable<CategoryDto>>
    {
        public string UserId { get; set; }
    }
}
