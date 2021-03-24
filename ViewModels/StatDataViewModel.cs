namespace Pixelstats.ViewModels
{
    public class StatDataViewModel
    {
        public string GameModeName { get; set; }
        public string Time { get; set; }
        public uint CorrectAnswers { get; set; }
        public uint WrongAnswers { get; set; }
        public int SuccessRate { get; set; }
    }
}
