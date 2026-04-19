using MatchStatCharts.Model;
using MatchStatCharts.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FluentUI.AspNetCore.Components;
using Syncfusion.Blazor;
using System.Net.Http.Json;


namespace MatchStatCharts
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1JHaF5cWWRCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdlWXtfeHVcQ2FZWUx/WEVWYEo=");
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.Services.AddSyncfusionBlazor();
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<IMatchTrackerHttpService, MatchTrackerHttpService>();
            builder.Services.AddFluentUIComponents();


            await builder.Build().RunAsync();


        }

       
    }
}
