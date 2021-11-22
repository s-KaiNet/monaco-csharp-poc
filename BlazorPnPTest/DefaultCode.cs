namespace BlazorPnPTest
{
    public class DefaultCode
    {
        public static string Code = @"using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PnP.Core.Auth;
using PnP.Core.Services;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

public class RawAccessTokenProvider : IAuthenticationProvider
{
	private string token = ""<your SharePoint access token here>"";

	public async Task AuthenticateRequestAsync(Uri resource, HttpRequestMessage request)
	{
		request.Headers.Authorization = new AuthenticationHeaderValue(""bearer"",
			await GetAccessTokenAsync(resource).ConfigureAwait(false));
   }

	public Task<string> GetAccessTokenAsync(Uri resource, string[] scopes)
	{
		return Task.FromResult(token);
	}

	public Task<string> GetAccessTokenAsync(Uri resource)
	{
		return Task.FromResult(token);
	}
}

class Program
{
    static string siteUrl = ""https://m365x790252.sharepoint.com/sites/pnpcoresdktestgroup/"";

	public static async Task Main(string[] args)
	{
		var services = new ServiceCollection();

            services.AddPnPCore(options =>
            {
                // Configure the interactive authentication provider as default
                options.DefaultAuthenticationProvider = new RawAccessTokenProvider();
                options.PnPContext.GraphFirst = false;
            });

            var provider = services.BuildServiceProvider();

            var scope = provider.CreateScope();

            var pnpContextFactory = scope.ServiceProvider.GetRequiredService<IPnPContextFactory>();

            // Create a PnPContext
            using (var context = await pnpContextFactory.CreateAsync(new Uri(siteUrl)))
            {
                // Load the Title property of the site's root web
                await context.Web.LoadAsync(p => p.Title);
                Console.WriteLine($""The title of the web is {context.Web.Title}"");
            }
	}
}
";
    }
}
