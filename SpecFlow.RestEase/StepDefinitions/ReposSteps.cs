using System.Collections.Generic;
using System.Net;
using FluentAssertions;
using RestEase;
using SpecFlow.RestEase.Models;
using SpecFlow.RestEase.Services;
using TechTalk.SpecFlow;

namespace SpecFlow.RestEase.StepDefinitions
{
    [Binding]
    public class ReposSteps
    {
        private string _url = "https://api.github.com";
        private readonly IReposApi _reposApi;
        
        // keeping _queryParamaters as class member
        private Dictionary<string, string> _queryParameters;
        
        // response that contains both HttpResponseMessage for status code assertions and deserialization of type T
        private Response<List<Repository>> _reposResponse;
        private List<Repository> _repos;

        // instantiating interface in the constructor in this example instead. _url could come from testdata object
        // injected from hooks or other methods
        public ReposSteps()
        {
            _reposApi = RestClient.For<IReposApi>(_url);
        }
        
        [Given(@"username ""(.*)""")]
        public void GivenUsername(string username)
        {
            // setting property on interface for later request instead of as method argument
            _reposApi.Username = username;
        }
        
        // adding a few more actions on this one
        [When(@"I get a list of repositories")]
        public void WhenIGetAListOfRepositories()
        {
            // make request
            _reposResponse = _reposApi.GetUserRepositories(_queryParameters).Result;
            
            // assert status code as 'ok'
            _reposResponse.ResponseMessage.StatusCode.Should().Be(HttpStatusCode.OK);
            
            // deserialize response to type T
            _repos = _reposResponse.GetContent();
            
            // general assert for not being null or empty
            _repos.Should().NotBeNullOrEmpty();
        }
        
        // adding a few more actions on this one too - gets list of all public repositories
        [When(@"I get a list of all public repositories")]
        public void WhenIGetAListOfAllPublicRepositories()
        {
            // make request 
            _reposResponse = _reposApi.GetAllPublicRepositories(_queryParameters).Result;
            
            // assert status code as 'ok'
            _reposResponse.ResponseMessage.StatusCode.Should().Be(HttpStatusCode.OK);
            
            // deserialize response to type T
            _repos = _reposResponse.GetContent();
            
            // general assert for not being null or empty
            _repos.Should().NotBeNullOrEmpty();
        }
        
        [When(@"I get repositories")]
        public void WhenIGetRepositories()
        {
            _reposResponse = _reposApi.GetUserRepositories(_queryParameters).Result;  
        }

        [Then(@"the repos endpoint returns not found")]
        public void ThenServiceReturnsNotFound()
        {
            // asserting not found is handled
            _reposResponse.ResponseMessage.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        
        [Then(@"repository ""(.*)"" is in the list")]
        public void ThenRepositoryIsInTheList(string repositoryName)
        {
            // asserting a specific repository is found by name
            _repos.Should().ContainSingle(repo => repo.Name.Equals(repositoryName));
        }
        
        [Given(@"query parameters")]
        public void GivenQueryParameters(Table table)
        {
            // adding query parameters from data table instead
            // very useful if there are a lot of parameters or many combinations
            _queryParameters = new Dictionary<string, string>();

            foreach (var tableRow in table.Rows)
            {
                _queryParameters.Add(tableRow[0], tableRow[1]);
            }
        }
        
        // start of a variety of assert methods
        
        [Then(@"repositories are sorted by when they were created in descending direction")]
        public void ThenRepositoriesAreSortedByInDescendingDirection()
        {
            _repos.Should().BeInDescendingOrder(repo => repo.CreatedAt);
        }
        
        [Then(@"repositories are sorted by when they were created in ascending direction")]
        public void ThenRepositoriesAreSortedByInAscendingDirection()
        {
            _repos.Should().BeInAscendingOrder(repo => repo.CreatedAt);
        }
        
        [Then(@"repositories are sorted by last updated in ascending direction")]
        public void ThenRepositoriesAreSortedByLastUpdatedInAscendingDirection()
        {
            _repos.Should().BeInAscendingOrder(repo => repo.UpdatedAt);
        }
        
        [Then(@"repositories are sorted by last updated in descending direction")]
        public void ThenRepositoriesAreSortedByLastUpdatedInDescendingDirection()
        {
            _repos.Should().BeInDescendingOrder(repo => repo.UpdatedAt);
        }
        
        [Then(@"repositories are sorted by full name in ascending direction")]
        public void ThenRepositoriesAreSortedByFullNameInAscendingDirection()
        {
            _repos.Should().BeInAscendingOrder(repo => repo.FullName);
        }
        
        [Then(@"repositories are sorted by full name in descending direction")]
        public void ThenRepositoriesAreSortedByFullNameInDescendingDirec()
        {
            _repos.Should().BeInDescendingOrder(repo => repo.FullName);
        }
        
        [Then(@"repositories are sorted by last pushed in ascending direction")]
        public void ThenRepositoriesAreSortedByLastPushedInAscendingDirection()
        {
            _repos.Should().BeInAscendingOrder(repo => repo.PushedAt);
        }
        
        [Then(@"repositories are sorted by last pushed in descending direction")]
        public void ThenRepositoriesAreSortedByLastPushedInDescendingDirection()
        {
            _repos.Should().BeInDescendingOrder(repo => repo.PushedAt);
        }
        
        [Then(@"the list contains repositories not owned by user ""(.*)""")]
        public void ThenTheListContainsRepositoriesNotOwnedByUser(string username)
        {
            _repos.Should().Contain(repo => !repo.Owner.Login.Equals(username));
        }
        
        [Then(@"the list contains repositories owned by user ""(.*)""")]
        public void ThenTheListContainsRepositoriesOwnedByUser(string username)
        {
            _repos.Should().Contain(repo => repo.Owner.Login.Equals(username));
        }
        
        [Then(@"the list only contains repositories not owned by user ""(.*)""")]
        public void ThenTheListOnlyContainsRepositoriesNotOwnedByUser(string username)
        {
            _repos.Should().NotContain(repo => repo.Owner.Login.Equals(username));
        }
        
        [Then(@"the list only contains repositories owned by user ""(.*)""")]
        public void ThenTheListOnlyContainsRepositoriesOwnedByUser(string username)
        {
            _repos.Should().OnlyContain(repo => repo.Owner.Login.Equals(username));
        }
        
        [Then(@"the list contains repositories sorted by date created")]
        public void ThenTheListContainsRepositoriesSortedByDateCreated()
        {
            _repos.Should().BeInAscendingOrder(repo => repo.CreatedAt);
        }
        
        [Then(@"the list contains repositories starting with id ""(.*)""")]
        public void ThenTheListContainsRepositoriesStartingAtId(int repoId)
        {
            _repos.Should().Contain(repo => repo.Id >= repoId)
                .And.BeInAscendingOrder(repo => repo.Id);
        }
        
        [Then(@"the list of repositories have basic information available")]
        public void ThenTheRepositoriesHaveBasicInformationAvailable()
        {
            _repos.Should().AllBeOfType<Repository>()
                .And.OnlyHaveUniqueItems(repo => repo.Id)
                .And.NotContainNulls(repo => repo.Name)
                .And.NotContainNulls(repo => repo.Url)
                .And.NotContainNulls(repo => repo.Owner);

        }
    }
}