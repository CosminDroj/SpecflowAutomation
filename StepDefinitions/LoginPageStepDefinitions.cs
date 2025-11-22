using FluentAssertions;
using Microsoft.Playwright;
using Reqnroll;
using Reqnroll.Assist.Dynamic;
using SpecFlow;
using SpecFlowPlaywright.Drivers;
using SpecFlowPlaywright.Pages;
using System;
using System.Threading.Tasks;



namespace SpecFlowPlaywright.StepDefinitions
{
    

    [Binding]
    public class LoginPageStepDefinitions
    {
        private readonly Driver _driver;
        private readonly LoginPage _loginPage;
            public LoginPageStepDefinitions(Driver driver)
        {
            _driver = driver;
            _loginPage = new LoginPage(_driver.Page);
           
        }
        [Given("Navigate into website")]
        public async Task GivenNavigateIntoWebsiteAsync()
        {
            _driver.Page.GotoAsync("http://www.eaapp.somee.com");
        }

        [Given("Click on Login link")]
        public async Task GivenClickOnLoginLink()
        {
            _loginPage.ClickLogin();
            
        }

        [Given("Add username and password on related fields")]
        public async Task GivenAddUsernameAndPasswordOnRelatedFields(DataTable dataTable)
        {
            dynamic data = dataTable.CreateDynamicInstance();
            _loginPage.Login((string)data.Username, (string)data.Password);
        }

        [Then("Succesfully login")]
        public async Task ThenSuccesfullyLogin()
        {
            var isExist = await _loginPage.IsEmployeeDetailsExists();
            isExist.Should().BeTrue();
        }
    }
}
