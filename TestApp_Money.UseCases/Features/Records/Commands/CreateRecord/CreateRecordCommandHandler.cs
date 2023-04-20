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

        public Task<Guid> Handle(CreateRecordCommand request, CancellationToken cancellationToken)
        {
            var category = _context.Categories.First(c => c.Name == request.Category);

            var user = _context.Users.Single(u => u.Id == request.UserId);

            var record = new Record()
            {
                Description = request.Description,
                CreatedDate = request.CreatedDate,
                Id = Guid.NewGuid(),
                Value = request.Value,
                Category = category,
                User = user,
            };

            _context.Records.Add(record);

            _context.SaveChanges();

            return Task.FromResult(record.Id);
        }
    }
}
