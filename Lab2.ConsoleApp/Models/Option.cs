using System.ComponentModel.DataAnnotations.Schema;
namespace Lab2.ConsoleApp.Models
{
    public class Option
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; } = null!;
        [NotMapped]
        public double Value { get; set; }
    }
}
