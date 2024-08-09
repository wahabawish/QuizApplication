namespace PROJ1.Models
{
    public class QuestionViewModel
    {
        public int UserScore { get; set; }
        public int TotalQuestions { get; set; }
        public IEnumerable<Question> Questions { get; set; }
    }
}
