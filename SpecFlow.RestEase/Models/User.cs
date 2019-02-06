using Newtonsoft.Json;

namespace SpecFlow.RestEase.Models
{
    // user model to deserialize responses from the users endpoint
    public class User
    {
        public string Login { get; set; }
        public int Id { get; set; }
        
        // property in response is `repos_url`, needs attribute to declare in C# properly and deserialize correct value
        [JsonProperty("repos_url")]
        
        // property in response is `html_url`, needs attribute to declare in C# properly and deserialize correct value
        public string ReposUrl { get; set; }
        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }
        public string Name { get; set; }
        public string Blog { get; set; }
        public string Url { get; set; }
        
        // setting a custom Email get and set due to SpecFlow inability to populate `null` from data tables easily
        private string _email;
        public string Email
        {
            get => _email;
            set => _email = value == "null" ? null : value;
        }
        public string Bio { get; set; } 
    }
}