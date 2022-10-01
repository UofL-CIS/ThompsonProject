using ThompsonProject.WebApi.Services;

namespace ThompsonProject.WebApi.Extensions;

internal static class MappingExtensions
{
    public static WebApplication UseVolunteerMappings(this WebApplication webApp)
    {

        webApp.MapGet("/volunteer", async () =>
        {
            using var scope = webApp.Services.CreateAsyncScope();
            var volunteerService = scope.ServiceProvider.GetRequiredService<IVolunteerService>();
            return Results.Ok(await volunteerService.ListVolunteersAsync());
        })
        .WithName("GetVolunteers");

        return webApp;
    }

    public static WebApplication UseEventMappings(this WebApplication webApp)
    {
        webApp.MapGet("/", () =>
        {
            return Results.Ok("Hello World");
        })
        .WithName("Get");

        return webApp;
    }
}
