using CommunityToolkit.Maui;
using GroceryApp.Interfaces;
using GroceryApp.Services;
using GroceryApp.ViewModels;
using GroceryApp.Views;
using Microsoft.Extensions.Logging;

namespace GroceryApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Ubuntu-Regular.ttf", "UbuntuRegular");
                    fonts.AddFont("Ubuntu-Bold.ttf", "UbuntuBold");
                });

            builder.Services.AddSingleton<IPlatformHttpMessageHandler>(sp =>
            {
#if ANDROID
                return new Platforms.Android.AndroidHttpMessageHandler();
#elif IOS
                return new Platforms.iOS.IosHttpMessageHandler(); 
#elif MACCATALYST
                return null;
#elif WINDOWS
                return null;
#endif
            });

            builder.Services.AddHttpClient(Constants.AppConstants.HttpClientName, httpClient =>
            {
                var baseAddress = DeviceInfo.Platform == DevicePlatform.Android
                ? "https://10.0.2.2:12345"
                : "https://localhost:12345";
                httpClient.BaseAddress = new Uri(baseAddress);
            })
             .ConfigureHttpMessageHandlerBuilder(configBuilder => { 
                var platformHttpMessageHandler = configBuilder.Services.GetRequiredService<IPlatformHttpMessageHandler>();
                configBuilder.PrimaryHandler = platformHttpMessageHandler.GetHttpMessageHandler();
            });

            builder.Services.AddSingleton<CategoryService>();
            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<HomePageViewModel>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
