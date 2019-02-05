using Newtonsoft.Json;

namespace SpecFlow.RestEase.Models
{
    public class User
    {
        public int Id { get; set; }
        [JsonProperty("repos_url")]
        public string ReposUrl { get; set; }
        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }
        public string Name { get; set; }
        public string Blog { get; set; }
        public string Url { get; set; }
        private string _email;
        public string Email
        {
            get => _email;
            set => _email = value == "null" ? null : value;
        }
        public string Bio { get; set; } 
    }
}