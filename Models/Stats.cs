namespace Pixelstats.Models
{
    public class Stats
    {
        public float Time { get; set; }
        public int CorrectAnswers { get; set; }
        public int WrongAnswers { get; set; }

        public virtual User User { get; set; }
    }
}
