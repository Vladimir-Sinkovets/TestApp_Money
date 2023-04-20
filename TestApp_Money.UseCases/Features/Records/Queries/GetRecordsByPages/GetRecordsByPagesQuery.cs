using MediatR;

namespace TestApp_Money.UseCases.Features.Records.Queries.GetRecordsByPages
{
    public class GetRecordsByPagesQuery : IRequest<IEnumerable<RecordDto>>
    {
        public string UserId { get; set; }
        public int PageNumber { get; set; }
        public int ItemsPerPage { get; set; }
    }
}
