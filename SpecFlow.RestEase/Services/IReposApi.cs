using System.Collections.Generic;
using System.Threading.Tasks;
using RestEase;
using SpecFlow.RestEase.Models;

namespace SpecFlow.RestEase.Services
{
    [Header("User-Agent", "RestEase")]
    public interface IReposApi
    {
        [Get("/users/{username}/repos")]
        Task<Response<Repository>> GetUserRepositories([Path] string username = null, [Query] string name = null,
            [Query] string sort = null, [Query] string direction = null);

        [Get("/repositories")]
        Task<Response<Repository>> GetAllPublicRepositories([Query] string since = null);
    }
}