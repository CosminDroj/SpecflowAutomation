using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Playwright;

namespace SpecFlowPlaywright.Drivers
{
    public class Driver: IDisposable
    {
        private readonly Task<IPage> _page;
        private IBrowser? _browser;

        public Driver()
        {
            _page = InitPlaywright();
        }

        public IPage Page => _page.Result;

        public void Dispose()
        {
            _browser.CloseAsync();
        }

        public async Task<IPage> InitPlaywright()
        {
            using var playwright = await Playwright.CreateAsync();

            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            //Page

            return await _browser.NewPageAsync();
        }
    }
}
