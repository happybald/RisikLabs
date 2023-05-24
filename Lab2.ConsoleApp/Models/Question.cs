namespace Lab2.ConsoleApp.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<Option> Options { get; set; } = null!;
        public int SurveyId { get; set; } 
        public Survey Survey { get; set; } 
    }
}
