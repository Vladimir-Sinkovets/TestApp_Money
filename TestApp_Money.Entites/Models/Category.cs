namespace TestApp_Money.Entites.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
    }
}
