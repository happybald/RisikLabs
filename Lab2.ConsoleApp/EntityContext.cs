using Lab2.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
namespace Lab2.ConsoleApp
{
    public class EntityContext : DbContext
    {
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<OptionResponse> OptionResponses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Database=Lab2;Pooling=true;Uid=postgres;Pwd=postgres;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var survey = new Survey()
            {
                Id = 1,
                Title = "AvtoService",
            };
            var questions = new List<Question>()
            {
                new Question()
                {
                    Id = 1,
                    SurveyId = 1,
                    Text = "Яка автомобільна марка вважається надійною?",
                },
                new Question()
                {
                    Id = 2,
                    SurveyId = 1,
                    Text = "Яка автомобільна марка вважається економічно вигідною?",
                },
                new Question()
                {
                    Id = 3,
                    SurveyId = 1,
                    Text = "Яка автомобільна марка має найкращий дизайн?",
                },
                new Question()
                {
                    Id = 4,
                    SurveyId = 1,
                    Text = "Яка автомобільна марка надає найкращі технологічні рішення?",
                }
            };

            var options = new List<Option>()
            {

                new Option()
                {
                    Id = 1,
                    QuestionId = 1,
                    Text = AutoBrand.Toyota.ToString(),
                },
                new Option()
                {
                    Id = 2,
                    QuestionId = 1,
                    Text = AutoBrand.Honda.ToString(),
                },
                new Option()
                {
                    Id = 3,
                    QuestionId = 1,
                    Text = AutoBrand.Ford.ToString(),
                },
                new Option()
                {
                    Id = 4,
                    QuestionId = 1,
                    Text = AutoBrand.Bmw.ToString(),
                },
                new Option()
                {
                    Id = 5,
                    QuestionId = 2,
                    Text = AutoBrand.Toyota.ToString(),
                },
                new Option()
                {
                    Id = 6,
                    QuestionId = 2,
                    Text = AutoBrand.Honda.ToString(),
                },
                new Option()
                {
                    Id = 7,
                    QuestionId = 2,
                    Text = AutoBrand.Ford.ToString(),
                },
                new Option()
                {
                    Id = 8,
                    QuestionId = 2,
                    Text = AutoBrand.Bmw.ToString(),
                },
                new Option()
                {
                    Id = 9,
                    QuestionId = 3,
                    Text = AutoBrand.Toyota.ToString(),
                },
                new Option()
                {
                    Id = 10,
                    QuestionId = 3,
                    Text = AutoBrand.Honda.ToString(),
                },
                new Option()
                {
                    Id = 11,
                    QuestionId = 3,
                    Text = AutoBrand.Ford.ToString(),
                },
                new Option()
                {
                    Id = 12,
                    QuestionId = 3,
                    Text = AutoBrand.Bmw.ToString(),
                },
                new Option()
                {
                    Id = 13,
                    QuestionId = 4,
                    Text = AutoBrand.Toyota.ToString(),
                },
                new Option()
                {
                    Id = 14,
                    QuestionId = 4,
                    Text = AutoBrand.Honda.ToString(),
                },
                new Option()
                {
                    Id = 15,
                    QuestionId = 4,
                    Text = AutoBrand.Ford.ToString(),
                },
                new Option()
                {
                    Id = 16,
                    QuestionId = 4,
                    Text = AutoBrand.Bmw.ToString(),
                }
            };
            modelBuilder.Entity<Survey>().HasData(survey);
            modelBuilder.Entity<Question>().HasData(questions);
            modelBuilder.Entity<Option>().HasData(options);
        }
    }
}
