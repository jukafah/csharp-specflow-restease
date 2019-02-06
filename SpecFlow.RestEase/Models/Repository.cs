using System;
using Newtonsoft.Json;

namespace SpecFlow.RestEase.Models
{
    // repository model to deserialize responses from the repos endpoint
    public class Repository
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // setting a custom FullName get and set due to SpecFlow inability to populate `null` from data tables easily
        private string _fullName;
        public string FullName 
        {
            get => _fullName;
            set => _fullName = value == "null" ? null : value;
        }
        
        public User Owner { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        
        // property in response is `html_url`, needs attribute to declare in C# properly and deserialize correct value
        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }
        public string DefaultBranch { get; set; }
        public bool HasProjects { get; set; }
        
        // property in response is `created_at`, needs attribute to declare in C# properly and deserialize correct value
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        
        // property in response is `updated_at`, needs attribute to declare in C# properly and deserialize correct value
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        
        // property in response is `pushed_at`, needs attribute to declare in C# properly and deserialize correct value
        [JsonProperty("pushed_at")]
        public DateTime PushedAt { get; set; }
    }
}