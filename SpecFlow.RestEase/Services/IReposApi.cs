using System.Collections.Generic;
using System.Threading.Tasks;
using RestEase;
using SpecFlow.RestEase.Models;

namespace SpecFlow.RestEase.Services
{
    [Header("User-Agent", "RestEase")]
    [AllowAnyStatusCode]
    public interface IReposApi
    {
        // path as a property demonstrating the ability to set a bit different
        [Path("username")]
        string Username { get; set; }
        
        // query parameters as [QueryMap] IDictionary. Useful for passing different parameters
        // as table in gherkin. Also a Response<T> to keep both HttpResponseMessage and deserialized response of type T
        // in this case, T is List<Respository>
        [Get("/users/{username}/repos")]
        Task<Response<List<Repository>>> GetUserRepositories([QueryMap] IDictionary<string, string> queryParameters);

        // query parameters as [QueryMap] IDictionary. Useful for passing different parameters
        // as table in gherkin. Also a Response<T> to keep both HttpResponseMessage and deserialized response of type T
        // in this case, T is List<Respository>
        [Get("/repositories")]
        Task<Response<List<Repository>>> GetAllPublicRepositories([QueryMap] IDictionary<string, string> queryParameters);
    }
}