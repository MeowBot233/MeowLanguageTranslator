using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MudBlazor.Services;
using CurrieTechnologies.Razor.Clipboard;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;

namespace MeowLanguageTranslator
{
    public class Program
    {
        public static IServiceCollection Services;

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.ShowTransitionDuration = 200;
                config.SnackbarConfiguration.HideTransitionDuration = 200;
                config.SnackbarConfiguration.NewestOnTop = true;
                config.SnackbarConfiguration.ShowCloseIcon = false;
                config.SnackbarConfiguration.VisibleStateDuration = 500;
                config.SnackbarConfiguration.SnackbarVariant = MudBlazor.Variant.Text;
            });
            builder.Services.AddClipboard();
            Services = builder.Services;

            await builder.Build().RunAsync();
        }
    }

    public static class Ext
    {
        public static void Back(this NavigationManager navigation)
        {
            var jsruntime = Program.Services.BuildServiceProvider().GetService<IJSRuntime>();
            jsruntime.InvokeVoidAsync("history.back");
        }
    }
}
