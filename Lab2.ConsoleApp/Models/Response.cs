namespace Lab2.ConsoleApp.Models
{
    public class Response
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }
        public List<OptionResponse> OptionResponses { get; set; } = null!;
    }
}
