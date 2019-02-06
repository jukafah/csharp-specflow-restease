using System.Collections.Generic;
using System.Net;
using FluentAssertions;
using RestEase;
using SpecFlow.RestEase.Models;
using SpecFlow.RestEase.Services;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlow.RestEase.StepDefinitions
{
    [Binding]
    public class UserSteps
    {
        private IUsersApi _usersApi;
        private Response<User> _userResponse;
        private Response<List<User>> _usersResponse;
        
        // exposing api in gherkin and using it to instantiate interface in first 'Given' step
        [Given(@"the github api ""(.*)""")]
        public void GivenTheGithubApi(string url)
        {
            _usersApi = RestClient.For<IUsersApi>(url);
        }
        
        // passing username through gherkin to step
        [When(@"I get user ""(.*)""")]
        public void WhenIGetUser(string username)
        {
            _userResponse = _usersApi.GetUser(username).Result;
        }
        
        [Then(@"the following data returns")]
        public void ThenTheDataMatches(Table table)
        {
            // create an instance of a user object from gherkin data table
            var user = table.CreateInstance<User>();
            var actualUser = _userResponse.GetContent();
            user.Should().BeEquivalentTo(actualUser);
        }
        
        [When(@"I get all users starting with page ""(.*)""")]
        public void WhenIGetAllUsersStartingWithPage(string since)
        {
            _usersResponse = _usersApi.GetUsers(since).Result;
        }
        
        [When(@"I get all users")]
        public void WhenIGetAllUsers()
        {
            _usersResponse = _usersApi.GetUsers().Result;
        }

        [Then(@"a list of users returns")]
        public void ThenAListOfUsersReturns()
        {
            var actualUsers = _usersResponse.GetContent();
            
            // chaining several different assertions
            actualUsers
                .Should().AllBeOfType<User>()
                .And.BeInAscendingOrder(user => user.Id)
                .And.NotContainNulls(user => user.Url)
                .And.NotContainNulls(user => user.HtmlUrl)
                .And.NotContainNulls(user => user.ReposUrl);
        }
        
        [Then(@"the users endpoint returns not found")]
        public void ThenTheServiceReturnsNotFound()
        {
            _userResponse.ResponseMessage.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        
        [When(@"I get all users starting with id ""(.*)""")]
        public void WhenIGetAllUsersStartingWithId(string userId)
        {
            _usersResponse = _usersApi.GetUsers(userId).Result;
        }
        
        [Then(@"a list of users returns starting with id ""(.*)""")]
        public void ThenAListOfUsersReturnsStartingWithId(int userId)
        {
            var actualUsers = _usersResponse.GetContent();

            // more assertion chaining
            actualUsers
                .Should().Contain(user => user.Id >= userId)
                .And.AllBeOfType<User>()
                .And.BeInAscendingOrder(user => user.Id)
                .And.NotContainNulls(user => user.Url)
                .And.NotContainNulls(user => user.HtmlUrl)
                .And.NotContainNulls(user => user.ReposUrl);
        }
    }
}