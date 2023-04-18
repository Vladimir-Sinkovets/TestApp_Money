using MediatR;
using Microsoft.AspNetCore.Identity;
using TestApp_Money.Entites.Models;
using TestApp_Money.Infrastructure.Interfaces.DataAccessInterfaces;

namespace TestApp_Money.UseCases.Features.Categories.Commands.AddCategory
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, Guid>
    {
        private IDbContext _context;
        private UserManager<User> _userManager;

        public AddCategoryCommandHandler(IDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<Guid> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category()
            {
                Name = request.CategoryName,
                User = _context.Users.Single(u => u.Id == request.UserId),
            };

            _context.Categories.Add(category);

            _context.SaveChanges();

            return category.Id;
        }
    }
}
