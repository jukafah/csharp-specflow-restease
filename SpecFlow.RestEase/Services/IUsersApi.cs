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
        [Get("users")]
        Task<Response<List<User>>> GetUsers([Query] string since = null);
        
        [Get("users/{username}")]
        Task<Response<User>> GetUser([Path] string username = null);
    }
}