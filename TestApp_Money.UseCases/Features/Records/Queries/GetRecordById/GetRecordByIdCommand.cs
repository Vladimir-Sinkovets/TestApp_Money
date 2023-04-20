using MediatR;

namespace TestApp_Money.UseCases.Features.Records.Queries.GetRecordById
{
    public class GetRecordByIdCommand : IRequest<SingleRecordData>
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
    }
}
