using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp_Money.Infrastructure.Interfaces.DataAccessInterfaces;

namespace TestApp_Money.UseCases.Features.Records.Queries.GetRecordById
{
    public class GetRecordByIdCommandHandler : IRequestHandler<GetRecordByIdCommand, SingleRecordData>
    {
        private IDbContext _context;
        private IMapper _mapper;

        public GetRecordByIdCommandHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<SingleRecordData> Handle(GetRecordByIdCommand request, CancellationToken cancellationToken)
        {
            var record = _context.Records
                .Include(r => r.User)
                .FirstOrDefault(r => r.Id == request.Id && r.User.Id == request.UserId);

            var recordData = _mapper.Map<SingleRecordData>(record);

            return Task.FromResult(recordData);
        }
    }
}
