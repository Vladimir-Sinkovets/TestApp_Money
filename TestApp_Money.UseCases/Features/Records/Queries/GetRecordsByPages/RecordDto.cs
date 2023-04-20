using TestApp_Money.Entites.Models;

namespace TestApp_Money.UseCases.Features.Records.Queries.GetRecordsByPages
{
    public class RecordDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Category { get; set; }
        public double Value { get; set; }
    }
}
