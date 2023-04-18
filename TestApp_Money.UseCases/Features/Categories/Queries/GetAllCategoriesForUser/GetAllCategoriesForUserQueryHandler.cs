using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp_Money.Infrastructure.Interfaces.DataAccessInterfaces;

namespace TestApp_Money.UseCases.Features.Categories.Queries.GetAllCategoriesForUser
{
    public class GetAllCategoriesForUserQueryHandler : IRequestHandler<GetAllCategoriesForUserQuery, IEnumerable<CategoryDto>>
    {
        private IDbContext _context;
        public IMapper _mapper;

        public GetAllCategoriesForUserQueryHandler(IDbContext context, IMapper mapper = null)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesForUserQuery request, CancellationToken cancellationToken)
        {
            var categories = _context.Categories
                .Where(x => x.User.Id == request.UserId)
                .ToList();

            var result = _mapper.Map<List<CategoryDto>>(categories);

            return result;
        }
    }
}
