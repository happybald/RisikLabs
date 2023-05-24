namespace Lab2.ConsoleApp.Models
{
    public class Survey
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Question> Questions { get; set; } = null!;
    }

}
