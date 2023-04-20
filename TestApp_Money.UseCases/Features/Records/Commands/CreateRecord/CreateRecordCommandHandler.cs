using AutoMapper;
using MediatR;
using TestApp_Money.Entites.Models;
using TestApp_Money.Infrastructure.Interfaces.DataAccessInterfaces;

namespace TestApp_Money.UseCases.Features.Records.Commands.CreateRecord
{
    public class CreateRecordCommandHandler : IRequestHandler<CreateRecordCommand, Guid>
    {
        private IDbContext _context;
        private IMapper _mapper;

        public CreateRecordCommandHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateRecordCommand request, CancellationToken cancellationToken)
        {
            var category = _context.Categories.First(x => x.Name == request.Category);

            var record = new Record()
            {
                Description = request.Description,
                CreatedDate = request.CreatedDate,
                Id = Guid.NewGuid(),
                Value = request.Value,
                Category = category,
            };

            _context.Records.Add(record);

            await _context.SaveChangesAsync(CancellationToken.None);

            return record.Id;
        }
    }
}
