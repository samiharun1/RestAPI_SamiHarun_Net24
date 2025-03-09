namespace RestAPI_SamiHarun_Net24.Models
{
    public class GitHubRepo
    {
        public string Name { get; set; } = string.Empty;
        public string Language { get; set; } = "okänt"; // Om inget språk anges
        public string Description { get; set; } = "saknas"; // Om ingen beskrivning finns
        public string Html_Url { get; set; } = string.Empty;
    }
}
