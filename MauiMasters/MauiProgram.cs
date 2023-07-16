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

        builder.Services.AddTransient<IGroceryService, GroceryService>();
        builder.Services.AddTransient<GroceryList>();
        builder.Services.AddTransient<GroceryListViewModel>();
        builder.Services.AddTransient<CheckoutCart>();
        builder.Services.AddTransient<CheckoutCartViewModel>();
        builder.Services.AddTransient<ThankYou>();

        return builder.Build();
	}
}
