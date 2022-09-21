namespace ThompsonProject.WebApi.Extensions;

internal static class MappingExtensions
{
    public static WebApplication UseCustomMappings(this WebApplication webApp)
    {

        webApp.MapGet("/", () =>
        {
            return Results.Ok();
        })
        .WithName("I'm alive");

        return webApp;
    }
}
