using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SpecFlow.RestEase.Models
{
    public class Repository
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public User Owner { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        
        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }
        public string DefaultBranch { get; set; }
        public bool HasProjects { get; set; }    
    }
}