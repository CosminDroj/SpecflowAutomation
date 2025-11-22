using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowPlaywright.Pages;

public class LoginPage
{
    private IPage _page;

    public LoginPage(IPage page) => _page = page;
    private ILocator _lnkLogin => _page.Locator("text=Login");
    private ILocator _txtUserName => _page.Locator("#UserName");
    private ILocator _txtPassword => _page.Locator("#Password");
    private ILocator _btnLogin => _page.Locator("text=Log in");
    private ILocator _lnkEmployeeDetails => _page.Locator("text=Employee Details");
    private ILocator _lnkEmployeeLists => _page.Locator("text=Employee List");



    public async Task ClickLogin() => await _lnkLogin.ClickAsync();
    public async Task ClickEmployeeList() => await _lnkEmployeeLists.ClickAsync();

    public async Task Login(string UserName, string Password)
    {
        await _txtUserName.FillAsync(UserName);
        await _txtPassword.FillAsync(Password);
        await _btnLogin.ClickAsync();
    }

    public async Task<bool> IsEmployeeDetailsExists() => await _lnkEmployeeDetails.IsVisibleAsync();

}
