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

        public Hooks(IObjectContainer objectContainer)
        {
            // can be used to register objects for use in step constructors
            _objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            // do stuff before a test run starts
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            // can be useful for preparing test data classes to pass around step definitions
            // _objectContainer.RegisterInstanceAs(yourObjectHere);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            // do stuff after a scenario has finished
        }
    }
}