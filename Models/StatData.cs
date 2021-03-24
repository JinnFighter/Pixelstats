namespace Pixelstats.Models
{
    public class StatData
    {
        public int Id { get; set; }
        public float Time { get; set; }
        public int CorrectAnswers { get; set; }
        public int WrongAnswers { get; set; }

        public virtual GameMode GameMode { get; set; }
        public virtual User User { get; set; }
    }
}
