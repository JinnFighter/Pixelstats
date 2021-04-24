namespace Pixelstats.Models
{
    public class ApiData
    {
        public string PlayerName { get; set; }
        public string GameModeName { get; set; }
        public float Time { get; set; }
        public int CorrectAnswers { get; set; }
        public int WrongAnswers { get; set; }
    }
}
