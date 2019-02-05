using System;
using System.Collections.Generic;
using RestEase;
using SpecFlow.RestEase.Models;
using SpecFlow.RestEase.Services;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlow.RestEase.StepDefinitions
{
    [Binding]
    public class ReposSteps
    {
        private string _url = "https://api.github.com";
        private readonly IReposApi _reposApi;
        private Response<Repository> _reposResponse;

        public ReposSteps()
        {
            _reposApi = RestClient.For<IReposApi>(_url);
        }
        
        [When(@"I get repos of ""(.*)""")]
        public void WhenIGetReposOf(string username)
        {
           _reposResponse = _reposApi.GetUserRepositories(username).Result;

           var content = _reposResponse.GetContent();

            Console.WriteLine("hi");
        }
        
        [Then(@"the list of repos contains")]
        public void ThenTheListOfReposContains(Table table)
        {
            var repos = table.CreateInstance<Repository>();

            Console.WriteLine("Hi");
        }
    }
}