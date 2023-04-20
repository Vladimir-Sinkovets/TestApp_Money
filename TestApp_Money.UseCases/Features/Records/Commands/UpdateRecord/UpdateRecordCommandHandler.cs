using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using TestApp_Money.Infrastructure.Interfaces.DataAccessInterfaces;
using TestApp_Money.UseCases.Features.Records.Commands.CreateRecord;

namespace TestApp_Money.UseCases.Features.Records.Commands.UpdateRecord
{
    public class UpdateRecordCommandHandler : IRequestHandler<UpdateRecordCommand, Guid>
    {
        private IDbContext _context;

        public UpdateRecordCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public Task<Guid> Handle(UpdateRecordCommand request, CancellationToken cancellationToken)
        {
            var recordEntity = _context.Records
                .Include(r => r.User)
                .First(r => r.Id == request.Id && r.User.Id == request.UserId);

            var category = _context.Categories
                .First(c => c.Name == request.Category);

            recordEntity.Description = request.Description;
            recordEntity.CreatedDate = request.CreatedDate;
            recordEntity.Value = request.Value;
            recordEntity.Category = category;

            _context.SaveChanges();

            return Task.FromResult(recordEntity.Id);
        }
    }
}
