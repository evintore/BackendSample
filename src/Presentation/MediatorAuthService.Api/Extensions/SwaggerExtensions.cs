using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace MediatorAuthService.Api.Extensions;

/// <summary>
/// Customizes Swagger-related settings.
/// </summary>
public class ConfigureSwaggerOptions() : IConfigureNamedOptions<SwaggerGenOptions>
{
    /// <summary>
    /// Configure each API discovered for Swagger Documentation
    /// </summary>
    /// <param name="options"></param>
    public void Configure(SwaggerGenOptions options)
    {
        // add jwt security
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JSON Web Token based security",
        });

        // add jwt bearer security
        options.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });

        // Endpoint descriptions
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
    }

    /// <summary>
    /// Configure Swagger Options. Inherited from the Interface
    /// </summary>
    /// <param name="name"></param>
    /// <param name="options"></param>
    public void Configure(string name, SwaggerGenOptions options) => Configure(options);
}

/// <summary>
/// Add SwaggerUI Extension
/// </summary>
public static class AddSwaggerUIExtension
{
    /// <summary>
    /// Add SwaggerUI
    /// </summary>
    public static IApplicationBuilder AddSwaggerUI(this IApplicationBuilder app)
    {
        return app.UseSwaggerUI();
    }
}