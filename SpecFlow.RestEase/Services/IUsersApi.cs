using System.Collections.Generic;
using System.Threading.Tasks;
using RestEase;
using SpecFlow.RestEase.Models;

namespace SpecFlow.RestEase.Services
{
    [Header("User-Agent", "RestEase")]
    [AllowAnyStatusCode]
    public interface IUsersApi
    {
        // example of [Query], also setting a default of null. Defaults of null are not used
        // also uses Response<T> as return type to keep HttpResponseMessage and deserialized response of type <T>
        // in this case, T is List<User>
        [Get("users")]
        Task<Response<List<User>>> GetUsers([Query] string since = null);
        
        // example of single [Path], {username} replaced with value if passed through
        // also uses Response<T> as return type to keep HttpResponseMessage and deserialized response of type <T>
        // in this case, T is User
        [Get("users/{username}")]
        Task<Response<User>> GetUser([Path] string username = null);
    }
}