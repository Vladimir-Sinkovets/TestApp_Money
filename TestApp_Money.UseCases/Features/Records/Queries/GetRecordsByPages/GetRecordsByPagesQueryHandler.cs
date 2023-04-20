using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp_Money.Infrastructure.Interfaces.DataAccessInterfaces;

namespace TestApp_Money.UseCases.Features.Records.Queries.GetRecordsByPages
{
    public class GetRecordsByPagesQueryHandler : IRequestHandler<GetRecordsByPagesQuery, IEnumerable<RecordDto>>
    {
        private IDbContext _context;
        private IMapper _mapper;

        public GetRecordsByPagesQueryHandler(IDbContext context, IMapper mapper = null)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<IEnumerable<RecordDto>> Handle(GetRecordsByPagesQuery request, CancellationToken cancellationToken)
        {
            var records = _context.Records
                .Include(r => r.Category)
                .Where(r => r.User.Id == request.UserId)
                .Skip((request.ItemsPerPage - 1) * request.PageNumber)
                .Take(request.ItemsPerPage);

            var resultList = _mapper.Map<List<RecordDto>>(records);

            return Task.FromResult(resultList.AsEnumerable());
        }
    }
}
