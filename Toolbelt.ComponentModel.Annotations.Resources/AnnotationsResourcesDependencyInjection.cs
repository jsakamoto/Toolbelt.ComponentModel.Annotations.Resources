using Microsoft.Extensions.DependencyInjection;
using Toolbelt.ComponentModel.Annotations.Resources;

namespace Toolbelt.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for injecting a system resource manager.
/// </summary>
public static class AnnotationsResourcesDependencyInjection
{
    /// <summary>
    /// Inject the resource manager as a system resource.
    /// </summary>
    /// <param name="services">The instance of Microsoft.Extensions.DependencyInjection.IServiceCollection.</param>
    public static IServiceCollection AddSystemComponentModelAnnotationsLocalization(this IServiceCollection services)
    {
        return services.AddSystemResourceManager<ValidationErrorMessages>();
    }
}
