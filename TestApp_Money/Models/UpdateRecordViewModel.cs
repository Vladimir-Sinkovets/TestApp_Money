namespace TestApp_Money.Web.Models
{
    public class UpdateRecordViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Category { get; set; }
        public double Value { get; set; }
        public IList<string> AllCategories { get; set; }
    }
}
