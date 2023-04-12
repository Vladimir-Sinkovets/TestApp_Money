namespace TestApp_Money.Entites.Models
{
    public class Record
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set;}
        public Category Category { get; set; }
        public decimal Value { get; set; }
    }
}
