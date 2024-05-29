namespace LogDivSample.Models
{
    public class Message(string content, bool error = false, int duree = 5)
    {
        public string Content { get; init; } = content;
        public int Duree { get; init; } = duree;
        public bool Error { get; init; } = error;
    }
}
