using BoDi;
using RestEase;
using SpecFlow.RestEase.Services;
using TechTalk.SpecFlow;

namespace SpecFlow.RestEase.Support
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private string _url = "https://api.github.com";

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            // doo stuff
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
//            _objectContainer.RegisterInstanceAs(_url);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            // doo even more stuff
        }
    }
}