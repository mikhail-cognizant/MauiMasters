using CommunityToolkit.Maui;
using MauiMasters.Services;
using Microsoft.Extensions.Logging;

namespace MauiMasters;

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
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<IGroceryService, GroceryService>();
        builder.Services.AddSingleton<GroceryList>();
        builder.Services.AddSingleton<GroceryListViewModel>();
        builder.Services.AddSingleton<CheckoutCart>();
        builder.Services.AddSingleton<CheckoutCartViewModel>();
        builder.Services.AddSingleton<ThankYou>();

        return builder.Build();
	}
}
