using MediatR;

namespace TestApp_Money.UseCases.Features.Records.Commands.UpdateRecord
{
    public class UpdateRecordCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Category { get; set; }
        public double Value { get; set; }
    }
}
