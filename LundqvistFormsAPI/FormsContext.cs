using FormsLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LundqvistFormsAPI
{
    public class FormsContext : DbContext
    {
        public DbSet<FormModel> Forms { get; set; }
        public DbSet<SegmentModel> Segments { get; set; }
        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<AnswerModel> Answers { get; set; }
        public DbSet<ChoiceModel> Choices { get; set; }
        public DbSet<ScaleModel> Scales { get; set; }
        public DbSet<MultipleChoiceAnswerModel> MultipleChoiceAnswers{ get; set; }
        public DbSet<TimeIntervalAnswerModel> TimeIntervalAnswers { get; set; }

        public FormsContext(DbContextOptions<FormsContext> options) : base(options) { }
    }
}
