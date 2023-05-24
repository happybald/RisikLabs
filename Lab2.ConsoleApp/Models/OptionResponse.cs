namespace Lab2.ConsoleApp.Models
{
    public class OptionResponse
    {
        public int Id { get; set; }
        public int ResponseId { get; set; }
        public Response Response { get; set; } = null!;
        public int OptionId { get; set; }
        public Option Option { get; set; } = null!;
    }
}
